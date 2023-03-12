using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.Web.Public.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        private readonly ICategoryAppService categoryAppService;
        private readonly IProductAppService productAppService;

        public IndexModel(ICategoryAppService categoryAppService, IProductAppService productAppService)
        {
            this.categoryAppService = categoryAppService;
            this.productAppService = productAppService;
        }

        public async Task OnGet(string mainCategory, string subCategory)
        {
            this.Category = await categoryAppService.GetCategoryByMainAndSubName(mainCategory, subCategory);
            Products = await productAppService.GetFirst25ByCategoryId(Category.Id);
        }
    }
}
