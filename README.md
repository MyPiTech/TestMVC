# TestMVC
Thanks for taking the time to check out this simple .NET Core MVC application.
It's mostly just a standard MVC template with some minor tweaks at this point.<br />

 The main thing that sets this apart from a standard MVC application is that it utilizes a REST API as its backend.<br />
 You can view and interact with the swagger docs for the API <a href="https://swcoretestapi.azurewebsites.net/swagger/index.html">here</a>.<br />
 And the GitHub code repository for the API can be found <a href="https://github.com/MyPiTech/DotNetCoreTestApi">here</a>.<br />

 From a development perspective, I would like to draw attention to the generic 
 <a href="https://github.com/MyPiTech/TestMVC/blob/master/TestMVC/Services/ApiService.cs">ApiService</a> class, 
 the <a href="https://github.com/MyPiTech/TestMVC/tree/master/TestMVC/Attributes">ApiKey and ApiRoute</a> custom attributes,
 and the way they are used in the corresponding DTOs (<a href="https://github.com/MyPiTech/TestMVC/tree/master/TestMVC/Dtos">users, and events</a>). 
 This is a very simplified implementation of a pattern I developed for a previous employer. 
 As you can see, by using generics and a little magical reflection, you can tie the DTOs to their respective endpoints. 
 This allows for a very simple and versatile implementation for new API endpoints. 
 Particularly for less experienced developers.<br />

 I have not currently added any ability to add, update, or delete anything from the API. 
 Though I have stubbed out some of it. 
 However, you can view all the users and events in the API's database by going to the <a href="https://mssimpletestmvc.azurewebsites.net/Users">Users</a> page. 
 Clicking on any user will take you to a page showing their events.<br />
