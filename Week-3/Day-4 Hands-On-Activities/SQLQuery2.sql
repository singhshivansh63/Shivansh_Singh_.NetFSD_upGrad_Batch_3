 CREATE DATABASE AutoDb;
 USE AutoDb;

 CREATE TABLE categories
(
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100) NOT NULL
);

CREATE TABLE products
(
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(200) NOT NULL,
    model_year INT,
    list_price DECIMAL(10,2),
    category_id INT,
    
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO categories (category_name)
VALUES
('Mountain Bikes'),
('Road Bikes'),
('Electric Bikes'),
('Kids Bikes');

INSERT INTO products (product_name, model_year, list_price, category_id)
VALUES
('Trek Marlin 7', 2017, 1200, 1),
('Specialized Rockhopper', 2018, 900, 1),
('Giant Talon', 2019, 800, 1),

('Trek Domane SL6', 2018, 3200, 2),
('Specialized Roubaix', 2017, 4500, 2),
('Giant Defy Advanced', 2019, 2800, 2),

('Trek Allant+ 7', 2020, 3600, 3),
('Specialized Turbo Vado', 2021, 4000, 3),

('Kids Supercycle', 2017, 250, 4),
('Little Rider', 2018, 300, 4);

SELECT 
    p.product_name + ' (' + CAST(p.model_year AS VARCHAR) + ')' AS Product_Details,
    p.list_price,
    
    (SELECT AVG(p2.list_price)
     FROM products p2
     WHERE p2.category_id = p.category_id) AS Category_Avg_Price,
     
    p.list_price -
    (SELECT AVG(p2.list_price)
     FROM products p2
     WHERE p2.category_id = p.category_id) AS Price_Difference

FROM products p
WHERE p.list_price >
      (SELECT AVG(p2.list_price)
       FROM products p2
       WHERE p2.category_id = p.category_id);