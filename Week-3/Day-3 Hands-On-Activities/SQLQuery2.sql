 CREATE DATABASE SalesDb;
 USE SalesDb;

 CREATE TABLE brands (
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(100) NOT NULL
);

CREATE TABLE categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100) NOT NULL,
    brand_id INT NOT NULL,
    category_id INT NOT NULL,
    model_year INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100) NOT NULL
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1001,1),
    store_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    order_status INT NOT NULL,

    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,
    discount DECIMAL(4,2) NOT NULL,

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE stocks (
    store_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,

    PRIMARY KEY (store_id, product_id),

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks (store_id, product_id, quantity)
VALUES
(1, 1, 20),
(1, 2, 15),
(1, 3, 10),
(2, 1, 12),
(2, 3, 8),
(2, 4, 25);

INSERT INTO brands (brand_name) VALUES
('Nike'),
('Adidas'),
('Apple');

INSERT INTO categories (category_name) VALUES
('Shoes'),
('Electronics'),
('Clothing');

INSERT INTO products (product_name, brand_id, category_id, model_year, list_price)
VALUES
('Running Shoes', 1, 1, 2025, 600),
('Football Shoes', 2, 1, 2024, 450),
('iPhone 15', 3, 2, 2025, 1200),
('T-Shirt', 2, 3, 2025, 300);

INSERT INTO stores (store_name) VALUES
('Mumbai Store'),
('Delhi Store');

INSERT INTO orders (store_id, order_date, order_status)
VALUES
(1, '2026-03-01', 4),
(2, '2026-03-02', 4),
(1, '2026-03-03', 1);

INSERT INTO order_items (order_id, product_id, quantity, list_price, discount)
VALUES
(1001, 1, 2, 600, 0.10),
(1001, 3, 1, 1200, 0.05),
(1002, 3, 1, 1200, 0.15),
(1003, 4, 3, 300, 0.00);

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
    ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;

SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o 
    ON s.store_id = o.store_id
INNER JOIN order_items oi 
    ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;