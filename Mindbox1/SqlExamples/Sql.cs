namespace SqlExamples;

/*
 В базе данных MS SQL Server есть продукты и категории. 
 Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. 
 Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
 Если у продукта нет категорий, то его имя все равно должно выводиться.
 По возможности — положите ответ рядом с кодом из первого вопроса.

 */
public class Sql
{
    public void Examples()
    {
        var sqlWayFirst = """
                          SELECT p.product_name, c.category_name 
                          FROM products AS p
                              LEFT OUTER JOIN product_to_category AS ptc ON p.product_id = ptc.product_id
                              LEFT OUTER JOIN categories AS c ON c.category_id = ptc.category_id
                          ORDER BY p.product_name, c.category_name
                          """;

        var sqlWaySecond = """
                           SELECT p.product_name, c.category_name
                           FROM products AS p
                               LEFT OUTER JOIN (
                               SELECT c0.category_name, ptc.product_id
                               FROM product_to_category AS ptc 
                                   INNER JOIN categories AS c0 ON c0.category_id = ptc.category_id
                               ) as c ON p.product_id = c.product_id

                           ORDER BY p.product_name, c.category_name
                           """;
    }
}