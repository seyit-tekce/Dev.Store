using Dev.Store.Keywords;
using Dev.Store.Products;
using Dev.Store.SeoSettings;
using Dev.Store.Web.Pages.SeoSettings.SeoSetting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dev.Store.Web.Pages.Products.Detail.Components.ProductSeoComponenet
{
    [Widget(
        ScriptFiles = new[] { "/Pages/Products/Detail/Components/ProductSeoComponent/ProductSeoComponent.js" }
        )]
    public class ProductSeoComponenet : AbpViewComponent
    {
        private readonly ISeoSettingRepository seoSettingRepository;
        private readonly IKeywordRepository keywordRepository;
        private readonly IProductAppService productAppService;

        public ProductSeoComponenet(ISeoSettingRepository seoSettingRepository, IKeywordRepository keywordRepository, IProductAppService productAppService)
        {
            this.seoSettingRepository = seoSettingRepository;
            this.keywordRepository = keywordRepository;
            this.productAppService = productAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            var product = await productAppService.GetAsync(productId);
            var seo = await seoSettingRepository.FindAsync(x => x.ProductId == productId);
            if (seo == null)
            {
                var keywords = string.Join(",", (await keywordRepository.GetListAsync()).Select(a => a.Name));
                seo = await seoSettingRepository.InsertAsync(new SeoSetting
                {
                    Title = product.Name,
                    Keywords = keywords,
                    ProductId = productId,
                    Description = product.Name,
                });
            }

            var model = ObjectMapper.Map<SeoSetting, CreateEditSeoSettingViewModel>(seo);
            
            model.Product = product;
            model._Keywords=model.Keywords.Split(",").ToList();
            var s = new Model
            {
                ViewModel = model,
            };
            return View("ProductSeoComponenet.cshtml", s);
        }
    }

    public class Model
    {

        public CreateEditSeoSettingViewModel ViewModel { get; set; }


    }
}