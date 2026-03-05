 CREATE DATABASE OrderMaintenanceDB;
 USE OrderMaintenanceDB;

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
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE
);

INSERT INTO customers (first_name,last_name,email)
VALUES
('John','Smith','john@gmail.com'),
('Alice','Brown','alice@gmail.com'),
('David','Miller','david@gmail.com'),
('Emma','Wilson','emma@gmail.com');

INSERT INTO orders (customer_id,order_status,order_date,required_date,shipped_date)
VALUES
(1,2,'2023-01-10','2023-01-15','2023-01-14'),
(2,1,'2023-02-05','2023-02-10','2023-02-11'),
(3,3,'2022-01-12','2022-01-18','2022-01-20'),
(1,2,'2023-03-20','2023-03-25','2023-03-24'),
(4,3,'2021-12-01','2021-12-05','2021-12-10');

INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
SELECT COUNT(*)
FROM orders o2
WHERE o2.customer_id = orders.customer_id
AND o2.order_status = 2
);

SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY,order_date,shipped_date) AS processing_delay
FROM orders;

SELECT
order_id,
order_date,
required_date,
shipped_date,

CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS delivery_status

FROM orders;