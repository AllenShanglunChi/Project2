using Microsoft.Maui.Controls;
using Project2;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static Project2.MainPageViewModel;

namespace Project2
{
    public partial class AddStaffProfilePage : ContentPage
    {
        private ObservableCollection<Department> _departments;
        private MainPageViewModel _viewModel; // Add a reference to MainPageViewModel

        // Constructor for passing departments and view model
        public AddStaffProfilePage(ObservableCollection<Department> departments, MainPageViewModel viewModel)
        {
            InitializeComponent();
            _departments = departments;
            _viewModel = viewModel; // Assign the instance of MainPageViewModel

            BindingContext = viewModel;

            PopulateDepartments();
        }

        // Default constructor, initializes with an empty ObservableCollection
        public AddStaffProfilePage()
        {
            InitializeComponent();
            _departments = new ObservableCollection<Department>();
            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;

            PopulateDepartments();
        }

        private void PopulateDepartments()
        {
            foreach (var department in _departments)
            {
                departmentPicker.Items.Add(department.Name);
            }

            if (_departments.Any())
            {
                departmentPicker.SelectedIndex = 0;
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {


            // Validate the new staff profile
            if (string.IsNullOrWhiteSpace(nameEntry.Text) ||
                string.IsNullOrWhiteSpace(phoneEntry.Text) ||
                departmentPicker.SelectedIndex == -1)
            {
                DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
                return;
            }

            // Create a new staff object
            var newStaff = new Staff
            {
                Name = nameEntry.Text,
                Phone = phoneEntry.Text,
                DepartmentId = _departments[departmentPicker.SelectedIndex].Id,
                Address = addressEntry.Text
            };

            // Save the new staff profile to the backend or local storage
            _viewModel.SaveStaff(newStaff);

            // For demo purposes, add the new staff to the collection

            _viewModel.StaffList.Add(newStaff);

            Navigation.PopAsync();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
