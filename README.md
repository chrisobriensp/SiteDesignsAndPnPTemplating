# COB resources for SharePoint Site Designs

Please see accompanying blog post - <a href="https://cob-sp.com/Site-Designs-PnP-1">https://cob-sp.com/Site-Designs-PnP-1</a>

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

Please see the accompanying blog post - <a href="https://cob-sp.com/Site-Designs-PnP-1">https://cob-sp.com/Site-Designs-PnP-1</a>

## The result

Once everything is deployed, you should have a situation where sites can be created from your site design, with the site design **and** PnP template being applied. :sparkles:

![User creating site with Site Design - step 1](https://3.bp.blogspot.com/-OpgI7GBlb6o/XFByhmVCovI/AAAAAAAAF_0/9lVgYq3XouEV0XOxciN8il5WlUIPqi1CgCLcBGAs/s1600/CreateSite1.png)

![User creating site with Site Design - step 2](https://1.bp.blogspot.com/-EddWdkcyo5M/XFByhYBWFWI/AAAAAAAAF_s/xi3KMhuUqmEvQK96ex8nyrNC_4GmSHExQCLcBGAs/s320/CreateSite2.png)

![User creating site with Site Design - step 3](https://1.bp.blogspot.com/-hAYh2Q8YC5A/XFByhZmpOCI/AAAAAAAAF_w/MLYI29Ieih8RKyP1WY9pOQZEfUK1enrPwCLcBGAs/s320/CreateSite3.png)

![User creating site with Site Design](https://4.bp.blogspot.com/-Sj67mfqry6I/XFBvujtk66I/AAAAAAAAF_Q/AOYq9mjNEx0Ot9F1MnFRxQC9vm1CiRQvgCLcBGAs/s320/Result2.png)

![Site Design being applied](https://4.bp.blogspot.com/-n6dOz9W3AHc/XFBvtzcC2DI/AAAAAAAAF_I/dXdx8ImEtvUwgUwV_ytgRqDTTk9vPXM9ACLcBGAs/s320/Result1.png)

Finally, the created site is ready, with both the Site Design and PnP template being applied (with an eye-watering modern theme in this case!) All document libraries, content types, navigation links, and any other items being provisioned will be there:

![Resulting site](https://2.bp.blogspot.com/-0AXVXIR1sl4/XFBvt98sUwI/AAAAAAAAF_E/y97neGl-mYc3h27l-2aMJH9pXJiEYkq_wCLcBGAs/s320/Result%2B-%2B700.png)
