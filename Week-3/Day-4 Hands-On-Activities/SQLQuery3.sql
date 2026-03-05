 CREATE DATABASE AutoDb1;
 USE AutoDb1;

 CREATE TABLE customers
(
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_date DATE,
    
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_name VARCHAR(100),
    quantity INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

INSERT INTO customers (first_name, last_name, email)
VALUES
('John','Smith','john@gmail.com'),
('Alice','Brown','alice@gmail.com'),
('Michael','Johnson','michael@gmail.com'),
('Emma','Wilson','emma@gmail.com'),
('David','Miller','david@gmail.com');

INSERT INTO orders (customer_id, order_date)
VALUES
(1,'2023-01-10'),
(2,'2023-02-05'),
(3,'2023-03-12'),
(1,'2023-04-18');

INSERT INTO order_items (order_id, product_name, quantity, list_price)
VALUES
(1,'Laptop',1,8000),
(1,'Mouse',2,500),

(2,'Mobile Phone',1,12000),

(3,'Keyboard',2,1500),

(4,'Monitor',1,9000);

SELECT 
    C.first_name + ' ' + C.last_name AS Full_Name,
    T.total_order_value,
    CASE
        WHEN T.total_order_value > 10000 THEN 'Premium'
        WHEN T.total_order_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS Customer_Class
FROM customers C
JOIN
(
    SELECT O.customer_id,
           SUM(OI.quantity * OI.list_price) AS total_order_value
    FROM orders O
    JOIN order_items OI
    ON O.order_id = OI.order_id
    GROUP BY O.customer_id
) T
ON C.customer_id = T.customer_id

UNION

SELECT 
    C.first_name + ' ' + C.last_name,
    0,
    'Basic'
FROM customers C
WHERE C.customer_id NOT IN
(
    SELECT customer_id FROM orders
);