<#
    EDIT THE FOLLOWING BEFORE RUNNING:

    - replace [TENANT] in $tenantAdminUrl
    - replace [PATH] in path to json file
    - rename COB references as necessary :)

#>

$creds = Get-Credential
$tenantAdminUrl = "https://[TENANT]-admin.sharepoint.com"

Connect-SPOService -Url $tenantAdminUrl -Credential $creds

## STEP 1 - Register site script ## 

Get-Content 'C:\[PATH]\COB_ProjectSite.json' -Raw | Add-SPOSiteScript -Title "COB project site script" 
Write-Output "Added site script" 

## STEP 2 - Register site design, with pointer to site script ## 

# COMMENT THIS SECTION BACK IN AFTER STEP 1 HAS BEEN EXECUTED

# script ID is obtained from previous output..
$cobProjectSiteScriptIdAsString = "[SITE SCRIPT ID FROM PREVIOUS STEP]"

Add-SPOSiteDesign `
-Title "COB project site" `
-WebTemplate "64" `
-SiteScripts $cobProjectSiteScriptIdAsString `
-Description "Creates a COB project site with a theme applied"  