﻿CREATE TABLE [dbo].[Note]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(MAX) NOT NULL,
	[CreateAt] DATETIME NOT NULL,
	[ModifiedAt] DATETIME,
	[IdBonsai] INT NOT NULL,
	FOREIGN KEY(IdBonsai) REFERENCES [Bonsai](Id)
)
