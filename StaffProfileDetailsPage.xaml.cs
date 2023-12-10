using Microsoft.Maui.Controls;

namespace Project2
{
    public partial class StaffProfileDetailsPage : ContentPage
    {
        private Staff _selectedStaff;
        private MainPageViewModel _viewModel;

        public StaffProfileDetailsPage(Staff selectedStaff, MainPageViewModel viewModel)
        {
            InitializeComponent();
            _selectedStaff = selectedStaff;
            _viewModel = viewModel;

            // Fetch the Department corresponding to the DepartmentId
            var department = _viewModel.Departments.FirstOrDefault(d => d.Id == _selectedStaff.DepartmentId);

            // Set the DepartmentName property
            _selectedStaff.DepartmentName = department?.Name;

            BindingContext = _selectedStaff;
        }

        private void OnUpdateClicked(object sender, System.EventArgs e)
        {
            // Pass the selected staff and the view model instance to the UpdateStaffProfilePage
            Navigation.PushAsync(new UpdateStaffProfilePage(_selectedStaff, _viewModel));
        }

        private void OnBackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
