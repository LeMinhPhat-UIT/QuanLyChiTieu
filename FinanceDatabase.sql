CREATE DATABASE IT008_Project
GO

SET DATEFORMAT MDY

USE IT008_Project

CREATE TABLE [Wallet] (
    ID INT PRIMARY KEY IDENTITY(1,1), 
    WalletName NVARCHAR(100) NOT NULL, 
    WalletType NVARCHAR(50) NOT NULL, 
    Money DECIMAL(18,2) NOT NULL DEFAULT 0,
    UpdateDate DATE NOT NULL DEFAULT GETDATE() 
);


CREATE TABLE [Transaction] (
    ID INT PRIMARY KEY IDENTITY(1,1), 
    TransactionName NVARCHAR(100) NOT NULL, 
    Money DECIMAL(18,2) NOT NULL, 
    TransactionMoneyFlow NVARCHAR(50) NOT NULL, 
    TransactionCatalog NVARCHAR(50),
    WalletID NVARCHAR(50), 
    TransactionDate DATE NOT NULL, 
);

CREATE TABLE [Catalog](
	CatalogMoneyFlow NVARCHAR(10),
	CatalogName NVARCHAR(20),
);

INSERT INTO [Catalog] (CatalogMoneyFlow, CatalogName)
VALUES
	(N'Chi tiêu', N'Mua sắm'), (N'Chi tiêu', N'Đồ ăn'),	(N'Chi tiêu', N'Điện thoại'),
	(N'Chi tiêu', N'Giải trí'),	(N'Chi tiêu', N'Giáo dục'),	(N'Chi tiêu', N'Sắc đẹp'),
	(N'Chi tiêu', N'Thẻ thao'),	(N'Chi tiêu', N'Xã hội'), (N'Chi tiêu', N'Vận tải'),
	(N'Chi tiêu', N'Quần áo'),	(N'Chi tiêu', N'Xe hơi'), (N'Chi tiêu', N'Rượu'),
	(N'Chi tiêu', N'Thuốc lá'),	(N'Chi tiêu', N'Thiết bị điện tử'),	(N'Chi tiêu', N'Du lịch'),
	(N'Chi tiêu', N'Sức khỏe'),	(N'Chi tiêu', N'Thú cưng'),	(N'Chi tiêu', N'Sửa chữa'),
	(N'Chi tiêu', N'Nhà ở'), (N'Chi tiêu', N'Nhà'),	(N'Chi tiêu', N'Quà tặng'),
	(N'Chi tiêu', N'Quyên góp'), (N'Chi tiêu', N'Vé số'), (N'Chi tiêu', N'Đồ ăn nhẹ'),
	(N'Chi tiêu', N'Trẻ em'), (N'Chi tiêu', N'Rau quả'), (N'Chi tiêu', N'Hoa quả'),
	(N'Thu nhập', N'Lương'), (N'Thu nhập', N'Khoản đầu tư'), (N'Thu nhập', N'Bán thời gian'),
	(N'Thu nhập', N'Giải thưởng');