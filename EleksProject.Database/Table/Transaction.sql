CREATE TABLE [dbo].[Transaction]
(
	[TransactionId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[TransactionDate] datetime not null,
	[Amount] DECIMAL(18, 2) not null,
	[CurrencyCode] varchar(5) not null,
	[Status] varchar(10) not null,
	[CustomerId] int foreign key (CustomerId) References Customer (CustomerId) on delete cascade
)
