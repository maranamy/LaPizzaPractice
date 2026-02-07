using LaPizzaPractice.Dto;
using LaPizzaPractice.Factory;
using LaPizzaPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace LaPizzaPractice.Pages.ShefPages
{
    /// <summary>
    /// Логика взаимодействия для OrdersToCook.xaml
    /// </summary>
    public partial class OrdersToCook : Page
    {
        private List<OrderDto> _newOrders = new();
        private List<OrderDto> inProgressOrders = new();
        private List<OrderDto> _readyOrders = new();
        public OrdersToCook()
        {
            InitializeComponent();       
            LoadOrders();
        }

        private void LoadOrders()
        {
            using var db = DbContextFactory.GetContext();

            var orders = db.OrdersSet
                .Include(o => o.DelivAddress)
                .Where(o => o.IsActive)
                .ToList();

            _newOrders.Clear();
            inProgressOrders.Clear();
            _readyOrders.Clear();

            foreach (var order in orders)
            {
                var display = new OrderDto
                {
                    Id = order.Id,
                    PizzaName = order.ProductName ?? "—",       
                    Quantity = order.Quantity,
                    Cost = order.Cost,
                    StatusId = order.StatusId,
                    FullAddress = FormatFullAddress(order.DelivAddress)
                };

                switch (order.StatusId)
                {
                    case 1: _newOrders.Add(display); break;
                    case 2: inProgressOrders.Add(display); break;
                    case 3: _readyOrders.Add(display); break;
                }
            }

            newOrders.ItemsSource = _newOrders;
            isInProgress.ItemsSource = inProgressOrders;
            isReady.ItemsSource = _readyOrders;
        }

        private string FormatFullAddress(Address addr)
        {
            if (addr == null) return "Адрес не указан";

            var parts = new List<string>
            {
                addr.CityName,
                addr.StreetName,
                $"д. {addr.HouseNumber}"
            };

            if (!string.IsNullOrEmpty(addr.FlatNumber))
                parts.Add($"кв. {addr.FlatNumber}");

            return string.Join(", ", parts);
        }

        private void BtnCook_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int orderId)
            {
                ChangeStatus(orderId, 2); // например → "Готовится"
                LoadOrders();
            }
        }

        // Кнопка "Готов"
        private void BtnReady_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int orderId)
            {
                ChangeStatus(orderId, 3); // → "Готов к выдаче"
                LoadOrders();
            }
        }

        private void ChangeStatus(int orderId, int newStatusId)
        {
            using var db = DbContextFactory.GetContext();
            var order = db.OrdersSet.Find(orderId);
            if (order != null)
            {
                order.StatusId = newStatusId;
                db.SaveChanges();
            }
        }

        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ShowNewOrders(object sender, RoutedEventArgs e)
        {
            gridNew.Visibility = Visibility.Visible;
            gridInProgress.Visibility = Visibility.Collapsed;
            gridReady.Visibility = Visibility.Collapsed;
        }

        private void ShowInProgress(object sender, RoutedEventArgs e)
        {
            gridNew.Visibility = Visibility.Collapsed;
            gridInProgress.Visibility = Visibility.Visible;
            gridReady.Visibility = Visibility.Collapsed;
        }

        private void ShowReady(object sender, RoutedEventArgs e)
        {
            gridNew.Visibility = Visibility.Collapsed;
            gridInProgress.Visibility = Visibility.Collapsed;
            gridReady.Visibility = Visibility.Visible;
        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            using var db = DbContextFactory.GetContext();
            if (sender is Button button && button.Tag is OrderDto order)
            {
                var existing = db.OrdersSet.Find(order.Id);
                if (existing == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }

                existing.StatusId = 3;
                try
                {
                    db.SaveChanges();
                    LoadOrders();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Ошибка сохранения:\n{ex.InnerException?.Message ?? ex.Message}");
                }
            }
            
        }

        private void CookButton_Click(object sender, RoutedEventArgs e)
        {
            using var db = DbContextFactory.GetContext();
            if (sender is Button button && button.Tag is OrderDto order)
            {
                var existing = db.OrdersSet.Find(order.Id);
                if (existing == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }

                existing.StatusId = 2;
                try
                {
                    db.SaveChanges();
                    LoadOrders();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Ошибка сохранения:\n{ex.InnerException?.Message ?? ex.Message}");
                }
            }
            
        }
    }
}
