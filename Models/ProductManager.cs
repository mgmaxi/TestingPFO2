public class ProductManager{

    public int Id { get; set; }
    public List<Product> products { get; set; } = new List<Product>();
    
    public void AddProduct(Product product){
        products.Add(product);
    }

    public decimal CalculateTotalPrice(){
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price * GetTaxRate(product.Category);
        }
        return total;
    }

       public decimal GetTaxRate(string category)
    {
        return category switch
        {
            "Electrónica" => 1.10m,
            "Alimentos" => 1.05m,
            _ => throw new ArgumentException("Categoría inexistente.")
        };
    }

    public Product FindProductById(int id)
        {
            var product = products.Find(p => p.Id == id) ?? throw new ArgumentException("No existe un producto con ese ID.");
            return product;
        }

        public Product FindProductByName(string name)
        {
            var product = products.Find(p => p.Name == name) ?? throw new ArgumentException("No existe un producto con ese nombre.");
            return product;
        }
}