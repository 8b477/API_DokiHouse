﻿CREATE TABLE [dbo].[PictureProfil]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Avatar] VARCHAR(MAX) NOT NULL,
	[CreateAt] DATETIME NOT NULL,
	[ModifiedAt] DATETIME,
	[IdUser] INT NOT NULL
	FOREIGN KEY (IdUser) REFERENCES [User](Id)
)
