﻿CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Content] VARCHAR(MAX) NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[ModifiedAt] DATETIME NOT NULL,
	[IdUser] INT NOT NULL,
	[IdPost] INT NOT NULL
	FOREIGN KEY (IdPost) REFERENCES [Post](Id)
	FOREIGN KEY (IdUser) REFERENCES [User](Id)
)
