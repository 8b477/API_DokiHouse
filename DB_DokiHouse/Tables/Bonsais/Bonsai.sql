﻿CREATE TABLE [dbo].[Bonsai]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(MAX),
	[UserId] INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](Id)
)
