public class ProductManager{

    public int Id { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    
    public void addProduct(Product product){
        Products.Add(product);
    }

    public decimal calculateTotalPrice(){
         decimal total = 0;
        foreach (var product in Products)
        {
            decimal tax = product.Category == "Electrónica" ? 1.10m : 1.05m;
            total += product.Price * tax;
        }
        return total;
    }

}