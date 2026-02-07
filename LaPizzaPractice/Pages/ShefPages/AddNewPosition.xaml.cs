using LaPizzaPractice.Models;
using LaPizzaPractice.Factory;
using Microsoft.EntityFrameworkCore;
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
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.IO;

namespace LaPizzaPractice.Pages.ShefPages
{
    /// <summary>
    /// Логика взаимодействия для AddNewPosition.xaml
    /// </summary>
    public partial class AddNewPosition : Window
    {

        private readonly bool isNew;
        private Products? pizzaModel;
        private List<Categories> _categories = new List<Categories>();
        public AddNewPosition(bool status, Products? pizza)
        {
            InitializeComponent();
            isNew = status;
            pizzaModel = pizza;
            LoadData();
        }

        public void LoadData()
        {
            var db = DbContextFactory.GetContext();
            _categories = db.CategoriesSet.ToList();

            chooseCategory.ItemsSource = _categories;
            chooseCategory.DisplayMemberPath = "CategoryName";
            chooseCategory.SelectedValuePath = "Id";
            if (pizzaModel != null)
            {
                chooseCategory.SelectedIndex = pizzaModel.CategoryId-1;

                namePizza.Text = pizzaModel.PizzaName?.ToString();
                pricePizza.Text = pizzaModel.Price.ToString();
                filling.Text = pizzaModel.FillingDescr?.ToString().Trim();
                size.Text = pizzaModel.PizzaSize?.ToString();
            }
        }

        private void SavePizza()
        {
            using var db = DbContextFactory.GetContext();

            string name = namePizza.Text?.Trim() ?? "";
            string fill = filling.Text?.Trim() ?? "";
            string sizeStr = size.Text?.Trim() ?? "";
            string priceStr = pricePizza.Text?.Trim() ?? "";
            int categoryIndex = chooseCategory.SelectedIndex;

            var errors = new List<string>();

            // 1. Название пиццы
            if (string.IsNullOrWhiteSpace(name))errors.Add("Введите название пиццы");
            else if (name.Length < 2) errors.Add("Название пиццы слишком короткое");

            // 2. Категория
            if (categoryIndex < 0) errors.Add("Выберите категорию");

            // 3. Размер
            if (string.IsNullOrWhiteSpace(sizeStr)) errors.Add("Укажите размер пиццы");

            // 4. Цена
            if (string.IsNullOrWhiteSpace(priceStr)) errors.Add("Введите цену");
            else if (!decimal.TryParse(priceStr, out decimal price) || price <= 0)
            {
                errors.Add("Цена должна быть положительным числом");
            }

            // 5. Описание начинки 
            if (string.IsNullOrWhiteSpace(fill))errors.Add("Опишите начинку");

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
                if (pizzaModel == null)
                {
                    db.ProductsSet.Add(new Products
                    {
                        PizzaName = name,
                        CategoryId = categoryIndex - 1,
                        Price = Convert.ToDecimal(priceStr),
                        FillingDescr = fill,
                        PizzaSize = sizeStr
                    });

                }
                else
                {
                    // находим существующий и обновляем
                    var existing = db.ProductsSet.Find(pizzaModel.Id);
                    if (existing == null)
                    {
                        MessageBox.Show("Запись не найдена");
                        return;
                    }

                    existing.PizzaName = name;
                    existing.CategoryId = categoryIndex - 1;
                    existing.Price = Convert.ToDecimal(priceStr);
                    existing.FillingDescr = fill;
                    existing.PizzaSize = sizeStr;
                }

                try
                {

                    //if (isNew) db.ProductsSet.Add(pizzaModel);
                    db.SaveChanges();
                    MessageBox.Show(isNew ? "Пицца добавлена" : "Пицца обновлена");
                    this.Close();

                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Ошибка сохранения:\n{ex.InnerException?.Message ?? ex.Message}");
                }
            }

            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SavePizza();
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
