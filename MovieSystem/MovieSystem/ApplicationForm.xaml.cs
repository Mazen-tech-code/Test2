using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Migrations;

namespace MovieSystem
{
    /// <summary>
    /// Interaction logic for ApplicationForm.xaml
    /// </summary>
    public partial class ApplicationForm : Page
    {
        FaculatyMSEntities db = new FaculatyMSEntities();
        string stud_email;
        public ApplicationForm(string email)
        {
            InitializeComponent();
            string stud_email = email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = db.Students.FirstOrDefault(x => x.student_Email == stud_email);
            if (result != null)
            {
                Student student = new Student();
                var depp = db.Departments.FirstOrDefault(x => x.dep_Name == Department_txt.Text);
                if (depp != null)
                {
                    result.student_address = Address_txt.Text;
                    result.student_Name = Name_txt.Text;
                    result.student_Age = int.Parse(Age_txt.Text);
                    result.dep_ID = depp.dep_ID;
                    db.Students.AddOrUpdate(result);
                    db.SaveChanges();
                }
            }
        }
    }
}
