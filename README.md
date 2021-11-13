# Getting Started .net core web api with React

This is a simple application done with Microsoft .net core 3.1 & React.

## It has below applications;

1. .net core web api
  - TheProjector.API --> This contains the web api 
  - TheProjector.Services --> Interfaces to call repositories/ response codes / requests objects 
  - TheProjector.Repository --> This is implemented using repository patter with UOW
  - TheProjector.Domain --> Domain objects & EF core migration 
  - TestProject.UnitTests --> Not completed. Need to add test cases. This contains test collection for some of the web api calls in postman.
3. React application
  - theprojector.ux --> NOT the best UI. Just to check the functionalities and behavior. We can update the UI later with remaining functionalities.

In the project directory, you can run:

Go to theprojector.ux\src and execute below command in command prompt to launch the reach application. 

### `npm start`

## Prerequisites 
  - SQL Server -> I use SQL Server 2014 
  - .Net Core Framework 3.1.0 or above
  - Node.js --> My version is Node.js v16.10.0.
