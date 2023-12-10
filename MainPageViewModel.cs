﻿using System.Collections.ObjectModel;

namespace Project2
{
    public class MainPageViewModel
    {
        public ObservableCollection<Staff> StaffList { get; set; } = new ObservableCollection<Staff>();
        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();
        public MainPageViewModel()
        {
            // Populate Departments
            Departments.Add(new Department { Id = 1, Name = "General" });
            Departments.Add(new Department { Id = 2, Name = "Information Communications Technology" });
            Departments.Add(new Department { Id = 3, Name = "Finance" });
            Departments.Add(new Department { Id = 4, Name = "Marketing" });
            Departments.Add(new Department { Id = 5, Name = "Human Resources" });

            // Populate StaffList
            StaffList.Add(new Staff { Id = 1, Name = "John Smith", Phone = "02 9988 2211", DepartmentId = 1, Address = "1 Code Lane, Javaville, NSW 0100, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\placeholder_male.png" });
            StaffList.Add(new Staff { Id = 2, Name = "Sue White", Phone = "03 8899 2255", DepartmentId = 2, Address = "16 Bit Way, Byte Cove, QLD 1101, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\placeholder_female.png" });
            StaffList.Add(new Staff { Id = 3, Name = "Bob O’Bits", Phone = "05 7788 2255", DepartmentId = 3, Address = "8 Silicon Road, Cloud Hills, VIC 1001, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\placeholder_male.png" });
            StaffList.Add(new Staff { Id = 4, Name = "Mary Blue", Phone = "06 4455 9988", DepartmentId = 2, Address = "4 Processor Boulevard, Appletson, NT 1010, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\placeholder_female.png" });
            StaffList.Add(new Staff { Id = 5, Name = "Mick Green", Phone = "02 9988 1122", DepartmentId = 3, Address = "700 Bandwidth Street, Bufferland, NSW 0110, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\placeholder_male.png" });
            StaffList.Add(new Staff { Id = 5, Name = "Allen Chi", Phone = "02 9988 8888", DepartmentId = 3, Address = "249 Georget Street, Waterloo, NSW 2017, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\Jobs.png" });
            StaffList.Add(new Staff { Id = 5, Name = "Shanglun Chi", Phone = "02 9988 6666", DepartmentId = 3, Address = "100 Sheperd Street, Chippendale, NSW 2008, Australia", PhotoPath = "C:\\Users\\allen\\OneDrive\\TAFE IT Programming 2023\\Semester 2\\Mobile Dev Shaun\\Assessments\\Pro2\\Images\\Musk.png" });
        }

        //add a generic UpdateStaff method to the MainPageViewModel class to handle updating staff details.
        public void UpdateStaff(Staff updatedStaff)
        {
            // Find the existing staff in the StaffList and update its details
            var existingStaff = StaffList.FirstOrDefault(s => s.Id == updatedStaff.Id);
            if (existingStaff != null)
            {
                existingStaff.Name = updatedStaff.Name;
                existingStaff.Phone = updatedStaff.Phone;
                existingStaff.DepartmentId = updatedStaff.DepartmentId;
                existingStaff.Address = updatedStaff.Address;
            }
        }

        public void SaveStaff(Staff staff)
        {
            // Implement actual saving logic here, e.g., calling a service or repository
            // For demonstration purposes, add the staff directly to the StaffList
            StaffList.Add(staff);
        }
    }
}
