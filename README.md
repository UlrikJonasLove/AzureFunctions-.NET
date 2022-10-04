# Azure Functions with ASP.NET Core 

### Create new Table in Sql Management Studio
CREATE TABLE[dbo].[Customers](

   [Id][nvarchar](450) NOT NULL,

  [Name] [nvarchar](max)NOT NULL,
	[Address] [nvarchar](max)NOT NULL,
	[Phone] [nvarchar](max)NOT NULL,
	[Email] [nvarchar](max)NOT NULL,
    [Age] [nvarchar](max)NOT NULL,
 CONSTRAINT[PK_SalesRequests] PRIMARY KEY CLUSTERED
(

   [Id] ASC
))