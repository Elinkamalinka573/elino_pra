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

namespace pract_ima
{
    public partial class AutomationPage : Page
    {
        private elinoEntities _context;

        public AutomationPage()
        {
            InitializeComponent();
            _context = new elinoEntities();
            LoadRules();
        }

        private void LoadRules()
        {
            try
            {
                var rules = _context.Правила_автоматизации.ToList();
                RulesListView.ItemsSource = rules;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void AddRule_Click(object sender, RoutedEventArgs e)
        {
            // TODO: окно добавления правила
            MessageBox.Show("Добавление нового правила");
        }
    }
}