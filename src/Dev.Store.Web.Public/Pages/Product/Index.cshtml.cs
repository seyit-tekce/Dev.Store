using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
namespace Dev.Store.Web.Public.Pages.Product
{
    public class IndexModel : AbpPageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        public ProductDto Product { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<ProductGridListDto> RelatedProducts { get; set; }

        public IndexModel(IProductAppService productAppService, ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }
        public async Task OnGetAsync(string category, string subcategory, string productLink)
        {
            var getCategory = await _categoryAppService.GetCategoryByMainAndSubName(category, subcategory);
            RelatedProducts = await _productAppService.GetProductByCategoryIdPaging(getCategory.Id, 0, 4);
            if (getCategory == null)
            {
                Unauthorized();
            }
            Category = getCategory;
            Product = await _productAppService.GetProductDetail(getCategory.Id, productLink);
            Product.Price = (Product.ProductSets?.Where(b => !b.IsOptional).Sum(b => b.Price) + Product.ProductSizes?.Where(b => b.IsDefault).Sum(x => x.Price))??0;  
        }
    }
}
