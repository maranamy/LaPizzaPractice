using LaPizzaPractice.Models;
using LaPizzaPractice.Pages.UserPages;
using LaPizzaPractice.Service;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LaPizzaPractice.Pages.Common
{
    /// <summary>
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        private string userRole = "";
        public AuthoPage()
        {
            InitializeComponent();
        }

        private void btn_Enter(object sender, RoutedEventArgs e)
        {
            var db = DbContextFactory.GetContext();
            string login = tbxLogin.Text.Trim();
            string password = tbxPassword.Text.Trim();

            bool isPhone = Regex.IsMatch(login, @"^\+7\d{10}$");

            if (isPhone)
            {
                userRole = "клиент";
                var client = db.UserAuthoSet.Where(w => w.ClientPhone == login &&
                w.Password == password).FirstOrDefault();
                if (client != null) LoadUserPage(userRole, client);
                else MessageBox.Show("Вы ввели логин или пароль неверно!");
            }
            else
            {
                var worker = db.WorkerAuthoSet.Where(w => w.Login == login &&
                w.Password == password).FirstOrDefault();
                if (worker != null)
                {
                    userRole = RoleIs(worker);
                    LoadWorkerPage(userRole, worker);
                }
                else MessageBox.Show("Вы ввели логин или пароль неверно!");
            }
        }

        public string RoleIs(WorkerAuthoriz user)
        {
            var db = DbContextFactory.GetContext();
            var worker = db.WorkersSet.Where(x => x.Id == user.Id).FirstOrDefault();
            string role = db.RolesSet.Where(x => x.Id == worker.RoleId).FirstOrDefault().RoleName;
            return role;
        }

        private void LoadWorkerPage(string role, WorkerAuthoriz user)
        {
            switch (role)
            {
                case "Курьер":
                    MessageBox.Show("У вашей роли пока что нет необходимого функционала в системе\n" +
                        $"Роль: {role}");
                    break;
                case "Менеджер":
                    //NavigationService.Navigate(new AgentPage(user, role));
                    //MessageBox.Show("Вы вошли как:" + role);
                    break;
                case "Пиццамейкер":
                    MessageBox.Show("У вашей роли пока что нет необходимого функционала в системе\n" +
                        $"Роль: {role}");
                    break;
                case "Управляющий":
                    //NavigationService.Navigate(new AgentPage(user, role));
                    //MessageBox.Show("Вы вошли как:" + role);
                    break;
                case "Шеф":
                    //NavigationService.Navigate(new AgentPage(user, role));
                    //MessageBox.Show("Вы вошли как:" + role);
                    break;
            }
        }

        private void LoadUserPage(string role, UserAuthoriz user)
        {
            NavigationService.Navigate(new MainUserPage(user));
            //MessageBox.Show("Вы вошли как:" + role);
        }
    }
}
