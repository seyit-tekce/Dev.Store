using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Polly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Dev.Store.Web.Public.Menus;

public class StoreMenuContributor : IMenuContributor
{
    private IEnumerable<CategoryDto> Categories { get; set; }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var categoryAppService = context.ServiceProvider.GetService<ICategoryAppService>();
        Categories = await categoryAppService.GetCategoriesAsync();
        var getMainList = Categories.Where(x => x.CategoryParentId == null).OrderBy(x => x.Order);

        foreach (var category in getMainList)
        {
            var menu = new ApplicationMenuItem(category.Link, category.Name, "/Categories/" + category.Link,customData:category.File?.FilePath);
            var subCategory = Categories.Where(x => x.CategoryParentId == category.Id).OrderBy(x => x.Order);
            RecursiveMenu(subCategory, ref menu);
            context.Menu.AddItem(menu);
        }

    }

    private void RecursiveMenu(IEnumerable<CategoryDto> categories, ref ApplicationMenuItem menuItem)
    {
        foreach (var category in categories)
        {
            var menu = new ApplicationMenuItem(category.Link, category.Name, menuItem.Url+"/" + category.Link);
            var subCategory = Categories.Where(x => x.CategoryParentId == category.Id).OrderBy(x => x.Order);
            RecursiveMenu(subCategory, ref menu);
            menuItem.AddItem(menu);

        }
    }


}
