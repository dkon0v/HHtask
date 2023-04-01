# HHtask

# Задание 1
* Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.
 
 Это пример библиотеки на C#, которая реализует указанные функции и содержит юнит-тесты. Эта библиотека предоставляет общий интерфейс IShape, который определяет метод GetArea(). Каждая конкретная фигура реализует этот интерфейс и свою логику вычисления площади. 
 https://github.com/dkon0v/HHtask/blob/main/CircleTraingle.cs

# Задание 2
* В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

"SELECT Products.Name, Categories.Name\
FROM Products\
LEFT JOIN ProductCategories ON Products.Id = ProductCategories.ProductId\
LEFT JOIN Categories ON Categories.Id = ProductCategories.CategoryId\
ORDER BY Products.Name\
