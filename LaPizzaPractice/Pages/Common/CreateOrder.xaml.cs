using LaPizzaPractice.Factory;
using LaPizzaPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
using System.Xml.Linq;

namespace LaPizzaPractice.Pages.Common
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        private readonly bool isEmpty;
        private List<Products> _products = new List<Products>();

        public class Quantity
        {
            public int num { get; set; }
        }
        private Products? pizzaModel;
        public CreateOrder(bool status, Products pizza, Address address)
        {
            InitializeComponent();
            isEmpty = status;
            pizzaModel = pizza;
            LoadData(pizza, address);
        }

        public void LoadData(Products pizza, Address address)
        {
            var db = DbContextFactory.GetContext();
            _products = db.ProductsSet.ToList();
            choosePizza.ItemsSource = _products;
            choosePizza.DisplayMemberPath = "PizzaName";
            choosePizza.SelectedValuePath = "Id";
            chooseQuantity.ItemsSource = Enumerable.Range(1, 6);
            if (!isEmpty)
            {
                choosePizza.SelectedIndex = pizza.Id - 1;
                chooseAddress.Text = address.CityName + ", " +
                    address.StreetName + ", " +
                    address.HouseNumber + ", " +
                    address.FlatNumber ?? " ";
            }
            chooseQuantity.SelectedIndex = 0;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            SaveOrder();
        }

        private void SaveOrder()
        {
            using var db = DbContextFactory.GetContext();

            int pizzaId = choosePizza.SelectedIndex;
            int quant = chooseQuantity.SelectedIndex;
            string address = chooseAddress.Text?.Trim() ?? "";


            var errors = new List<string>();

            // 1. Название пиццы
            if (string.IsNullOrWhiteSpace(address)) errors.Add("Введите адрес");
            else if (address.Length < 2) errors.Add("Слишком короткий адрес");

            if (pizzaId < 0) errors.Add("Выберите пиццу");
            if (quant < 0) errors.Add("Выберите количество");

            if (errors.Count > 0)
            {
                MessageBox.Show(
                    "Не удалось сохранить:\n\n" +
                    string.Join("\n", errors.Select(err => "• " + err)),
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
            else
            {
                db.OrdersSet.Add(new Orders
                {
                    ProductName = db.ProductsSet.Find(pizzaId).PizzaName,
                    Quantity = quant,
                    StatusId = 1,
                    IsActive = true,
                    Cost = quant * db.ProductsSet.Find(pizzaId).Price,
                    AddressId = 4,
                    Created = DateTime.Now,
                });

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Заказа успешно оформлен");
                    this.Close();

                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Ошибка сохранения:\n{ex.InnerException?.Message ?? ex.Message}");
                }
            }
        }
    }
}
