/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Customer]
           ([CustomerName]
           ,[ContactEmail]
           ,[MobileNo])
     VALUES
           ('Artem'
           ,'arty@mailinator.com'
           ,'1111111111')
GO

INSERT INTO [dbo].[Customer]
           ([CustomerName]
           ,[ContactEmail]
           ,[MobileNo])
     VALUES
           ('Peter Parker'
           ,'parker@mailinator.com'
           ,'1111111111')
GO

INSERT INTO [dbo].[Transaction]
           ([TransactionDate]
           ,[Amount]
           ,[CurrencyCode]
           ,[Status]
           ,[CustomerId])
     VALUES
           (getdate()
           ,1230.49
           ,'CAD'
           ,'Success'
           ,1)

GO

INSERT INTO [dbo].[Transaction]
           ([TransactionDate]
           ,[Amount]
           ,[CurrencyCode]
           ,[Status]
           ,[CustomerId])
     VALUES
           (getdate()
           ,35.49
           ,'USD'
           ,'Success'
           ,1)

GO

INSERT INTO [dbo].[Transaction]
           ([TransactionDate]
           ,[Amount]
           ,[CurrencyCode]
           ,[Status]
           ,[CustomerId])
     VALUES
           (getdate()
           ,30.439
           ,'CAD'
           ,'Success'
           ,1)

GO

INSERT INTO [dbo].[Transaction]
           ([TransactionDate]
           ,[Amount]
           ,[CurrencyCode]
           ,[Status]
           ,[CustomerId])
     VALUES
           (getdate()
           ,1230.439
           ,'CAD'
           ,'Success'
           ,2)