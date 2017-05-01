# Azure App Service Walkthrough

## Abstract

This is a walktrough of the Azure App Service features.

## What you'll need

TODO

## Get the code

Open a command window and navigate to a folder of your choice.

Now clone this repository:

```
git clone https://github.com/neaorin/AppServiceWalkthrough.git
```

Navigate to the `AppServiceWalkthrough` folder.

```
cd AppServiceWalkthrough
```

Now open Visual Studio, and open the `src\initial\MercuryHealth.sln` solution file. Build the solution.

## (Optional) Test the application locally

In order to test the web application locally, the first step is to deploy the database.

You will need to have SQL Server up and running, either on your local machine or on a remote server. 

I would say that today the two easiest ways to get SQL Server running locally is to either 
a) [use Docker](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup-docker), or 
b) [use LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb).

Your user also needs to have the rights to create new databases on the SQL Server.


**Next Step**: [Deploy the application to Microsoft Azure](DeployToAzure.md)

[Back to Index](Readme.md)