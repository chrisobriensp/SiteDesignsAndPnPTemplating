# COB resources for SharePoint Site Designs

Please see accompanying blog post - TODO: LINK

## This project includes:

- A sample Site Script/Site Design, including the PowerShell to register them
- Integration with PnP templating using the suggested approach of:
  -  Site Design > Flow > Azure queue > Azure Function to apply template
- A C# Azure Function project
- A simplified PnP template (stored within the C# project, since it needs to be deployed to the Azure Function)

The Flow which links the Site Design and PnP side of things is *not* included, since it's simpler for you to create this yourself. It only has a couple of actions:

![Add HTTP request trigger to Flow](https://4.bp.blogspot.com/-K6FBEkhx1nI/XEcvAKvmrTI/AAAAAAAAF74/8Zieupm2eiguVyimTKBD6nS_svoLS6L4wCLcBGAs/s1600/CreateSiteDesignFlow3.png)

![Key action in the Flow - put message on queue](https://2.bp.blogspot.com/-rVLsBA-bTjg/XEcvBuSGAuI/AAAAAAAAF8Q/3HqEiB0kgvQ77Y4kfZWBUKb4TuRgQJqZgCLcBGAs/s1600/CreateSiteDesignFlow9.png)

## The setup process

Please see the accompanying blog post - TODO: LINK.

## The result

Once everything is deployed, you should have a situation where sites can be created from your site design, with the site design **and** PnP template being applied. :sparkles:

TODO: IMAGES.





