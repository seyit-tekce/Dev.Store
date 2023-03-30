using Dev.Store.Categories;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
namespace Dev.Store.Web.Public.Pages.Product
{
    public class IndexModel : AbpPageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        public ProductDto Product { get; set; }
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
            Product = await _productAppService.GetProductDetail(getCategory.Id, productLink);
        }
    }
}
