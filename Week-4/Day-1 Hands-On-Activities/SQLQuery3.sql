CREATE DATABASE SalesManagementDB;
USE SalesManagementDB;

CREATE TABLE orders
(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_name VARCHAR(100),
    order_date DATE,
    shipped_date DATE NULL,
    order_status INT
);

INSERT INTO orders (customer_name, order_date, shipped_date, order_status)
VALUES
('John', '2024-01-10', NULL, 1),
('Alice', '2024-01-11', '2024-01-12', 3),
('David', '2024-01-12', NULL, 2);

CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        
        -- Validation Check
        IF EXISTS
        (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            THROW 50001, 'Cannot set order status to Completed without shipped_date.', 1;
        END

    END TRY

    BEGIN CATCH

        PRINT 'Error occurred while updating order status';

        ROLLBACK TRANSACTION;

    END CATCH
END;
GO

UPDATE orders
SET shipped_date = '2024-01-15',
    order_status = 4
WHERE order_id = 1;