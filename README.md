<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1137093)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Data Grid - Customize Column Headers Based on Location

This example applies different settings to column headers based on the header's container. The [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl) displays column headers in the [column header panel](https://docs.devexpress.com/WPF/7569/controls-and-libraries/data-grid/visual-elements/common-elements/column-header-panel), [group panel](https://docs.devexpress.com/WPF/6215/controls-and-libraries/data-grid/visual-elements/common-elements/group-panel) (if you group data by this column), or [column chooser](https://docs.devexpress.com/WPF/6217/controls-and-libraries/data-grid/visual-elements/common-elements/column-band-chooser). Use the [ColumnBase.HeaderPresenterType](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.HeaderPresenterType) attached property to determine the header's location.

The following table demonstrates how the header's text is changed:

| Header's Location | New Text |
| --- | --- |
| [Column header panel](https://docs.devexpress.com/WPF/7569/controls-and-libraries/data-grid/visual-elements/common-elements/column-header-panel) | Custom Panel Header |
| [Group panel](https://docs.devexpress.com/WPF/6215/controls-and-libraries/data-grid/visual-elements/common-elements/group-panel) | Custom Group Header |
| [Column chooser](https://docs.devexpress.com/WPF/6217/controls-and-libraries/data-grid/visual-elements/common-elements/column-band-chooser) | Custom Column Chooser Header |

![image](https://user-images.githubusercontent.com/65009440/212900882-89b3e293-71c2-4f87-9fb0-bd1b006aa629.png)

## Implementation details

This solution implements a multi-value converter that changes the header's text. The converter receives the column header and its location and returns the new header text:

```xaml
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

## Files to Review

- [MainWindow.xaml](./CS/CustomColumnHeader/MainWindow.xaml)
- [CustomHeaderConverter.cs](./CS/CustomColumnHeader/CustomHeaderConverter.cs)

## Documentation

- [ColumnBase.HeaderPresenterType](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.HeaderPresenterType)
- [Column Header Customization](https://docs.devexpress.com/WPF/6295/controls-and-libraries/data-grid/appearance-customization/column-header-customization)

## More Examples

- [WPF Data Grid - Display an Image within a Column Header](https://github.com/DevExpress-Examples/how-to-display-an-image-within-a-column-header-e1629)
- [WPF Data Grid - Display a Check Box in Column Headers](https://github.com/DevExpress-Examples/how-to-display-a-check-box-within-column-headers-e1517)
- [WPF Data Grid - Display a Standalone Column Chooser](https://github.com/DevExpress-Examples/how-to-create-a-custom-column-chooser-e1661)
- [WPF Data Grid - Specify Custom Content for Headers Displayed in the Column Chooser](https://github.com/DevExpress-Examples/wpf-data-grid-custom-content-for-column-chooser-headers)
