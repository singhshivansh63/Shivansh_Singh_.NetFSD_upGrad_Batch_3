CREATE DATABASE InventoryDB;
USE InventoryDB;

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);

CREATE TABLE stocks
(
    product_id INT PRIMARY KEY,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    product_id INT,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO products VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Keyboard');

INSERT INTO stocks VALUES
(1,50),
(2,30),
(3,20);

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY
        
        
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN stocks s ON i.product_id = s.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock available for this product.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id;

    END TRY

    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage,16,1);
        ROLLBACK TRANSACTION;
    END CATCH
END;

INSERT INTO order_items VALUES (1,1,5);
INSERT INTO order_items VALUES (2,1,100);

SELECT * FROM stocks;