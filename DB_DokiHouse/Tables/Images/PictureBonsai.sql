CREATE TABLE [dbo].[PictureBonsai]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Picture] VARBINARY(MAX) NOT NULL,
	[IdBonsai] INT NOT NULL
	FOREIGN KEY (IdBonsai) REFERENCES [Bonsai](Id)
)
