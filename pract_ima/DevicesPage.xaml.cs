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
using System.Data.Entity;

namespace pract_ima
{
    public partial class DevicesPage : Page
    {
        private elinoEntities _context;

        public DevicesPage()
        {
            InitializeComponent();
            _context = new elinoEntities();
            LoadRooms();
            LoadDevices();
        }

        private void LoadRooms()
        {
            try
            {
                var rooms = _context.Комнаты.ToList();
                RoomFilter.Items.Add("Все");
                foreach (var room in rooms)
                {
                    RoomFilter.Items.Add(room.Название);
                }
                RoomFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                StatusText.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void LoadDevices()
        {
            try
            {
                var devices = _context.Устройства
                    .Include(d => d.Комнаты)
                    .ToList();
                DevicesListView.ItemsSource = devices;
                StatusText.Text = $"Загружено устройств: {devices.Count}";
            }
            catch (Exception ex)
            {
                StatusText.Text = $"Ошибка: {ex.Message}";
                MessageBox.Show("Ошибка подключения к БД: " + ex.Message);
            }
        }

        private void RoomFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomFilter.SelectedItem == null) return;
            string selectedRoom = RoomFilter.SelectedItem.ToString();

            try
            {
                if (selectedRoom == "Все")
                {
                    LoadDevices();
                }
                else
                {
                    var filtered = _context.Устройства
                        .Include(d => d.Комнаты)
                        .Where(d => d.Комнаты.Название == selectedRoom)
                        .ToList();
                    DevicesListView.ItemsSource = filtered;
                    StatusText.Text = $"Загружено: {filtered.Count} (комната: {selectedRoom})";
                }
            }
            catch (Exception ex)
            {
                StatusText.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadDevices();
            if (RoomFilter.Items.Count > 0)
                RoomFilter.SelectedIndex = 0;
        }
    }
}