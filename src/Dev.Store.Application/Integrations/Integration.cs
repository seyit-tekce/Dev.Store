
using DataAccess.Abstract;
using Dev.Store.Categories;
using Dev.Store.ProductImages;
using Dev.Store.Products;
using Dev.Store.ProductSets;
using Dev.Store.ProductSizes;
using Dev.Store.UploadFiles;
using MongoDB.Driver;
using ServiceStack;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Integrations
{
    public class Integration : ApplicationService
    {
        private readonly DataAccess.Abstract.ICategoryRepository oldCategoryRepository;
        private readonly DataAccess.Abstract.ISubCategoryRepository oldSubCategoryRepository;
        private readonly DataAccess.Abstract.IProductRepository oldProductRepository;
        private readonly DataAccess.Abstract.ISetRepository oldSetRepository;
        private readonly DataAccess.Abstract.ISizeRepository oldSizeRepository;
        private readonly DataAccess.Abstract.IPhotoRepository oldPhotoRepository;
        private readonly DataAccess.Abstract.IFeatureRepository oldFeatureRepository;
        private readonly DataAccess.Abstract.ISeoSettingsRepository OldseoSettingsRepository;


        private readonly Categories.ICategoryRepository categoryRepository;
        private readonly IUploadFileRepository uploadFileRepository;
        private readonly Dev.Store.Products.IProductRepository productRepository;

        public Integration(DataAccess.Abstract.ICategoryRepository oldCategoryRepository, ISubCategoryRepository oldSubCategoryRepository, DataAccess.Abstract.IProductRepository oldProductRepository, ISetRepository oldSetRepository, ISizeRepository oldizeRepository, IPhotoRepository oldPhotoRepository, IFeatureRepository oldFeatureRepository, Categories.ICategoryRepository categoryRepository, IUploadFileRepository uploadFileRepository, ISeoSettingsRepository oldseoSettingsRepository, Products.IProductRepository productRepository)
        {
            this.oldCategoryRepository = oldCategoryRepository;
            this.oldSubCategoryRepository = oldSubCategoryRepository;
            this.oldProductRepository = oldProductRepository;
            this.oldSetRepository = oldSetRepository;
            this.oldSizeRepository = oldizeRepository;
            this.oldPhotoRepository = oldPhotoRepository;
            this.oldFeatureRepository = oldFeatureRepository;
            this.categoryRepository = categoryRepository;
            this.uploadFileRepository = uploadFileRepository;
            OldseoSettingsRepository = oldseoSettingsRepository;
            this.productRepository = productRepository;
        }


        public async Task CopyAll()
        {
            var categories = await oldCategoryRepository.GetListAsync();
            var subCategories = await oldSubCategoryRepository.GetListAsync();
            var products = await oldProductRepository.GetListAsync();
            var sets = await oldSetRepository.GetListAsync();
            var sizes = await oldSizeRepository.GetListAsync();
            var photos = await oldPhotoRepository.GetListAsync();
            var features = await oldFeatureRepository.GetListAsync();
            var seos = await OldseoSettingsRepository.GetListAsync();

            await categoryRepository.InsertManyAsync(categories.Select(a => new Category(GuidGenerator.Create(), a.Name, a.Link, a.Name, null, true, subCategories.Where(x => x.CategoryId == a.Id).Select(sub => new Category(GuidGenerator.Create(), sub.Name, sub.Link == null ? sub.Name : sub.Link, sub.Name, null, true, null, null)).ToList(), null)).ToList(), true);
            await uploadFileRepository.InsertManyAsync(photos.Select(image => new UploadFiles.UploadFile(GuidGenerator.Create(), image.Name, image.Url, image.PublicId, null)), true);
            var newCategories = await categoryRepository.GetListAsync();
            var uploadFiles = await uploadFileRepository.GetListAsync();
            var iProducts = products.Where(x => x.AddedDate >= new System.DateTime(2022, 01, 01)).Select(product =>
            {
                var feature = features.FirstOrDefault(x => x.ProductId == product.Id);
                var oldCategory = subCategories.FirstOrDefault(x => x.Id == product.SubCategoryId);
                var newCategory = newCategories.FirstOrDefault(x => x.Name == oldCategory.Name);
                var seo = seos.FirstOrDefault(x => x.ProductId == product.Id) ?? new Entities.Concrete.SeoSetting();
                var newProduct = new Product(GuidGenerator.Create(), product.ProductName,
                    product.ProductCode,
                    feature?.Features ?? "",
                    product.UnitPrice,
                    newCategory.Id,
                    newCategory,
                    null,
                    null,
                    true,
                    sets.Where(x => x.ProductId == product.Id).Select(set => new ProductSet(GuidGenerator.Create(), set.ProductName, set.ProductName, GuidGenerator.Create(), set.Price, set.Amount, set.IsOptional)).ToList(),
                    sizes.Where(x => x.ProductId == product.Id).Select(size => new ProductSize(GuidGenerator.Create(), size.Width + "*" + size.Height, GuidGenerator.Create(), size.Height, size.Width, null, size.Price, false)).ToList()
                    , photos.Where(x => x.ProductId == product.Id).Select(image =>
                    {

                        return new ProductImage(GuidGenerator.Create(), GuidGenerator.Create(), uploadFiles.FirstOrDefault(x => x.FilePath == image.Url).Id, image.IsMain, null, null);

                    }).ToList(), new SeoSettings.SeoSetting(GuidGenerator.Create(), product.ProductName, seo.SiteDescription ?? "Yatak,Baza,Set,Başlık", seo.KeyWords ?? "Yatak,Baza,Set,Başlık", GuidGenerator.Create(), null));


                return newProduct;
            });

            await productRepository.InsertManyAsync(iProducts);




        }
    }
}
