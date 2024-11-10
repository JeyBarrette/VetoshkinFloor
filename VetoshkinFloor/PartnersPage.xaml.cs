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

namespace VetoshkinFloor
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            InitializeComponent();
            var currentPartner = VetoshkinFloorMasterEntities.GetContext().Partners.ToList();
            PartnersListView.ItemsSource = currentPartner;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var currentPartner = VetoshkinFloorMasterEntities.GetContext().Partners.ToList();
            PartnersListView.ItemsSource = currentPartner;
        }

        private void AddPartnerBTN_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPartnerPage(null));
        }

        private void EditPartnerBTN_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPartnerPage((sender as Button).DataContext as Partners));
        }
    }
}
