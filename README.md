# TestMVC
Thanks for taking the time to check out this simple .NET Core MVC application.<br /><br />

 It's mostly just a standard MVC template with some minor tweaks at this point.<br />

 The main thing that sets this apart from a standard MVC application is that it utilizes a REST API as its backend.<br />
 You can view and interact with the swagger docs for the API <a href="https://swcoretestapi.azurewebsites.net/swagger/index.html" target="_blank">here</a>.<br />
 And the GitHub code repository for the API can be found <a href="https://github.com/MyPiTech/DotNetCoreTestApi" target="_blank">here</a>.<br /><br />

 From a development perspective, I would like to draw attention to the generic 
 <a href="https://github.com/MyPiTech/TestMVC/blob/master/TestMVC/Services/ApiService.cs" target="_blank">ApiService</a> class, 
 the <a href="https://github.com/MyPiTech/TestMVC/tree/master/TestMVC/Attributes" target="_blank">ApiKey and ApiRoute</a> custom attributes,
 and the way they are used in the corresponding DTOs (<a href="https://github.com/MyPiTech/TestMVC/tree/master/TestMVC/Dtos" target="_blank">users, and events</a>). 
 This is a very simplified implementation of a pattern I developed for a previous employer. 
 As you can see, by using generics and a little magical reflection, you can tie the DTOs to their respective endpoints. 
 This allows for a very simple and versatile implementation for new API endpoints. 
 Particularly for less experienced developers.<br /><br />

 I have not currently added any ability to add, update, or delete anything from the API. 
 Though I have stubbed out some of it. 
 However, you can view all the users and events in the API's database by going to the <a asp-action="index" asp-controller="users">Users</a> page (or use the tab in the menu). 
 Clicking on any user will take you to a page showing their events.<br /><br />

 Thanks again, <br />
 Shawn
