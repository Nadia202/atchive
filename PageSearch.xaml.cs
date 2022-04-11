using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PP
{
    /// <summary>
    /// Логика взаимодействия для PageSearch.xaml
    /// </summary>
    public partial class PageSearch : Page
    {
        DBPP dbpp;
        public static int idDoc { get; set; }
        public static long idOrg { get; set; }
        public PageSearch()
        {
            InitializeComponent();
            dbpp = new DBPP();
            if (idOrg != 0)
            {
                innTextBox.Text = idOrg.ToString();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PageAuthorization.xaml", UriKind.Relative));
        }

        private void innTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text,0))
            {
                e.Handled = true;
            }
        }

        private void btnAddOrganization_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PageAddOrganization.xaml", UriKind.Relative));
        }

        private void innTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (innTextBox.Text == "")
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(innTextBox, "Нет организаций с данным ИНН");
                infoOrgTextBlock.Text = "";
                btnAddDocument.IsEnabled = false;
                listBoxDoc.ItemsSource = null;
                return;
            }
            idOrg = Convert.ToInt64(innTextBox.Text);
            var organization = (from org in dbpp.Organizations where org.id == idOrg select org).ToList();
            Organizations o = new Organizations();
            if (organization.Count == 0)
            {

                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(innTextBox, "Нет организаций с данным ИНН");
                infoOrgTextBlock.Text = "";
                btnAddDocument.IsEnabled = false;
                listBoxDoc.ItemsSource = null;
                return;
            }
            if (organization.Count > 0)
            {
                btnAddDocument.IsEnabled = true;
            }
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(innTextBox, "");
            o = organization.First();
            var opf = (from t in dbpp.TypeOPF where t.id == o.opf select t).ToList();
            infoOrgTextBlock.Text = opf.First().type + "\"" + o.name + "\"" + "\n" + "Руководитель: " + o.director + "\n" + "Зарегистрирован по адресу: " + o.address + "\n" + "КПП: " + o.kpp + "\n" + "ОГРН: " + o.ogrn;
            var documents = (from p in dbpp.Pages where p.page == 1
                             join d in dbpp.Documents on p.document equals d.id
                             join t in dbpp.TypeDocument on d.type equals t.id
                             select new
                             {
                                 organization = d.organization,
                                 photo = p.photo,
                                 document = t.type,
                                 date = d.date
                             }).Where(p => p.organization == idOrg).ToList(); 
            listBoxDoc.ItemsSource = documents;
        }

        private void btnAddDocument_Click(object sender, RoutedEventArgs e)
        {
            idOrg = Convert.ToInt64(innTextBox.Text);
            this.NavigationService.Navigate(new Uri("PageAddDocument.xaml", UriKind.Relative));
        }

        private void documentItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            idDoc = 15;
            this.NavigationService.Navigate(new Uri("PageAddDocument.xaml", UriKind.Relative));
        }
    }  
}
