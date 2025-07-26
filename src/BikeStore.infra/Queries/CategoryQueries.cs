namespace BikeStore.Infra.Queries;

public class CategoryQueries
{
    public const string GetAllCategories = 
        """
        SELECT
            c.category_id AS CategoryId,
            c.category_name AS CategoryName
        FROM BikeStores.production.categories c 
        """;
}