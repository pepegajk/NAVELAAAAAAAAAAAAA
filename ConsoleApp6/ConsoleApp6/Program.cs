using System;
using System.Collections.Generic;
using System.IO;

class Order
{
    private string form;
    private string size;
    private string flavor;
    private int quantity;
    private string icing;
    private string decoration;

    public void StartOrder()
    {
        Console.WriteLine("=== Cake Order Menu ===");
        Console.WriteLine("1. Form");
        Console.WriteLine("2. Size");
        Console.WriteLine("3. Flavor");
        Console.WriteLine("4. Quantity");
        Console.WriteLine("5. Icing");
        Console.WriteLine("6. Decoration");
        Console.WriteLine("Esc. Exit");

        bool exit = false;
        while (!exit)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    ExecuteSelectedMenuItem();
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }
    }

    private void ExecuteSelectedMenuItem()
    {
        Console.Clear();
        Console.WriteLine("=== Selected Option ===");
        Console.WriteLine("1. Form");
        Console.WriteLine("2. Size");
        Console.WriteLine("3. Flavor");
        Console.WriteLine("4. Quantity");
        Console.WriteLine("5. Icing");
        Console.WriteLine("6. Decoration");
        Console.WriteLine("Esc. Exit");

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.Escape:
                Console.Clear();
                StartOrder();
                break;
            case ConsoleKey.D1:
                SelectForm();
                break;
            case ConsoleKey.D2:
                SelectSize();
                break;
            case ConsoleKey.D3:
                SelectFlavor();
                break;
            case ConsoleKey.D4:
                SelectQuantity();
                break;
            case ConsoleKey.D5:
                SelectIcing();
                break;
            case ConsoleKey.D6:
                SelectDecoration();
                break;
            default:
                ExecuteSelectedMenuItem();
                break;
        }
    }

    private void SelectForm()
    {
        Console.WriteLine("=== Select Form ===");
        // Вывод доступных форм тортов

        // Здесь можно реализовать логику выбора формы торта

        ExecuteSelectedMenuItem();
    }

    private void SelectSize()
    {
        Console.WriteLine("=== Select Size ===");
        // Вывод доступных размеров тортов

        // Здесь можно реализовать логику выбора размера торта

        ExecuteSelectedMenuItem();
    }

    private void SelectFlavor()
    {
        Console.WriteLine("=== Select Flavor ===");
        // Вывод доступных вкусов тортов

        // Здесь можно реализовать логику выбора вкуса торта

        ExecuteSelectedMenuItem();
    }

    private void SelectQuantity()
    {
        Console.WriteLine("=== Select Quantity ===");
        // Здесь можно реализовать логику выбора количества тортов

        ExecuteSelectedMenuItem();
    }

    private void SelectIcing()
    {
        Console.WriteLine("=== Select Icing ===");
        // Вывод доступных видов глазурей

        // Здесь можно реализовать логику выбора глазури

        ExecuteSelectedMenuItem();
    }

    private void SelectDecoration()
    {
        Console.WriteLine("=== Select Decoration ===");
        // Вывод доступных вариантов декорации

        // Здесь можно реализовать логику выбора декорации

        ExecuteSelectedMenuItem();
    }

    private void SaveOrderToFile()
    {
        string filePath = "История заказов.txt";
        string orderDetails = $"Form: {form}, Size: {size}, Flavor: {flavor}, Quantity: {quantity}, Icing: {icing}, Decoration: {decoration}";
        string orderSummary = $"Order: {orderDetails}, Total Price: {CalculateTotalPrice()}";

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(orderSummary);
        }
    }

    private decimal CalculateTotalPrice()
    {
        // Здесь можно реализовать расчет общей стоимости заказа на основе выбранных параметров

        return 0; // Вернуть общую стоимость заказа
    }
}

class MenuItem
{
    public string Description { get; set; }
    public decimal Price { get; set; }

    public MenuItem(string description, decimal price)
    {
        Description = description;
        Price = price;
    }
}

class Menu
{
    private List<MenuItem> subMenuItems;

    public Menu(List<MenuItem> items)
    {
        subMenuItems = items;
    }

    public void ExecuteSubMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Submenu ===");

        for (int i = 0; i < subMenuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {subMenuItems[i].Description} - {subMenuItems[i].Price}$");
        }
        Console.WriteLine("Esc. Back to Main Menu");

        bool exit = false;
        while (!exit)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    // Здесь можно обработать выбранный пункт подменю
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<MenuItem> subMenuItems = new List<MenuItem>()
        {
            new MenuItem("Option 1", 10.0m),
            new MenuItem("Option 2", 20.0m),
            new MenuItem("Option 3", 30.0m)
        };

        Menu subMenu = new Menu(subMenuItems);
        subMenu.ExecuteSubMenu();

        Order order = new Order();
        order.StartOrder();
    }
}