using System;
using System.Collections.Generic;
using System.Text;
using LaPizzaPractice.Models;
using LaPizzaPractice.Factory;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaPizzaPractice.Pages.ShefPages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    /// 
    public partial class Menu : Page
    {

        private List<Products> allPizza = new List<Products>();
        public Menu(WorkerAuthoriz user)
        {
            InitializeComponent();
            LoadPizzas();
        }

        private void LoadPizzas()
        {
            using var db = DbContextFactory.GetContext();

            // Загружаем пиццы + связанные категории (Include!)
            allPizza = db.ProductsSet
                .Include(p => p.Category)
                .ToList();

            foodItemsControl.ItemsSource = allPizza;
        }

        private void GoToOrders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersToCook());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Products product)
            {
                DeleteProductWithConfirm(product);
            }
        }

        private void DeleteProductWithConfirm(Products product)
        {
            //var pizzaToDelete = allPizza?.FirstOrDefault(p => p.Id == product);
            //string pizzaName = pizzaToDelete?.PizzaName ?? $"ID {product}";

            var result = MessageBox.Show(
                $"Вы действительно хотите удалить пиццу:\n«{product.PizzaName}»?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
            );

            if (result != MessageBoxResult.Yes)
                return;
            else
            {

                try
                {
                    using var db = DbContextFactory.GetContext();

                    if (product == null)
                    {
                        MessageBox.Show("Товар не найден в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var hasOrders = db.OrdersSet.Any(o => o.ProductName == product.PizzaName);
                    if (hasOrders)
                    {
                        MessageBox.Show("Эту пиццу нельзя удалить — на неё уже есть заказы.", "Запрещено", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    db.ProductsSet.Remove(product);
                    db.SaveChanges();

                    // Обновляем список на экране
                    LoadPizzas();
                    // allPizzas.RemoveAll(p => p.Id == productId);
                    // foodItemsControl.ItemsSource = null;
                    // foodItemsControl.ItemsSource = allPizzas;

                    MessageBox.Show("Пицца успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ToChange_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Products product)
            {
                AddNewPosition win = new AddNewPosition(false, product);
                win.Owner = Application.Current.MainWindow;
                win.ShowDialog();
            }
            LoadPizzas();
        }

        private void AddNewPos_Click(object sender, RoutedEventArgs e)
        {
            AddNewPosition win = new AddNewPosition(false, null);
            win.Owner = Application.Current.MainWindow;
            win.ShowDialog();
            LoadPizzas();
        }
    }
}
