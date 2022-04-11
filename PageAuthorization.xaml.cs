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
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;

namespace PP
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            DBPP pp = new DBPP();
            bool l = false;
            bool p = false;
            var users = pp.Users;
            foreach (Users u in users)
            {
                if (login == u.login)
                {
                    l = true;
                }
                if (password == u.password)
                {
                    p = true;
                }
            }
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(loginTextBox, "");
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(passwordTextBox, "");

            if (l == true && p == true)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(loginTextBox, "");
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(passwordTextBox, "");
                this.NavigationService.Navigate(new Uri("PageSearch.xaml", UriKind.Relative));
            }
            if (login == "")
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(loginTextBox, "Поле пустое");
                return;
            }
            if (l == false)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(loginTextBox, "Неверный логин");
            }
            if (password == "")
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(passwordTextBox, "Поле пустое");
                return;
            }
            if (l == true && p == false)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(loginTextBox, "");
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(passwordTextBox, "Неверный пароль");
            }
        }
    }
}
