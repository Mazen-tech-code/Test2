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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        FaculatyMSEntities db = new FaculatyMSEntities();
        public Admin()
        {
            InitializeComponent();
            ShowData();
        }
        public void ShowData()
        {
            var data = db.Students.Select(x => new
            {
                x.student_ID,
                x.student_Name,
                x.student_address,
                department = x.Department.dep_Name,
            }).ToList();
            db.SaveChanges();
            DG.ItemsSource = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(ID_txt.Text);
            var rec = db.Students.FirstOrDefault(x => x.student_ID == id);
            if (rec != null)
            {
                db.Students.Remove(rec);
                db.SaveChanges();
                ShowData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(ID_txt.Text);
            var rec = db.Students.FirstOrDefault(x => x.student_ID == id);
            if (rec != null)
            {
                rec.Department.dep_Name = Dep_txt.Text;
                db.Students.AddOrUpdate(rec);
                db.SaveChanges();
                ShowData();
            }
            else
            {
                MessageBox.Show("Edit not completed");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}