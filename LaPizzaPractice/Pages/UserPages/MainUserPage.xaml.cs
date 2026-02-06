using LaPizzaPractice.Models;
using LaPizzaPractice.Service;
using Microsoft.EntityFrameworkCore;
using LaPizzaPractice.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaPizzaPractice.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для MainUserPage.xaml
    /// </summary>
    public partial class MainUserPage : Page
    {
        private List<Products> allPizza = new List<Products>();
        private UserAuthoriz client = new UserAuthoriz();
        public MainUserPage(UserAuthoriz user)
        {
            InitializeComponent();
            LoadPizzas();
            client = user;
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

        private void GoProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(client));
        }
    }
}
