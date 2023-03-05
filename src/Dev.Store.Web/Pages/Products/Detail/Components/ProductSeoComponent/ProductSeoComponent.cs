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
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Web.Pages.Products.Detail.Components.ProductSeoComponenet
{
    [Widget(
        ScriptFiles = new[] { "/Pages/Products/Detail/Components/ProductSeoComponent/ProductSeoComponent.js" }
        )]
    public class ProductSeoComponenet : AbpViewComponent
    {
        private readonly ISeoSettingRepository seoSettingRepository;
        private readonly IProductRepository productRepository;
        private readonly IKeywordRepository keywordRepository;
        public ProductSeoComponenet(ISeoSettingRepository seoSettingRepository, IProductRepository productRepository, IKeywordRepository keywordRepository)
        {
            this.seoSettingRepository = seoSettingRepository;
            this.productRepository = productRepository;
            this.keywordRepository = keywordRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            var product = await productRepository.GetAsync(x => x.Id == productId);
            var seo = await seoSettingRepository.FindAsync(x => x.ProductId == productId);
            if (seo == null)
            {
                var keywords = string.Join(",", (await keywordRepository.GetListAsync()).Select(a => a.Name));
                seo = await seoSettingRepository.InsertAsync(new SeoSetting
                {
                    Title = product.Name,
                    Keywords = keywords,
                    ProductId = productId
                });
            }

            var model = ObjectMapper.Map<SeoSetting, CreateEditSeoSettingViewModel>(seo);

            return View("ProductSeoComponenet.cshtml", model);
        }
    }
}
