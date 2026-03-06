USE EcommDb;

CREATE VIEW vw_ProductDetails
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    order_date DATE,
    order_status INT,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE staffs (
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    store_id INT,

    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO staffs VALUES
(1,'Rahul','Verma',1),
(2,'Amit','Singh',2),
(3,'Neha','Sharma',3);

INSERT INTO orders VALUES
(101,1,1,'2024-01-10',1),
(102,2,2,'2024-01-11',4),
(103,3,1,'2024-01-12',4),
(104,4,3,'2024-01-13',1),
(105,5,2,'2024-01-14',4);



CREATE VIEW vw_OrderSummary
AS
SELECT 
o.order_id,
o.order_date,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name
FROM orders o
INNER JOIN customers c
ON o.customer_id = c.customer_id
INNER JOIN stores s
ON o.store_id = s.store_id;

SELECT * FROM vw_OrderSummary;