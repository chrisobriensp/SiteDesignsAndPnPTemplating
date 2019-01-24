using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.IO;
using System.Configuration;

namespace COBProvisioningFunctions
{
    public static class ApplyPnPTemplate
    {
        private static readonly string PNP_TEMPLATE_FILE = "COBProjectSite.xml";

        [FunctionName("ApplyPnPTemplate")]
        public static void Run([QueueTrigger("cob-provisioning-demo")]string myQueueItem, TraceWriter log, ExecutionContext functionContext)
        {
            log.Info($"ApplyPnPTemplate function started for item: {myQueueItem}");

            try
            {
                var clientID = ConfigurationManager.AppSettings["ProvisioningAppClientID"];
                var clientSecret = ConfigurationManager.AppSettings["ProvisioningAppClientSecret"];

                log.Info($"Fetched client ID '{clientID}' from AppSettings.'");

                ClientCredentials provisioningCreds = new ClientCredentials { ClientID = clientID, ClientSecret = clientSecret };
                applyTemplate(myQueueItem, functionContext, provisioningCreds, log);
            }
            catch (Exception e)
            {
                log.Error($"Error when running ApplyPnPTemplate function. Exception: {e}");
                throw;
            }
        }

        private static void applyTemplate(string siteUrl, ExecutionContext functionContext, ClientCredentials credentials, TraceWriter log)
        {
            try
            {
                using (var ctx = new AuthenticationManager().GetAppOnlyAuthenticatedContext(siteUrl, credentials.ClientID, credentials.ClientSecret))
                {
                    Web web = ctx.Web;
                    ctx.Load(web, w => w.Title);
                    ctx.ExecuteQueryRetry();

                    log.Info($"Successfully connected to site: {web.Title}");

                    string currentDirectory = functionContext.FunctionDirectory;
                    DirectoryInfo dInfo = new DirectoryInfo(currentDirectory);
                    var schemaDir = dInfo.Parent.FullName + "\\Templates";
                    XMLTemplateProvider sitesProvider = new XMLFileSystemTemplateProvider(schemaDir, "");

                    log.Info($"About to get template with with filename '{PNP_TEMPLATE_FILE}'");

                    ProvisioningTemplate template = sitesProvider.GetTemplate(PNP_TEMPLATE_FILE);

                    log.Info($"Successfully found template with ID '{template.Id}'");

                    ProvisioningTemplateApplyingInformation ptai = new ProvisioningTemplateApplyingInformation
                    {
                        ProgressDelegate = (message, progress, total) =>
                        {
                            log.Info(string.Format("{0:00}/{1:00} - {2}", progress, total, message));
                        }
                    };

                    // Associate file connector for assets..
                    FileSystemConnector connector = new FileSystemConnector(Path.Combine(currentDirectory, "Files"), "");
                    template.Connector = connector;

                    web.ApplyProvisioningTemplate(template, ptai);
                }
            }
            catch (Exception e)
            {
                log.Error("Error when applying PnP template!", e);
                throw;
            }
        }
    }
}
