using LaPizzaPractice.Dto;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaPizzaPractice.Factory;
using Microsoft.EntityFrameworkCore;

namespace LaPizzaPractice.Pages.BossPages
{
    /// <summary>
    /// Логика взаимодействия для AllWorkers.xaml
    /// </summary>
    public partial class AllWorkers : Page
    {
        private List<WorkerDto> allWorkers = new List<WorkerDto>();
        public AllWorkers()
        {
            InitializeComponent();
            LoadWorkers();
        }

        public void LoadWorkers()
        {
            using var db = DbContextFactory.GetContext();
            var workers = db.WorkersSet
                .ToList();

            var persdate = db.WorkerPersDataSet
                .Include(w => w.Worker)
                .ToList();


            foreach (var w in workers)
            {
                var display = new WorkerDto
                {
                    Id = w.Id,
                    Name = w.WorkerName,
                    Surname = w.WorkerSurn,
                    Role = db.RolesSet.Find(w.RoleId)?.RoleName,
                    Phone = db.WorkerPersDataSet.FirstOrDefault(w => w.WorkerId == w.Id)?.WorkerPhone,
                    Email = db.WorkerPersDataSet.FirstOrDefault(w => w.WorkerId==w.Id)?.Email,
                    Login = db.WorkerAuthoSet.FirstOrDefault(w => w.WorkerId == w.Id)?.Login,
                    Password = db.WorkerAuthoSet.FirstOrDefault(w => w.WorkerId == w.Id)?.Password,
                };
                allWorkers.Add(display);
            }
            workerItemsControl.ItemsSource = allWorkers;
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditWorker_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is WorkerDto workerDto)
            {
                var window = new CreateEditWorker(false, workerDto); // передаём существующий объект
                window.Owner = Window.GetWindow(this);
                window.ShowDialog();
                LoadWorkers(); // обновляем список
            }
        }

        private void DeleteWorker_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
