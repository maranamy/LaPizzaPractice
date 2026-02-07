using LaPizzaPractice.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaPizzaPractice.Factory;

namespace LaPizzaPractice.Pages.BossPages
{
    /// <summary>
    /// Логика взаимодействия для MenuNotFun.xaml
    /// </summary>
    public partial class MenuNotFun : Page
    {
        private List<Products> allPizza = new List<Products>();
        public MenuNotFun()
        {
            InitializeComponent();
            LoadPizzas();
        }

        private void LoadPizzas()
        {
            using var db = DbContextFactory.GetContext();

            allPizza = db.ProductsSet
                .Include(p => p.Category)
                .ToList();

            foodItemsControl.ItemsSource = allPizza;
        }
        private void GoToWorkers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWorkers());
        }
    }
}
