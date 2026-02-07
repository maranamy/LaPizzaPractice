using LaPizzaPractice.Dto;
using LaPizzaPractice.Factory;
using LaPizzaPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaPizzaPractice.Pages.BossPages
{
    /// <summary>
    /// Логика взаимодействия для CreateEditWorker.xaml
    /// </summary>
    public partial class CreateEditWorker : Window
    {
        private bool isNew;
        public CreateEditWorker(bool status, WorkerDto worker)
        {
            InitializeComponent();

            var db = DbContextFactory.GetContext();
            isNew = status;
            cmbRole.ItemsSource = db.RolesSet.ToList();
            cmbRole.DisplayMemberPath = "RoleName";
            cmbRole.SelectedValuePath = "Id";
            if (!isNew)
            {
                tbName.Text = worker.Name ?? "";
                tbSurname.Text = worker.Surname ?? "";
                tbPhone.Text = worker.Phone ?? "";
                tbEmail.Text = worker.Email ?? "";
                tbLogin.Text = worker.Login ?? "";
                pbPassword.Text = worker.Password ?? "";
                cmbRole.SelectedIndex = db.RolesSet.FirstOrDefault(r => r.RoleName == worker.Role).Id;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
