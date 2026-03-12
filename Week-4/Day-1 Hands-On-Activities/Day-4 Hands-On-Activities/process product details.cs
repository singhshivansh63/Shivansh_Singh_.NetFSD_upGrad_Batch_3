using System;

class Product
{
    private int productId;
    private string productName;
    private double unitPrice;
    private int qty;

     
    public Product(int id)
    {
        productId = id;
    }

     
    public int ProductId
    {
        get { return productId; }
    }

    
    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }
 
    public double UnitPrice
    {
        get { return unitPrice; }
        set { unitPrice = value; }
    }

    
    public int Quantity
    {
        get { return qty; }
        set { qty = value; }
    }

    
    public void ShowDetails()
    {
        double total = unitPrice * qty;

        Console.WriteLine("\nProduct Details");
        Console.WriteLine("----------------------");
        Console.WriteLine("Product ID   : " + ProductId);
        Console.WriteLine("Product Name : " + ProductName);
        Console.WriteLine("Unit Price   : " + UnitPrice);
        Console.WriteLine("Quantity     : " + Quantity);
        Console.WriteLine("Total Amount : " + total);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

     
        Product p = new Product(id);

        Console.Write("Enter Product Name: ");
        p.ProductName = Console.ReadLine();

        Console.Write("Enter Unit Price: ");
        p.UnitPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Quantity: ");
        p.Quantity = Convert.ToInt32(Console.ReadLine());

        p.ShowDetails();
    }
}
