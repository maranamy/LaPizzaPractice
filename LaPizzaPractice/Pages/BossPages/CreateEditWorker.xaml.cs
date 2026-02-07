using LaPizzaPractice.Dto;
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
        public CreateEditWorker(WorkerDto worker)
        {
            InitializeComponent(); InitializeComponent();
            //isNew = existing == null;
            //worker = existing ?? new WorkerDisplay();

            //if (!isNew)
            //{
            //    tbName.Text = worker.Name ?? "";
            //    tbSurname.Text = worker.Surname ?? "";
            //    tbPhone.Text = worker.Phone ?? "";
            //    tbEmail.Text = worker.Email ?? "";
            //    tbLogin.Text = worker.Login ?? "";
            //    // tbPassword — не заполняем (оставляем пустым)
            //    // cmbRole.SelectedValue = ... (если есть роли)
            //}
        }
    }
}
