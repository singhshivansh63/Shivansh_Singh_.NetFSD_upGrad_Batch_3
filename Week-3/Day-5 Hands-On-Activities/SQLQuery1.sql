CREATE DATABASE EcommDb;
USE EcommDb;

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    email VARCHAR(100)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

INSERT INTO categories VALUES
(1,'Bikes'),
(2,'Scooters'),
(3,'Electric Bikes'),
(4,'Accessories'),
(5,'Spare Parts');

INSERT INTO brands VALUES
(1,'Honda'),
(2,'Yamaha'),
(3,'Suzuki'),
(4,'Hero'),
(5,'TVS');

INSERT INTO products VALUES
(1,'Honda Shine',1,1,2023,80000),
(2,'Yamaha R15',2,1,2024,150000),
(3,'Suzuki Access',3,2,2023,90000),
(4,'Hero Electric Optima',4,3,2024,120000),
(5,'TVS Jupiter',5,2,2023,85000);

INSERT INTO customers VALUES
(1,'Rahul','Sharma','Delhi','rahul@gmail.com'),
(2,'Amit','Verma','Lucknow','amit@gmail.com'),
(3,'Priya','Singh','Delhi','priya@gmail.com'),
(4,'Neha','Gupta','Mumbai','neha@gmail.com'),
(5,'Rohan','Mehta','Lucknow','rohan@gmail.com');

INSERT INTO stores VALUES
(1,'Auto World','Delhi'),
(2,'Bike Hub','Lucknow'),
(3,'Speed Motors','Mumbai'),
(4,'Super Wheels','Pune'),
(5,'City Bikes','Bangalore');

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

SELECT *
FROM customers
WHERE city = 'Lucknow';

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

