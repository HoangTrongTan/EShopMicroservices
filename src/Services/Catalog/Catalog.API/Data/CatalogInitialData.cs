using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }
    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "IPhone X",
            Description = "This phone is the company's biggest change to its flagship smartphone in years.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("c67d6323-e8b1-4b56-9a75-a77b1b14426a"),
            Name = "Samsung 10",
            Description = "This phone is the company's biggest change to its flagship smartphone in years.",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("4f136e9f-ff8c-4ced-9a10-5d6995025426"),
            Name = "Huawei Plus",
            Description = "This phone is the company's biggest change to its flagship smartphone in years.",
            ImageFile = "product-3.png",
            Price = 650.00M,
            Category = new List<string> { "White Appliances" }
        },
        new Product()
        {
            Id = new Guid("91049944-7d52-4a00-b807-690a5a0f671b"),
            Name = "Xiaomi Mi 9",
            Description = "This phone is the company's biggest change to its flagship smartphone in years.",
            ImageFile = "product-4.png",
            Price = 470.00M,
            Category = new List<string> { "White Appliances" }
        },
        new Product()
        {
            Id = new Guid("04e76d92-c53d-4610-9927-4633231e2a51"),
            Name = "HTC One",
            Description = "This phone is the company's biggest change to its flagship smartphone in years.",
            ImageFile = "product-5.png",
            Price = 400.00M,
            Category = new List<string> { "Home Kitchen" }
        },
        new Product()
        {
            Id = new Guid("3eeb9604-e588-4c3e-86e5-4a6c4296716f"),
            Name = "LG G7 ThinQ",
            Description = "This phone is the company's biggest change to its flagship smartphone in years.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Category = new List<string> { "Camera" }
        }
    };
}
