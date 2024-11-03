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
            decimal tax = product.Category == "Electrónica" ? 1.10m : 1.05m;
            total += product.Price * tax;
        }
        return total;
    }

    public Product FindProductById(int id)
        {
            var product = products.Find(p => p.Id == id);
            if(product == null)throw new ArgumentException("No existe un producto con ese ID.");
            return product;
        }
}