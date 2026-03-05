 CREATE DATABASE StorePerformanceDB;
 USE StorePerformanceDB;

 CREATE TABLE stores
(
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100),
    city VARCHAR(100)
);

CREATE TABLE products
(
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(150),
    list_price DECIMAL(10,2)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_date DATE,

    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);


CREATE TABLE order_items
(
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(10,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,

    PRIMARY KEY (store_id, product_id),

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stores (store_name, city)
VALUES
('Central Store','New York'),
('City Mall Store','Chicago'),
('Downtown Store','Los Angeles');

INSERT INTO products (product_name, list_price)
VALUES
('Mountain Bike',1200),
('Road Bike',1500),
('Electric Bike',2500),
('Kids Bike',300);

INSERT INTO orders (store_id, order_date)
VALUES
(1,'2023-01-10'),
(2,'2023-02-12'),
(1,'2023-03-05'),
(3,'2023-04-15');

INSERT INTO order_items (order_id, product_id, quantity, list_price, discount)
VALUES
(1,1,2,1200,100),
(1,2,1,1500,50),
(2,3,1,2500,200),
(3,1,1,1200,0),
(4,4,3,300,20);

INSERT INTO stocks (store_id, product_id, quantity)
VALUES
(1,1,5),
(1,2,0),
(2,3,2),
(3,4,0);

SELECT 
    S.store_name,
    P.product_name,
    SUM(OI.quantity) AS total_quantity_sold,
    SUM((OI.quantity * OI.list_price) - OI.discount) AS total_revenue
FROM orders O
JOIN order_items OI
ON O.order_id = OI.order_id
JOIN stores S
ON O.store_id = S.store_id
JOIN products P
ON OI.product_id = P.product_id
GROUP BY S.store_name, P.product_name;