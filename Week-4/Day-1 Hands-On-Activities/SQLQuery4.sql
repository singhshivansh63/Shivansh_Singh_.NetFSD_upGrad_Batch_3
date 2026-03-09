 CREATE DATABASE RetailDB;
 USE RetailDB;

 CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY,
    order_id INT,
    product_name VARCHAR(100),
    quantity INT,
    price DECIMAL(10,2),
    discount DECIMAL(5,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

INSERT INTO stores VALUES
(1,'New York Store'),
(2,'Chicago Store');

INSERT INTO orders VALUES
(101,1,4,'2024-01-10'),
(102,1,4,'2024-01-11'),
(103,2,4,'2024-01-12'),
(104,2,2,'2024-01-13');

INSERT INTO order_items VALUES
(1,101,'Laptop',1,1000,10),
(2,101,'Mouse',2,50,5),
(3,102,'Keyboard',1,200,20),
(4,103,'Monitor',2,300,15),
(5,104,'Printer',1,400,10);

CREATE TABLE #RevenueTemp
(
    store_id INT,
    order_id INT,
    revenue DECIMAL(12,2)
);

BEGIN TRY

BEGIN TRANSACTION;

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

DECLARE order_cursor CURSOR FOR

SELECT order_id, store_id
FROM orders
WHERE order_status = 4;

OPEN order_cursor;

FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate Revenue for each order
    SELECT @revenue = SUM((price * quantity) - discount)
    FROM order_items
    WHERE order_id = @order_id;

    -- Handle NULL
    IF @revenue IS NULL
        SET @revenue = 0;

    INSERT INTO #RevenueTemp
    VALUES(@store_id,@order_id,@revenue);

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

END

CLOSE order_cursor;
DEALLOCATE order_cursor;

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    PRINT 'Error occurred during revenue calculation';

    ROLLBACK TRANSACTION;

END CATCH;

SELECT 
    s.store_name,
    SUM(r.revenue) AS Total_Revenue
FROM #RevenueTemp r
JOIN stores s
ON r.store_id = s.store_id
GROUP BY s.store_name;

