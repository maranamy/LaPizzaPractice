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


namespace LaPizzaPractice.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {

        private UserAuthoriz _client = new UserAuthoriz();
        public ProfilePage(UserAuthoriz user)
        {
            InitializeComponent();
            LoadPizzas();
            _client = user;
        }

        private void LoadPizzas()
        {
            using var db = DbContextFactory.GetContext();

            var client = db.ClientsSet.Where(c => c.Id == _client.Id).FirstOrDefault();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
