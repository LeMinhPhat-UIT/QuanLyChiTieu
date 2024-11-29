CREATE DATABASE IT008_Project
GO

USE IT008_Project

CREATE TABLE Wallet (
    ID INT PRIMARY KEY IDENTITY(1,1), 
    WalletName NVARCHAR(100) NOT NULL, 
    WalletType NVARCHAR(50) NOT NULL, 
    Money DECIMAL(18,2) NOT NULL DEFAULT 0,
    UpdateDate DATETIME NOT NULL DEFAULT GETDATE() 
);


CREATE TABLE [Transaction] (
    ID INT PRIMARY KEY IDENTITY(1,1), 
    TransactionName NVARCHAR(100) NOT NULL, 
    Money DECIMAL(18,2) NOT NULL, 
    TransactionMoneyFlow NVARCHAR(50) NOT NULL, 
    TransactionCatalog NVARCHAR(50),
    TransactionBudgetService NVARCHAR(50), 
    TransactionDate DATETIME NOT NULL, 
);

Insert into Wallet(WalletName, WalletType, Money, UpdateDate)
Values
	('Wallet 1', 'Cash', 100, '2005-05-23'),
	('Wallet 2', 'Cash', 100, '2005-10-19');