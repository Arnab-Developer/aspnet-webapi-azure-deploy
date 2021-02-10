# ASP.NET web api azure deploy

![build test deploy](https://github.com/Arnab-Developer/aspnet-webapi-azure-deploy/workflows/build%20test%20deploy/badge.svg)

Deploy ASP.NET web api to azure web app with GitHub action.

Steps:

- Create a new solution with two new apis and a web app.
- Create some tests.
- Push to GitHub.
- Create three new web apps in Azure for two apis and a web app.
- Download the publish profiles from Azure web app.
- Store the publish profile's content to GitHub repository secrets.
- Create workflows with GitHub action to build, test and deploy.

```
- name: 'Deploy to Azure WebApp'
  uses: azure/webapps-deploy@v2
  with:
    app-name: ${{ env.AZURE_WEBAPP_NAME }}
    publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
    package: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}/myapp
```

## Tech stack

* .NET 5
* C# 9
* xUnit for unit testing
* Visual Studio 2019

## Contribution

If you want to contribute in this repo then create an issue and let me know how you want to contribute.
