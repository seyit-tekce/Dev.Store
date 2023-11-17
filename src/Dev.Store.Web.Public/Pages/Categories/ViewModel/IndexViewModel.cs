using System.Collections.Generic;

namespace Dev.Store.Web.Public.Pages.Categories.ViewModel
{
    public class IndexViewModel
    {
        public string CategoryName { get; set; }
        public string CategoryLink { get; set; }
        public string Description { get; set; }
        public string CategoryParentName { get; set; }
        public string CategoryParentLink { get; set; }

        public int ProductCount { get; set; }
        public List<IndexViewModelProduct> Products { get; set; }

    }
    public class IndexViewModelProduct
    {
        public string MainImage { get; set; }
        public string SecondImage { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
    }
}
