using Microsoft.Maui.Controls;

namespace Project2
{
    public partial class SettingsPage : ContentPage
    {
        private Settings _settings;

        public SettingsPage()
        {
            InitializeComponent();
            _settings = SettingsService.LoadSettings();
            BindingContext = _settings;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Save the updated settings
            SettingsService.SaveSettings(_settings);
            DisplayAlert("Success", "Settings saved!", "OK");
        }
    }
}
