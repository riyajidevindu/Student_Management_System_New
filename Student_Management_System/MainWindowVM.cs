using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Management_System.Model;
using Student_Management_System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Student_Management_System
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;





        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new StudentInsertWindowVM();
            vm.title = "ADD USER";
            StudentInsertWindow window = new StudentInsertWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                students.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedStudent != null)
            {
                var vm = new StudentInsertWindowVM(selectedStudent);
                vm.title = "EDIT USER";
                var window = new StudentInsertWindow(vm);

                window.ShowDialog();


                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        [RelayCommand]
        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void MinimizedMainWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        public void MaximizedMainWindow()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();


            DateTime date1 = new DateTime(2000, 04, 19);
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            students.Add(new Student(4184, "Riyaji", "Devindu", date1, 3.56, image1));

            DateTime date2 = new DateTime(2000, 01, 11);
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            students.Add(new Student(4185, "Sahaswari", "Samoda", date2, 3.46, image2));





        }


    }
}
