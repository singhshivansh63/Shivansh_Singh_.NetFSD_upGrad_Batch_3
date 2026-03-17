using System;

class Product
{
    // Private Fields (Encapsulation)
    private string name;
    private double price;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property for Price with Validation
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be negative.");
            }
            else
            {
                price = value;
            }
        }
    }

    // Virtual Method
    public virtual double CalculateDiscount()
    {
        return price;
    }
}

// Derived Class: Electronics
class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05); // 5% Discount
    }
}

// Derived Class: Clothing
class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15); // 15% Discount
    }
}

class Program
{
    static void Main()
    {
        Product item;

        // Electronics Product
        item = new Electronics();
        item.Name = "Laptop";
        item.Price = 20000;

        Console.WriteLine("Electronics Price = " + item.Price);
        Console.WriteLine("Final Price after 5% discount = " + item.CalculateDiscount());

        Console.WriteLine();

        // Clothing Product
        item = new Clothing();
        item.Name = "Jacket";
        item.Price = 20000;

        Console.WriteLine("Clothing Price = " + item.Price);
        Console.WriteLine("Final Price after 15% discount = " + item.CalculateDiscount());
    }
}