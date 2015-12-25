	USE Gallery

	IF OBJECT_ID(N'dbo.Comment', N'U')IS NOT NULL
	DROP TABLE dbo.[Comment];

	IF OBJECT_ID(N'dbo.Image', N'U')IS NOT NULL
	DROP TABLE dbo.[Image];


	CREATE TABLE [Image] (	[ID] INT IDENTITY(1,1) NOT NULL  PRIMARY KEY,
							[CreateTS] DATETIME NOT NULL,
							[BaseName] VARCHAR(255) NOT NULL,
							[UUIDName] VARCHAR(255) NOT NULL,
							[FileSize] INT NOT NULL,
							[Rating] INT NOT NULL
                      );

	CREATE TABLE [Comment] ([ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
							[CreateTS] DATETIME NOT NULL,
							[Imgtext] VARCHAR(255),
							[ImageSize] INT NOT NULL,
							[ImageID] INT FOREIGN KEY REFERENCES [Image]([ID])
                     );