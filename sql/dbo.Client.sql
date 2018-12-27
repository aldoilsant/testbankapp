CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[FirstName] VARCHAR(100) NOT NULL,
	[LastName] VARCHAR(100) NOT NULL,
	[UserName] VARCHAR(100) NOT NULL UNIQUE,
	[Password] BINARY(64) NOT NULL,
	[Country] CHAR(2),
	[Region] VARCHAR(100),
	[City] VARCHAR(100),
	[Address] VARCHAR(100)
)