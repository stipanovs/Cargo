--a.	Write a query to display first name, last name, 
--package number and internet speed for all customers.
SELECT c.First_Name, c.Last_Name, p.pack_id, p.speed
FROM customers AS c
INNER JOIN packages AS p ON p.pack_id = c.pack_id;