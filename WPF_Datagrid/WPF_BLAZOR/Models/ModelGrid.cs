using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF_BLAZOR.Models
{
    public partial class ModelGrid : ObservableObject
    {
        public void Update(ModelGrid? modelGrid)
        {
            if (modelGrid is null) return;

            String1 = modelGrid.string1;
            String2 = modelGrid.string2;
            String3 = modelGrid.string3;
            String4 = modelGrid.string4;
            String5 = modelGrid.string5;
            String6 = modelGrid.string6;
            String7 = modelGrid.string7;
            String8 = modelGrid.string8;
            String9 = modelGrid.string9;
            String10 = modelGrid.string10;
        }

        public void Clear()
        {
            String1 = null;
            String2 = null;
            String3 = null;
            String4 = null;
            String5 = null;
            String6 = null;
            String7 = null;
            String8 = null;
            String9 = null;
            String10 = null;
        }

        [ObservableProperty]
        private string string1;
        [ObservableProperty]
        private string string2;
        [ObservableProperty]
        private string string3;
        [ObservableProperty]
        private string string4;
        [ObservableProperty]
        private string string5;
        [ObservableProperty]
        private string string6;
        [ObservableProperty]
        private string string7;
        [ObservableProperty]
        private string string8;
        [ObservableProperty]
        private string string9;
        [ObservableProperty]
        private string string10;
    }
}
