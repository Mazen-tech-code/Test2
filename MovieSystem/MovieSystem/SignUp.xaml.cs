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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        FaculatyMSEntities db = new FaculatyMSEntities();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Con_txt.Text == Pass_txt.Text)
            {
                if (db.Students.FirstOrDefault(x => x.student_Email == Email_txt.Text) == null)
                {

                    Student student = new Student();
                    student.student_Name = Name_txt.Text;
                    student.student_Email = Email_txt.Text;
                    student.student_Password = Pass_txt.Text;
                    db.Students.AddOrUpdate(student);
                    db.SaveChanges();
                    Login login = new Login();
                    NavigationService.Navigate(login);
                }
                else
                {
                    MessageBox.Show("Email is already logged in");
                }
            }
            else
            {
                MessageBox.Show("Password not the same");
            }

        }
    }
}
