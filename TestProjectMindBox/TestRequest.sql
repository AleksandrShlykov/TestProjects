SELECT Products.Name || " — "|| Categories.Name as 'Information'
FROM Products JOIN Products_Cotygory ON Products.Id = Products_Cotygory.ProductId JOIN Categories ON Products_Cotygory.CategoryId = Categories.Id
UNION
SELECT Products.Name  as 'Information'
FROM Products JOIN Products_Cotygory ON  (Products_Cotygory.CategoryId IS NULL AND Products.Id = Products_Cotygory.ProductId)
