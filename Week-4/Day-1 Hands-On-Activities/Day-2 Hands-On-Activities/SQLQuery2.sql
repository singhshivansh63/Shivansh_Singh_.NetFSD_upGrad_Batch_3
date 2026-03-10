 USE AutoRetailDB;

DECLARE @OrderID INT = 101;

BEGIN TRANSACTION

BEGIN TRY

    SAVE TRANSACTION RestoreStockPoint;

    -- Restore stock
    UPDATE p
    SET p.StockQty = p.StockQty + oi.Quantity
    FROM Products p
    JOIN Order_Items oi
    ON p.ProductID = oi.ProductID
    WHERE oi.OrderID = @OrderID;

    -- Update order status to Rejected
    UPDATE Orders
    SET OrderStatus = 3
    WHERE OrderID = @OrderID;

    COMMIT;

    PRINT 'Order cancelled successfully';

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION RestoreStockPoint;

    PRINT ERROR_MESSAGE();

    ROLLBACK;

END CATCH;

SELECT * FROM Orders;
SELECT * FROM Products;
SELECT * FROM Order_Items;
 