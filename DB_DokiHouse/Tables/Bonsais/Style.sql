﻿CREATE TABLE [dbo].[Style]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Bunjin BIT DEFAULT 0 NOT NULL,
	Bankan BIT DEFAULT 0 NOT NULL,
	Korabuki BIT DEFAULT 0 NOT NULL,
	Ishituki BIT DEFAULT 0 NOT NULL,
	[Perso] VARCHAR(150),
	[CreateAt] DATETIME NOT NULL,
	[ModifiedAt] DATETIME,
	[IdBonsai] INT NOT NULL
	FOREIGN KEY (IdBonsai) REFERENCES [Bonsai](Id)
)
