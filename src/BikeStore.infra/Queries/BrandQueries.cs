namespace BikeStore.Infra.Queries;

public static class BrandQueries
{
    public const string GetAllBrands =
        """
        SELECT
            b.brand_id AS BrandId,
            b.brand_name AS BrandName
        FROM BikeStores.production.brands b 
        """;
}