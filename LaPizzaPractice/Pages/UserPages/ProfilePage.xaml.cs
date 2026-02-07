using LaPizzaPractice.Models;
using LaPizzaPractice.Factory;
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
        public ProfilePage(UserAuthoriz user)
        {
            InitializeComponent();
            LoadClient(user);
        }

        private void LoadClient(UserAuthoriz user)
        {
            using var db = DbContextFactory.GetContext();

            var client = db.UserAuthoSet.Include(u => u.ClientAutho).FirstOrDefault(c => c.Id == user.Id);

            if (client != null)
            {
                this.DataContext = client;
            }

            else
            {
                this.DataContext = new UserAuthoriz
                {
                    ClientAutho = new Clients(),
                    ClientPhone = "not found"
                };
            }
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
