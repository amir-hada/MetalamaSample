class Program
{
    static void Main(string[] args)
    {
        Product product = new Product();
        
        product.PropertyChanged += (sender, e) =>
        {
            Console.WriteLine($"Property {e.PropertyName} changed.");
        };
        
        product.Title = "Iphone";
        product.Price = 29.99m;
        
    }
});