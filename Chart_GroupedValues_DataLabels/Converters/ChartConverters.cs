namespace Chart_GroupedValues_DataLabels
{
    using Syncfusion.UI.Xaml.Charts;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts data values into custom label templates for chart adornments.
    /// Useful for customizing the appearance of data labels in chart segments.
    /// </summary>
    public class DataLabelTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChartPieAdornment adornment)
            {
                // Case 1: Single item
                if (adornment.Item is ProductSales model)
                {
                    return $"{model.Product} : {model.SalesRate}";
                }
                // Case 2: Grouped items (e.g., List<ProductSales>)
                else if (adornment.Item is IEnumerable<object> group)
                {
                    var lines = new List<string>();

                    foreach (var item in group)
                    {
                        if (item is ProductSales product)
                        {
                            lines.Add($"{product.Product} : {product.SalesRate}");
                        }
                    }

                    return string.Join("\n", lines);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    /// <summary>
    /// Converts data values into brush styles for chart segments.
    /// Enables dynamic styling of chart segments based on bound data.
    /// </summary>
    public class SegmentBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChartPieAdornment adornment && adornment.Interior != null)
            {
                return adornment.Interior;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
