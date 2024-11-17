using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace MovieSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        FaculatyMSEntities db = new FaculatyMSEntities();

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            string A_email = "Admin";
            string A_Password = "admin123";
            Student student = new Student();
            var rec = db.Students.FirstOrDefault(x => x.student_Email == lgn_Emailtxt.Text);
            if (rec != null && A_email != lgn_Emailtxt.Text)
            {
                ApplicationForm applicationForm = new ApplicationForm(lgn_Emailtxt.Text);
                NavigationService.Navigate(applicationForm);
            }
            else if (A_email == lgn_Emailtxt.Text && A_Password == lgn_Passtxt.Text)
            {
                Admin admin = new Admin();
                NavigationService.Navigate(admin);
            }
            else
            {
                MessageBox.Show("You must sign up first");
                SignUp signUp = new SignUp();
                NavigationService.Navigate(signUp);
            }
        }
    }
}
