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
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Skip { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public int Take { get; set; } = 25;
        public CategoryDto Category { get; set; }
        public IEnumerable<ProductGridListDto> Products { get; set; }

        public int ProductCount { get; set; }

        private readonly ICategoryAppService categoryAppService;
        private readonly IProductAppService productAppService;

        public IndexModel(ICategoryAppService categoryAppService, IProductAppService productAppService)
        {
            this.categoryAppService = categoryAppService;
            this.productAppService = productAppService;
        }

        public async Task OnGet(string mainCategory, string subCategory)
        {
            var getCategory = await categoryAppService.GetCategoryByMainAndSubName(mainCategory, subCategory);
            var getProduct = await productAppService.GetProductByCategoryIdPaging(getCategory.Id, Skip, Take);
            var getProductCount = await productAppService.GetProductCount(getCategory.Id);

            this.Category = getCategory;
            this.Products = getProduct;
            this.ProductCount = getProductCount;
        }
    }
}
