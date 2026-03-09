CREATE DATABASE SalesDB1;
USE SalesDB1;

CREATE TABLE Stores
(
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(100),
    Location VARCHAR(100)
);

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2)
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    StoreID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10,2),

    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID)
);

CREATE TABLE OrderDetails
(
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(10,2),

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Stores VALUES
(1,'Central Store','Delhi'),
(2,'City Store','Mumbai'),
(3,'Mall Store','Bangalore');

INSERT INTO Products VALUES
(101,'Laptop',50000),
(102,'Mobile',20000),
(103,'Headphones',3000),
(104,'Keyboard',1500),
(105,'Mouse',800);

INSERT INTO Orders VALUES
(1,1,'2024-01-10',55000),
(2,2,'2024-01-15',20000),
(3,1,'2024-02-01',3000),
(4,3,'2024-02-10',1500),
(5,2,'2024-03-05',800);

INSERT INTO OrderDetails VALUES
(1,1,101,1,50000),
(2,1,103,1,3000),
(3,2,102,1,20000),
(4,3,103,1,3000),
(5,4,104,1,1500),
(6,5,105,1,800);

CREATE PROCEDURE usp_GetTotalSalesPerStore
AS
BEGIN
    SELECT 
        s.StoreName,
        SUM(ISNULL(o.TotalAmount,0)) AS TotalSales
    FROM Orders o
    INNER JOIN Stores s
    ON o.StoreID = s.StoreID
    GROUP BY s.StoreName
END

EXEC usp_GetTotalSalesPerStore;

CREATE PROCEDURE usp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        OrderID,
        StoreID,
        OrderDate,
        TotalAmount
    FROM Orders
    WHERE OrderDate BETWEEN @StartDate AND @EndDate
END

EXEC usp_GetOrdersByDateRange '2024-01-01','2024-02-28';

CREATE FUNCTION fn_CalculateDiscountPrice
(
    @Price DECIMAL(10,2),
    @DiscountPercent DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @FinalPrice DECIMAL(10,2)

    SET @FinalPrice = @Price - (@Price * ISNULL(@DiscountPercent,0)/100)

    RETURN @FinalPrice
END

SELECT dbo.fn_CalculateDiscountPrice(10000,10) AS DiscountedPrice;


CREATE FUNCTION fn_GetTop5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.ProductName,
        SUM(ISNULL(od.Quantity,0)) AS TotalSold
    FROM OrderDetails od
    INNER JOIN Products p
    ON od.ProductID = p.ProductID
    GROUP BY p.ProductName
    ORDER BY TotalSold DESC
)

SELECT * FROM dbo.fn_GetTop5SellingProducts();