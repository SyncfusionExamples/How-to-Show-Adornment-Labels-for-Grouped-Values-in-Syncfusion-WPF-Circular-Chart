namespace Chart_GroupedValues_DataLabels
{
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        public ObservableCollection<ProductSales> Data { get; set; }

        public MainViewModel()
        {
            Data = new ObservableCollection<ProductSales>()
            {
                new ProductSales { Product = "Laptops", SalesRate = 1850 },
                new ProductSales { Product = "Smartphones", SalesRate = 1975 },
                new ProductSales { Product = "Tablets", SalesRate = 1120 },
                new ProductSales { Product = "Desktop PCs", SalesRate = 1480 },
                new ProductSales { Product = "Smart Watches", SalesRate = 720 },
                new ProductSales { Product = "Headphones", SalesRate = 380 },
                new ProductSales { Product = "Cameras", SalesRate = 610 },
            };
        }
    }
}