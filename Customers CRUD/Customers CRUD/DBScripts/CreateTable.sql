	USE Customers

	IF OBJECT_ID(N'dbo.User', N'U')IS NOT NULL
	DROP TABLE dbo.[User];

	IF OBJECT_ID(N'dbo.City', N'U')IS NOT NULL
	DROP TABLE dbo.[City];

	CREATE TABLE [City] (	[ID] INT IDENTITY(1,1) NOT NULL  PRIMARY KEY,
							[Name] VARCHAR(255) NOT NULL
                      );

	CREATE TABLE [User] (	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
							[Name] VARCHAR(255) NOT NULL,
							[Email] VARCHAR(255) NOT NULL,
							[Adress] VARCHAR(255) NOT NULL,
							[CityID] INT FOREIGN KEY REFERENCES City(ID),
							[Country] VARCHAR(255)
                     );