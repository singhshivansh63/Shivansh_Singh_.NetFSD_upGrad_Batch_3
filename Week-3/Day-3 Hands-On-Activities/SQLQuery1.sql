CREATE DATABASE StoreDb;
USE StoreDb;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1001,1),
    customer_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    order_status INT NOT NULL,

    CONSTRAINT FK_orders_customer
    FOREIGN KEY (customer_id)
    REFERENCES customers(customer_id)
);

INSERT INTO customers (first_name, last_name, email)
VALUES
('Rahul','Sharma','rahul@mail.com'),
('Anita','Verma','anita@mail.com'),
('John','Doe','john@mail.com');

INSERT INTO orders (customer_id, order_date, order_status)
VALUES
(1, '2026-03-01', 1),   -- Pending
(2, '2026-03-02', 4),   -- Completed
(3, '2026-03-03', 2),   -- Shipped
(1, '2026-03-04', 4),   -- Completed
(2, '2026-03-05', 1);   -- Pending

SELECT * FROM customers;
SELECT * FROM orders;

SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o
    ON c.customer_id = o.customer_id
WHERE o.order_status IN (1,4)
ORDER BY o.order_date DESC;