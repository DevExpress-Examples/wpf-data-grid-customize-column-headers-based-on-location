using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace CustomColumnHeader {
    public class MainViewModel : ViewModelBase {
        public ObservableCollection<Item> Source { get; } = new ObservableCollection<Item>(Item.GetData(100));
    }
}
