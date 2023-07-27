using Dev.Store.Categories;
using Dev.Store.Products;
using Dev.Store.Web.Public.Pages.Categories.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Store.Web.Public.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public IndexViewModel View { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Paging { get; set; } = 0;

        private readonly ICategoryAppService categoryAppService;
        private readonly IProductAppService productAppService;

        public IndexModel(ICategoryAppService categoryAppService, IProductAppService productAppService)
        {
            this.categoryAppService = categoryAppService;
            this.productAppService = productAppService;
        }
        public async Task OnGetAsync(string category, string subcategory)
        {
            var getCategory = await categoryAppService.GetCategoryByMainAndSubName(category, subcategory);
            var getProduct = await productAppService.GetProductByCategoryIdPaging(getCategory.Id, Paging * 25, 25);
            var getProductCount = await productAppService.GetProductCount(getCategory.Id);

            View = new IndexViewModel
            {
                CategoryLink = getCategory.Link,
                CategoryName = getCategory.Name,
                CategoryParentLink = getCategory.CategoryParent.Link,
                CategoryParentName = getCategory.CategoryParent.Name,
                ProductCount = getProductCount,
                Products = getProduct.Select(a => new IndexViewModelProduct
                {
                    MainImage = a.MainImagePath,
                    Price = a.Price,
                    ProductName = a.Name,
                    SecondImage = a.SecondImagePath,
                    ProductCode = a.Code
                }).ToList()
            };

        }
    }
}
