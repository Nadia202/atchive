using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageAddDocument.xaml
    /// </summary>
    public partial class PageAddDocument : Page
    {
        DBPP dbpp;
        int number;
        int idDoc;
        Documents d;
        public PageAddDocument()
        {
            InitializeComponent();
            dbpp = new DBPP();
            typeComboBox.ItemsSource = dbpp.TypeDocument.ToList();
            number = 1;
            idDoc = PageSearch.idDoc;
            if (idDoc != 0)
            {
                Documents doc = (from d in dbpp.Documents where d.id == idDoc select d).First();
                typeComboBox.SelectedIndex = doc.type;
                typeComboBox.IsEnabled = false;
                datePicker.Text = doc.date.ToString();
                datePicker.IsEnabled = false;
                btnCreate.IsEnabled = false;
                UpdateList();
            }
        }
        
        private void UpdateList()
        {
            if (d == null)
            {
                return;
            }
            listBoxAddPage.ItemsSource = dbpp.Pages.Where(x => x.document == d.id).ToList();
        }

        private void btnExit_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PageSearch.xaml", UriKind.Relative));
        }

        private void btnAddPage_Click(object sender, RoutedEventArgs e)
        {
            int id = d.id;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Картинка форматов jpg, png|*.jpg; *.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                byte[] image = File.ReadAllBytes(nameFile);
                Pages p = new Pages
                {
                    document = id,
                    page = number,
                    photo = image
                };
                dbpp.Pages.Add(p);
                dbpp.SaveChanges();
            }
            number++;
            UpdateList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            number = 1;
            if (typeComboBox.SelectedIndex == -1)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(typeComboBox, "Поле не заполнено");
                return;
            }
            else
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(typeComboBox, "");

            if (datePicker.Text == "")
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(datePicker, "Поле не заполнено");
                return;
            }
            else
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(typeComboBox, "");

            d = new Documents
            {
                organization = PageSearch.idOrg,
                type = typeComboBox.SelectedIndex,
                date = Convert.ToDateTime(datePicker.Text)
            };
            dbpp.Documents.Add(d);
            dbpp.SaveChanges();
            btnAddPage.IsEnabled = true;
            btnCreate.IsEnabled = false;
            typeComboBox.IsEnabled = false;
            datePicker.IsEnabled = false;
        }
    }
}