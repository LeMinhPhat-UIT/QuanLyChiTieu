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
    WalletID INT NOT NULL, 
    CONSTRAINT FK_Transaction_Wallet FOREIGN KEY (WalletID) REFERENCES Wallet(ID) ON DELETE CASCADE
);
