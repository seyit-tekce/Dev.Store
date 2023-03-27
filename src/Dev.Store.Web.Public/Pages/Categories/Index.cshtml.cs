using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.Web.Public.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<ProductGridListDto> Products { get; set; }

        public int ProductCount { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Paging { get; set; } = 0;

        private readonly ICategoryAppService categoryAppService;
        private readonly IProductAppService productAppService;

        public IndexModel(ICategoryAppService categoryAppService, IProductAppService productAppService)
        {
            this.categoryAppService = categoryAppService;
            this.productAppService = productAppService;
        }

        public async Task OnGet(string category, string subcategory)
        {
            var getCategory = await categoryAppService.GetCategoryByMainAndSubName(category, subcategory);
            var getProduct = await productAppService.GetProductByCategoryIdPaging(getCategory.Id, Paging * 25, 25);
            var getProductCount = await productAppService.GetProductCount(getCategory.Id);

            this.Category = getCategory;
            this.Products = getProduct;
            this.ProductCount = getProductCount;
        }
    }
}
