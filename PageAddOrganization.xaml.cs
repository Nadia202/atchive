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

namespace PP
{
    /// <summary>
    /// Логика взаимодействия для PageAddOrganization.xaml
    /// </summary>
    public partial class PageAddOrganization : Page
    {
        DBPP dbpp;
        public PageAddOrganization()
        {
            InitializeComponent();
            dbpp = new DBPP();
            opfComboBox.ItemsSource = dbpp.TypeOPF.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DBPP pp = new DBPP();
            Organizations organizations;
            if (innTextBox.Text != "" && innTextBox.Text.Length == 10 && directorTextBox.Text != "" && opfComboBox.SelectedIndex != -1 && nameTextBox.Text != "" && addressTextBox.Text != "")
            {
                organizations = new Organizations
                {
                    id = Convert.ToInt64(innTextBox.Text),
                    director = directorTextBox.Text,
                    opf = opfComboBox.SelectedIndex,
                    name = nameTextBox.Text,
                    kpp = Convert.ToInt64(kppTextBox.Text),
                    ogrn = Convert.ToInt64(ogrnTextBox.Text),
                    address = addressTextBox.Text
                };
                pp.Organizations.Add(organizations);
                pp.SaveChanges();
                PageSearch.idOrg = organizations.id;
                this.NavigationService.Navigate(new Uri("PageSearch.xaml", UriKind.Relative));
                return;
            }
            if (innTextBox.Text == "" || innTextBox.Text.Length < 10)
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(innTextBox, "Поле не заполнено");
            else
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(innTextBox, "");

            if (directorTextBox.Text == "")
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(directorTextBox, "Поле не заполнено");
            else
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(directorTextBox, "");

            if (opfComboBox.SelectedIndex == -1)
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(opfComboBox, "Поле не заполнено");
            else 
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(opfComboBox, "");

            if (nameTextBox.Text == "")
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(nameTextBox, "Поле не заполнено");
            else
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(nameTextBox, "");

            if (addressTextBox.Text == "")
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(addressTextBox, "Поле не заполнено");
            else
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(addressTextBox, "");
        }

        private void number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PageSearch.xaml", UriKind.Relative));
        }
    }
}
