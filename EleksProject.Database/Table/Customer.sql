CREATE TABLE [dbo].[Customer]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerName] varchar(30) not null,
	[ContactEmail] varchar(25) not null,
	[MobileNo] varchar(10) not null
)
