CREATE DATABASE BookMartDB;
USE BookMartDB;

CREATE TABLE Books (
BookID INT IDENTITY(1,1) PRIMARY KEY,
Title NVARCHAR(150) NOT NULL,
Stock INT NOT NULL CHECK (Stock >= 0),
Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
OrderID INT IDENTITY(1,1) PRIMARY KEY,
BookID INT NOT NULL,
Quantity INT NOT NULL CHECK (Quantity > 0),
OrderDate DATETIME2 DEFAULT SYSDATETIME(),
FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

--Create a Procedure For Adding a New Book--
CREATE PROCEDURE sp_AddNewBook
@Title NVARCHAR(150),
@Stock INT,
@Price DECIMAL(10,2)

AS
BEGIN

BEGIN TRY

INSERT INTO Books (Title, Stock, Price)

VALUES (@Title, @Stock, @Price);

PRINT 'Book added successfully.';

END TRY

BEGIN CATCH

PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR)
+ ': ' + ERROR_MESSAGE();

END CATCH

END;

-- Create a Procedure For Placing Order or Handling Transactions--
CREATE PROCEDURE sp_PlaceOrder

@BookID INT,
@Quantity INT

AS
BEGIN

SET XACT_ABORT ON;
BEGIN TRY

BEGIN TRANSACTION;

IF NOT EXISTS
(
SELECT 1
FROM Books
WHERE BookID = @BookID
AND Stock >= @Quantity
)

BEGIN

RAISERROR('Not enough stock or book not found.',16,1);

END

UPDATE Books

SET Stock = Stock - @Quantity

WHERE BookID = @BookID;

INSERT INTO Orders (BookID, Quantity)

VALUES (@BookID, @Quantity);

COMMIT TRANSACTION;

PRINT 'Order placed successfully.';

END TRY

BEGIN CATCH

IF @@TRANCOUNT > 0
ROLLBACK TRANSACTION;

PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR)
+ ': ' + ERROR_MESSAGE();

END CATCH

END;

--Adding a raw Book Data--
EXEC sp_AddNewBook 'Database Systems', 10, 500;
EXEC sp_AddNewBook 'Learning SQL', 5, 350;
EXEC sp_AddNewBook 'C# Programming', 7, 600;
EXEC sp_AddNewBook 'JavaScript Guide', 8, 450;
EXEC sp_AddNewBook 'Web Development', 12, 550;

--Different Cases Senerios--
EXEC sp_PlaceOrder 1,5; 
EXEC sp_PlaceOrder 2,10;
EXEC sp_PlaceOrder 100,1;

SELECT * FROM Books;

SELECT * FROM Orders;

 