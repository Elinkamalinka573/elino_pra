using System.Windows;
using System.Windows.Controls;

namespace pract_ima
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void BtnDevices_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу устройств
            NavigationService.Navigate(new DevicesPage());
        }

        private void BtnAutomation_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу автоматизации
            NavigationService.Navigate(new AutomationPage());
        }
    }
}