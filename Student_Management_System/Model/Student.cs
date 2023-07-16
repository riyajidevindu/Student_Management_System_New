using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Student_Management_System.Model
{
    public class Student
    {
        public int IndexNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Model/Images/{Image}"; }
        }

        public Student(int indexno, string firstName, string lastName, DateTime dateOfBirth, double gpa, BitmapImage image)
        {
            IndexNo = indexno;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            GPA = gpa;
            Image = image;

        }

        public Student()
        {
        }
    }
}
