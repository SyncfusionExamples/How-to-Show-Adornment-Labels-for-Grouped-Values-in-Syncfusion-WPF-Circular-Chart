# How to show adornment labels for grouped values in WPF Circular Chart
This article explains how to display adornment labels for grouped values in a [Syncfusion WPF Circular Chart](https://www.syncfusion.com/wpf-controls/charts). Grouped segments are created using the [GroupTo](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CircularSeriesBase.html#Syncfusion_UI_Xaml_Charts_CircularSeriesBase_GroupTo) property, and labels are customized using converters and templates to show multiple data points in a single label.

For more details, refer to the [Group To documentation in Syncfusion UG](https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#group-small-data-points-into-others).

## Steps to display and customize adornment labels for grouped values

**Step 1: Getting Started**

Let’s configure the [Syncfusion® WPF Circular Chart](https://www.syncfusion.com/wpf-controls/charts/2d-chart#circular-charts) control using this [getting started documentation](https://help.syncfusion.com/wpf/charts/getting-started). This section guides you through the initial configuration steps required to integrate the chart control using [Syncfusion’s WPF NuGet packages](https://www.nuget.org/packages?q=syncfusion+wpf&includeComputedFrameworks=true&prerel=true&sortby=relevance).

**Step 2: Add PieSeries to the Chart**

Define the [PieSeries](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PieSeries.html) inside the SfChart control and bind it to your data source, and need to specify the [GroupTo](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CircularSeriesBase.html#Syncfusion_UI_Xaml_Charts_CircularSeriesBase_GroupTo) property, which determines the threshold value for grouping smaller data points. In the example below, data points with values less than 1000 are grouped together.

**[XAML]**

```
<chart:SfChart>
. . . 

    <chart:PieSeries x:Name="pieSeries"
                     ItemsSource="{Binding CountryData}"
                     XBindingPath="Country"
                     YBindingPath="Count"
                     GroupMode="Value"
                     GroupTo="1000"
    </chart:PieSeries>

. . .
</chart:SfChart> 
 ```

**Step 3:** Enable Data Label

Use [ChartAdornmentInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAdornmentInfo.html) to show labels and connector lines. For more details, refer to the [Adornments UG Documentation](https://help.syncfusion.com/wpf/charts/adornments/label).

**[XAML]**

```
<chart:SfChart>
. . . 

    <chart:PieSeries.AdornmentsInfo>
        <chart:ChartAdornmentInfo ShowConnectorLine="True" 
                                  ConnectorHeight="80" 
                                  ShowLabel="True"  
                                  SegmentLabelContent="LabelContentPath">
        </chart:ChartAdornmentInfo>
    </chart:PieSeries.AdornmentsInfo> 

. . .
</chart:SfChart> 
 ```

 Note: To display both the X and Y values in the data labels, set the SegmentLabelContent property to LabelContentPath. This ensures that the labels reflect the bound data accurately.

**Step 4: Define the Custom Data Label Template**

 Next, we create a custom data label template called “customDataLabelTemplate”. This template uses a vertical stack layout to format the label content.

**[XAML]**

```
. . .
<Window.Resources>
   <DataTemplate x:Key="customDataLabelTemplate">
       <StackPanel Orientation="Vertical" Margin="5">
           <TextBlock Text="{Binding Converter={StaticResource DataLabelConverter}}"                          
                      Margin="3" Foreground="White">
           </TextBlock>
       </StackPanel>
   </DataTemplate>
</Window.Resources> 
<chart:SfChart>
. . . 

 ```

**Step 5: Implement Converters**

 This converter formats pie chart labels by extracting and displaying country names and their counts. It handles both single CountryInfo items and grouped collections, returning a readable label string for each chart segment.

 **[C#]**

```
public class DataLabelTemplateConverter : IValueConverter
{
   public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
   {
       if (value is ChartPieAdornment adornment)
       {
           // Case 1: Single item
           if (adornment.Item is CountryInfo model)
           {
               return $"{model.Country} : {model.Count}";
           }
           // Case 2: Grouped items (e.g., List<CountryInfo>)
           else if (adornment.Item is IEnumerable<object> group)
           {
               var lines = new List<string>();

               foreach (var item in group)
               {
                   if (item is CountryInfo country)
                   {
                       lines.Add($"{country.Country} : {country.Count}");
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

 ```

**Step 6: Integrate Custom Data Label Template with the Chart**

 Finally, we add the custom data label template to the Circular Chart by setting the [LabelTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAdornmentInfoBase.html#Syncfusion_UI_Xaml_Charts_ChartAdornmentInfoBase_LabelTemplate) property in the ChartAdornmentInfo class.

**[XAML]**

```
<chart:SfChart>
. . . 

    <chart:ChartAdornmentInfo LabelTemplate="{StaticResource customDataLabelTemplate}" /> 

. . .
</chart:SfChart> 
 ```

 ## Output

 ![Chart adornment grouped values](https://github.com/user-attachments/assets/e94ac551-5492-4d9c-b808-383fd15d342a)

 ## Troubleshooting

#### Path too long exception

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For more details, refer to the KB on [how to show adornment labels for grouped values in Syncfusion WPF Circular chart control?](https://support.syncfusion.com/kb/article/21684/how-to-show-adornment-labels-for-grouped-values-in-wpf-circular-chart).
