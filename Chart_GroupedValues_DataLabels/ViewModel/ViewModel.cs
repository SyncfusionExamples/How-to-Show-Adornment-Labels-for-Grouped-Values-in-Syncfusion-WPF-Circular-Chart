namespace Chart_GroupedValues_DataLabels
{
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        public ObservableCollection<CountryInfo> CountryData { get; set; }

        public MainViewModel()
        {
            CountryData = new ObservableCollection<CountryInfo>()
            {
                new CountryInfo { Country = "Malta", Count = 960 },
                new CountryInfo { Country = "Maldives", Count = 941 },
                new CountryInfo { Country = "Monaco", Count = 908 },
                new CountryInfo { Country = "Uruguay", Count = 2407 },
                new CountryInfo { Country = "Argentina", Count = 2077 },
                new CountryInfo { Country = "USA", Count = 1973 },
                new CountryInfo { Country = "Germany", Count = 1820 },
                new CountryInfo { Country = "Netherlands", Count = 1701 }
            };
        }
    }
}