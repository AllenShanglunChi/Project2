using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Project2
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel myMainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            myMainPageViewModel = new MainPageViewModel();
            BindingContext = myMainPageViewModel;
            Console.WriteLine("MainPage constructor called");

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("OnItemSelected executed");

            if (e.SelectedItem == null)
                return;

            var selectedStaff = e.SelectedItem as Staff;
            Navigation.PushAsync(new StaffProfileDetailsPage(selectedStaff, (MainPageViewModel)BindingContext));

            // Deselect item
            ((ListView)sender).SelectedItem = null;
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("OnAddClicked executed");

            // Create a new instance of AddStaffProfilePage, passing the ViewModel
            var addStaffPage = new AddStaffProfilePage(myMainPageViewModel.Departments, myMainPageViewModel);

            // Subscribe to the Disappearing event of the AddStaffProfilePage
            addStaffPage.Disappearing += (s, args) =>
            {
                // Handle the event when the AddStaffProfilePage disappears
                // This will be triggered when the user saves or cancels
                myMainPageViewModel.Departments = new ObservableCollection<Department>(myMainPageViewModel.Departments);
            };

            // Navigate to the AddStaffProfilePage
            Navigation.PushAsync(addStaffPage);
        }


    }
}
