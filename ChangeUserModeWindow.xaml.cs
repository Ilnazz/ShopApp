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
using System.Windows.Shapes;

namespace ShopApp
{
    /// <summary>
    /// Логика взаимодействия для ChangeUserModeWindow.xaml
    /// </summary>
    public partial class ChangeUserModeWindow : Window
    {
        public ChangeUserModeWindow()
        {
            InitializeComponent();
        }

        private void Button_Authorize_Click(object sender, RoutedEventArgs e)
        {
            if (CodeBox.Text == "0000")
            {
                App.CurrentUserMode = UserMode.Administrator;
                MessageBox.Show("Вы перешли в режим администратора.");
            }
            else
                MessageBox.Show("Вы ввели неверный пароль.");
            Close();
        }
    }
}
