using Microsoft.Maui.Controls;

namespace Project2
{
    public partial class UpdateStaffProfilePage : ContentPage
    {
        private Staff _staff;
        private MainPageViewModel _viewModel; // Add a reference to MainPageViewModel

        public UpdateStaffProfilePage(Staff staff, MainPageViewModel viewModel)
        {
            InitializeComponent();
            _staff = staff;
            _viewModel = viewModel; // Assign the instance of MainPageViewModel

            // Populate the UI with the existing staff details
            nameEntry.Text = _staff.Name;
            phoneEntry.Text = _staff.Phone;
            addressEntry.Text = _staff.Address;

            // Populate the department picker with existing and new departments
            foreach (var department in _viewModel.Departments)
            {
                departmentPicker.Items.Add(department.Name);
            }
            departmentPicker.SelectedIndex = _staff.DepartmentId - 1; // Adjust for 0-based index
        }

        private void OnUpdateClicked(object sender, System.EventArgs e)
        {
            // Update the existing staff details
            _staff.Name = nameEntry.Text;
            _staff.Phone = phoneEntry.Text;
            _staff.DepartmentId = _viewModel.Departments[departmentPicker.SelectedIndex].Id;
            _staff.Address = addressEntry.Text;

            // Update the staff details in the ViewModel 
            _viewModel.UpdateStaff(_staff);

            // Navigate to a new instance of StaffProfileDetailsPage with the updated staff
            Navigation.PushAsync(new StaffProfileDetailsPage(_staff, _viewModel));
        }

        private void OnCancelClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(); // Cancel and navigate back
        }
    }
}
