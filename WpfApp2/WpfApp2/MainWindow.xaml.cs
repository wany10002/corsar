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
using System.Collections.ObjectModel;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // Создаем заглушку данных для отображения в DataGrid
            productDataGrid.ItemsSource = new[]
            {
                new { ProductName = "Молоко", Quantity = 100, suplies = "Андрей" },
                new { ProductName = "хлеб", Quantity = 200,  suplies = "Андрей"}
            };
        }

        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null)
            {
                dynamic selectedProduct = productDataGrid.SelectedItem;
                selectedProduct.ProductName = productNameTextBox.Text;
                productDataGrid.Items.Refresh();
            }
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null && int.TryParse(quantityTextBox.Text, out int quantity))
            {
                dynamic selectedProduct = productDataGrid.SelectedItem;
                selectedProduct.Quantity = quantity;
                productDataGrid.Items.Refresh();
            }
        }

        private void SuplesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null && int.TryParse(quantityTextBox.Text, out int quantity))
            {
                dynamic selectedProduct = productDataGrid.SelectedItem;
                selectedProduct.Quantity = quantity;
                productDataGrid.Items.Refresh();
            }
        }
        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(productNameTextBox.Text) && int.TryParse(quantityTextBox.Text, out int quantity))
            {
                // Создание нового объекта данных запросом с введенными значениями
                var newProduct = new { ProductName = productNameTextBox.Text, Quantity = quantity };

                // Добавление нового объекта данных в источник данных DataGrid
                productDataGrid.Items.Add(newProduct);

                // Очистка полей после добавления
                productNameTextBox.Text = "";
                quantityTextBox.Text = "";
                suplesTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Введите корректные значения для добавления.");
            }
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null)
            {
                // Удаление выбранной строки из DataGrid
                productDataGrid.Items.Remove(productDataGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.");
            }
        }
    }
}
