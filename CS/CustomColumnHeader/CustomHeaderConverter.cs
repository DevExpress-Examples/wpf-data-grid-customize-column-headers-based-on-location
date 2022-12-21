using DevExpress.Xpf.Grid;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CustomColumnHeader
{
    public class CustomHeaderConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return GetCustomHeaderString((string)values[0], (HeaderPresenterType)values[1]);
        }

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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
