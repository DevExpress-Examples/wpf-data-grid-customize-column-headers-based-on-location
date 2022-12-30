<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1137093)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Data Grid - How To Customize Column Headers 

This example demonstrates how to customize column headers in the headers panel, group panel or column chooser independent from each other. They can be distinguished by the [`ColumnBase.HeaderPresenterType`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.HeaderPresenterType) attached property. 


## Implementation details

This solution implements a multi-value converter to modify the column header based on its type. The header itself is the first bound value and its type is the second:

```xml
<Style TargetType="dxg:GridColumn">
    <Setter Property="HeaderTemplate">
        <Setter.Value>
            <DataTemplate>
                <TextBlock>
                    <TextBlock.Text>
                        <MultiBinding Converter="{local:CustomHeaderConverter}">
                            <Binding />
                            <Binding Path="(dxg:ColumnBase.HeaderPresenterType)" RelativeSource="{RelativeSource Self}" />
                        </MultiBinding>
                    </TextBlock.Text>
                </TextBlock>
            </DataTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

```cs
private string GetCustomHeaderString(string originalHeader, HeaderPresenterType headerType) {
    switch (headerType) {
        case HeaderPresenterType.Headers:
            return originalHeader.Replace("Original ", "Custom\nPanel\n");
        case HeaderPresenterType.GroupPanel:
            return originalHeader.Replace("Original", "Custom Group");
        case HeaderPresenterType.ColumnChooser:
            return originalHeader.Replace("Original", "Custom Column Chooser");
    }

    return originalHeader;
}
```

## Documentation

- [ColumnBase.HeaderPresenterType](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.HeaderPresenterType)


## Files to Review
- [MainWindow.xaml](./CS/CustomColumnHeader/MainWindow.xaml)
  
- [CustomHeaderConverter.cs](./CS/CustomColumnHeader/CustomHeaderConverter.cs)
