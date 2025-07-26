namespace BikeStore.Infra.Queries;

public static class ProductQueries
{
    public const string GetProductsWithBrandAndCategoryQuery =
        """
            SELECT 
               p.product_id AS ProductId,
               p.product_name AS ProductName,
               p.list_price AS ListPrice,
               b.brand_name AS BrandName,
               c.category_name AS CategoryName,
               p.model_year AS ModelYear
            FROM BikeStores.production.products p
                INNER JOIN BikeStores.production.categories c 
                    ON c.category_id = p.category_id
                INNER JOIN BikeStores.production.brands b 
                    ON b.brand_id = p.brand_id
        """;

    public const string GetProductByIdQuery =
        """
            SELECT 
               p.product_id AS ProductId,
               p.product_name AS ProductName,
               p.list_price AS ListPrice,
               b.brand_name AS BrandName,
               c.category_name AS CategoryName,
               p.model_year AS ModelYear
            FROM BikeStores.production.products p
                INNER JOIN BikeStores.production.categories c 
                    ON c.category_id = p.category_id
                INNER JOIN BikeStores.production.brands b 
                    ON b.brand_id = p.brand_id
            WHERE p.product_id = @ProductId
        """;

    public const string AddProductQuery =
        """
        INSERT INTO BikeStores.production.products
        (product_name, brand_id, category_id, model_year, list_price)
        VALUES(@ProductName, @BrandId, @CategoryId, @ModelYear, @Price);
        SELECT CAST(SCOPE_IDENTITY() AS INT);
        """;

}
