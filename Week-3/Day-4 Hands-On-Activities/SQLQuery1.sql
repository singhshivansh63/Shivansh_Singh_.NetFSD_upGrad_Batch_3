 create database OnlineBookStore
 use OnlineBookStore
 
 CREATE TABLE Authors (
	author_id INT PRIMARY KEY IDENTITY(1, 1),
	author_name VARCHAR(100) NOT NULL,
	country VARCHAR(50)
);

CREATE TABLE Books (
	book_id INT   PRIMARY KEY IDENTITY(1, 1),
	title VARCHAR(200) NOT NULL,
	author_id INT FOREIGN KEY REFERENCES Authors(author_id),
	price DECIMAL(10, 2) NOT NULL,
	publication_year INT	
);

CREATE TABLE Customers (
	customer_id INT PRIMARY KEY IDENTITY(1, 1),
	customer_name VARCHAR(100) NOT NULL,
	email VARCHAR(100),
	join_date DATE
);

CREATE TABLE Orders (
	order_id INT PRIMARY KEY IDENTITY(1, 1),
	customer_id INT FOREIGN KEY REFERENCES Customers(customer_id),
	order_date DATE
);

CREATE TABLE Order_Details (
	order_detail_id INT PRIMARY KEY IDENTITY(1, 1),
	order_id INT FOREIGN KEY REFERENCES Orders(order_id),
	book_id INT FOREIGN KEY REFERENCES Books(book_id),
	quantity INT NOT NULL,
	subtotal DECIMAL(10, 2) NOT NULL
);

INSERT INTO Authors (author_name, country) VALUES
('J.K. Rowling', 'UK'),
('George R.R. Martin', 'USA'),
('Haruki Murakami', 'Japan');

INSERT INTO Books (title, author_id, price, publication_year)
VALUES
('Harry Potter and the Philosophers Stone', 1, 20.99, 1997),
('A Game of Thrones', 2, 25.99, 1996),
('Norwegian Wood', 3, 15.99, 1987);

INSERT INTO Customers (customer_name, email, join_date) VALUES
('Alice Johnson', 'alice@example.com', '2020-01-15'),
('Bob Smith', 'bob@example.com', '2019-05-20');

INSERT INTO Orders (customer_id, order_date) VALUES
(1, '2023-01-10'),
(2, '2023-02-15');

INSERT INTO Order_Details (order_id, book_id, quantity,
subtotal) VALUES
(1, 1, 2, 41.98),
(1, 3, 1, 15.99),
(2, 2, 1, 25.99);

SELECT 
    B.title AS Book_Title,
    A.author_name AS Author_Name,
    A.country AS Country
FROM Books B
JOIN Authors A
    ON B.author_id = A.author_id;

	SELECT 
    A.author_name,
    SUM(OD.subtotal) AS Total_Revenue
FROM Authors A
JOIN Books B 
    ON A.author_id = B.author_id
JOIN Order_Details OD 
    ON B.book_id = OD.book_id
GROUP BY A.author_name;

SELECT title, price
FROM Books
WHERE price = (SELECT MAX(price) FROM Books);

SELECT publication_year,
       AVG(price) AS average_price
FROM Books
GROUP BY publication_year;

SELECT C.customer_name,
       SUM(OD.subtotal) AS total_spent
FROM Customers C
JOIN Orders O
    ON C.customer_id = O.customer_id
JOIN Order_Details OD
    ON O.order_id = OD.order_id
GROUP BY C.customer_name;

SELECT B.title
FROM Books B
LEFT JOIN Order_Details OD
    ON B.book_id = OD.book_id
WHERE OD.book_id IS NULL;

SELECT TOP 1 C.customer_name,
       SUM(OD.subtotal) AS total_spent
FROM Customers C
JOIN Orders O
    ON C.customer_id = O.customer_id
JOIN Order_Details OD
    ON O.order_id = OD.order_id
GROUP BY C.customer_name
ORDER BY total_spent DESC;

SELECT A.author_name
FROM Authors A
LEFT JOIN Books B
    ON A.author_id = B.author_id
LEFT JOIN Order_Details OD
    ON B.book_id = OD.book_id
WHERE OD.book_id IS NULL;

SELECT A.author_name,
       SUM(OD.quantity) AS total_books_sold
FROM Authors A
JOIN Books B
    ON A.author_id = B.author_id
JOIN Order_Details OD
    ON B.book_id = OD.book_id
GROUP BY A.author_name;

SELECT C.customer_name,
       B.title,
       O.order_date,
       OD.quantity,
       OD.subtotal
FROM Orders O
JOIN Customers C
    ON O.customer_id = C.customer_id
JOIN Order_Details OD
    ON O.order_id = OD.order_id
JOIN Books B
    ON OD.book_id = B.book_id
WHERE O.order_date = (
    SELECT MAX(order_date)
    FROM Orders
);


SELECT SUM(subtotal) AS total_revenue
FROM Order_Details;

