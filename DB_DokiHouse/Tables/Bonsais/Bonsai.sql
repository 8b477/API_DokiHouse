﻿CREATE TABLE [dbo].[Bonsai]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(MAX),
	[CreateAt] DATETIME NOT NULL,
	[ModifiedAt] DATETIME,
	[IdUser] INT NOT NULL
	FOREIGN KEY (IdUser) REFERENCES [User](Id),
	[IdPicture] 
	INT FOREIGN KEY (IdPicture) REFERENCES [PictureBonsai](Id)
)
