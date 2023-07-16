using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Management_System.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace Student_Management_System
{
    public partial class StudentInsertWindowVM : ObservableObject

    {
        [ObservableProperty]
        public int indexno;

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public DateTime dateofbirth;

        [ObservableProperty]
        public double gpa;


        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;



        public StudentInsertWindowVM(Student u)
        {
            Student = u;

            indexno = Student.IndexNo;
            firstname = Student.FirstName;
            lastname = Student.LastName;
            dateofbirth = Student.DateOfBirth;
            gpa = Student.GPA;
            selectedImage = Student.Image;

        }
        public StudentInsertWindowVM()
        {

            Dateofbirth = DateTime.Today;
        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }





        public Student Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {
            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (Student == null)
            {

                Student = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    IndexNo = indexno,
                    DateOfBirth = dateofbirth,
                    GPA = gpa,
                    Image = selectedImage
                };

            }
            else
            {
                Student.IndexNo = indexno;
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.DateOfBirth = dateofbirth;
                Student.GPA = gpa;
                Student.Image = selectedImage;
            }

            if (Student.FirstName != null)
            {
                CloseAction();
            }

            Application.Current.MainWindow.Show();


        }


        [RelayCommand]
        public void CloseStudentInsertWindow()
        {
            if (Student == null)
            {

                Student = new Student()
                {
                    FirstName = null,
                    LastName = null,
                    IndexNo = 0,
                    DateOfBirth = DateTime.Today,
                    GPA = 0.00,
                    Image = null
                };

            }
            else
            {
                Student.IndexNo = indexno;
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.DateOfBirth = dateofbirth;
                Student.GPA = gpa;
                Student.Image = selectedImage;
            }


            CloseAction();

            Application.Current.MainWindow.Show();
        }

    }
}
