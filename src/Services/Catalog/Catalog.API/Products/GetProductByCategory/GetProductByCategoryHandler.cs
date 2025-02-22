
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryHandler(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryHandler, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryHandler request, CancellationToken cancellationToken)
        {
            var result = await session.Query<Product>().Where(e => e.Category.Contains(request.Category)).ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(result);
        }
    }
}
