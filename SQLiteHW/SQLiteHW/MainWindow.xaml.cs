
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

namespace SQLiteHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(textBox.Text.ToString());
            MessageBox.Show("Already Add");
        }

        private void showall(object sender, RoutedEventArgs e)
        {
            List<String> getList = DataAccess.GetData();
            string sender_ = "";
            foreach(string i in getList)
            {
                sender_ += i + "\n";
            }
            MessageBox.Show(sender_);
        }

    }
}
