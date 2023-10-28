using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Products;

public interface IProductRepository : IRepository<Product, Guid>
{
    public Task<int> GetCountByCategoryId(Guid categoryId);
    public Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId, int skip = 0, int take = 50);
    public Task<IEnumerable<Product>> GetNewestProductList(int skip = 0, int take = 8);
    public Task<IEnumerable<Product>> GetBestSellerProductList(int skip = 0, int take = 8);
    public Task<Product> GetProductWithDetailsByCategoryAndCode(Guid categoryId, string code);
    public Task<Product> GetProductById(Guid productId);
}
