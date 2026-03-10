CREATE DATABASE AutoRetailDB;
USE AutoRetailDB;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    StockQty INT
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Order_Items (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Products VALUES
(1,'Car Tyre',50),
(2,'Car Battery',30),
(3,'Brake Pad',20);

SELECT * FROM Products;

CREATE TRIGGER trg_ReduceStock
ON Order_Items
AFTER INSERT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM Products p
        JOIN inserted i
        ON p.ProductID = i.ProductID
        WHERE p.StockQty < i.Quantity
    )
    BEGIN
        RAISERROR('Insufficient Stock',16,1)
        ROLLBACK TRANSACTION
        RETURN
    END

    UPDATE p
    SET p.StockQty = p.StockQty - i.Quantity
    FROM Products p
    JOIN inserted i
    ON p.ProductID = i.ProductID

END

BEGIN TRANSACTION

BEGIN TRY

    -- Insert Order
    INSERT INTO Orders(OrderID)
    VALUES (101)

    -- Insert Order Items
    INSERT INTO Order_Items(OrderID, ProductID, Quantity)
    VALUES
    (101,1,5),
    (101,2,10)

    COMMIT

    PRINT 'Order placed successfully'

END TRY

BEGIN CATCH

    ROLLBACK

    PRINT 'Order failed: ' + ERROR_MESSAGE()

END CATCH

SELECT * FROM Products;

SELECT * FROM Orders;

SELECT * FROM Order_Items;

BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Orders(OrderID)
VALUES (102)

INSERT INTO Order_Items(OrderID, ProductID, Quantity)
VALUES
(102,3,50)

COMMIT

END TRY

BEGIN CATCH

ROLLBACK

PRINT ERROR_MESSAGE()

END CATCH