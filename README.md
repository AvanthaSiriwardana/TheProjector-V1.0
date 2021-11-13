# Getting Started .NET Core Web API with React

This is a simple application done with Microsoft .NET Core 3.1 & React.

## It has below applications;

1. .net core web api
  - TheProjector.API --> This contains the web api 
  - TheProjector.Services --> Interfaces to call repositories/ response codes / requests objects 
  - TheProjector.Repository --> This is implemented using repository patter with UOW
  - TheProjector.Domain --> Domain objects & EF core migration 
  - TestProject.UnitTests --> Not completed. Need to add test cases. This contains test collection for some of the web api calls in postman.
  -
2. React application
  - theprojector.ux --> NOT the best UI. Just to check the functionalities and behavior. We can update the UI later with remaining functionalities.

3. Setup Database Migration:
  - Go to "Package Manager Console" and select the Default Project "TheProjector.Domain"
  - Run the command add-migration and give a name if you like. I gave it as "TheProjectorInitialMigrationV10"
  - Run the command update-database
  - Go to SQL Serve and verify the database with the name "TheProjector"
  - Verify the tables and seeded data.

![image](https://user-images.githubusercontent.com/48938732/141614879-88be12e7-a220-4d9a-b5ab-77a45090fd7d.png)

4. To run the **React** application: 

  - Go to theprojector.ux\src and execute below command in command prompt to launch the reach application. 

### `npm start`

## Prerequisites 
  - SQL Server -> I used SQL Server 2014 
  - .Net Core 3.1.0 or above
  - Node.js --> My version is Node.js v16.10.0.
