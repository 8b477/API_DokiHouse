CREATE TABLE [dbo].[Bonsai]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(MAX),
	[IdUser] INT 
	FOREIGN KEY (IdUser) REFERENCES [User](Id),
	[IdPicture] 
	INT FOREIGN KEY (IdPicture) REFERENCES [PictureBonsai](Id)
	
)
