using System.Runtime.InteropServices;

namespace PFO2.Tests;

public class IntegrationTests
{

    private ProductManager _productManager;

    [SetUp]
    public void Setup()
    {
        _productManager = new ProductManager();
    }

    [Test]
    public void ValidarAtributosProductoValidos()
    {
        var product = new Product(1, "Televisor", 500000, "Electrónica");
        Assert.That(product.Id, Is.TypeOf<int>(), "El ID no es un número entero.");
        Assert.That(product.Id, Is.GreaterThan(0), "El ID no es mayor a cero.");
        Assert.That(product.Name, Is.TypeOf<string>(), "El Name no es del tipo string.");
        Assert.That(product.Price, Is.TypeOf<decimal>(), "El Price no es del tipo decimal.");
        Assert.That(product.Category, Is.TypeOf<string>(), "La Category no es del tipo string.");
     
    }

[Test]
    public void ValidarAgregarProducto()
    {       
        var product = new Product(1, "Televisor", 500000, "Electrónica");
        var resultFindProductById = _productManager.FindProductById(product.Id);
        var resultFindProductByName = _productManager.FindProductByName(product.Name);
        
        _productManager.AddProduct(product);

        Assert.That(_productManager.products.Count(),Is.GreaterThan(0), "La lista está vacía.");
        Assert.That(product.Id, Is.EqualTo(resultFindProductById.Id), "El Id no se encuentra en la lista");
        Assert.That(product.Name, Is.EqualTo(resultFindProductByName.Name), "El nombre no se encuentra en la lista");

    }


    [Test]
    public void ValidateFindProductByName()
    {       
        var product1 = new Product(1, "Televisor Samsung", 500000, "Electrónica");
        var product2 = new Product(2, "PS5", 1500000, "Electrónica");
        var product3 = new Product(3, "Celular Iphone", 1000000, "Electrónica");

        var resultFindProduct1ByName = _productManager.FindProductByName(product1.Name);
        var resultFindProduct2ByName = _productManager.FindProductByName(product2.Name);
        var resultFindProduct3ByName = _productManager.FindProductByName(product3.Name);
        
        _productManager.AddProduct(product1);
        _productManager.AddProduct(product2);
        _productManager.AddProduct(product3);

        Assert.That(_productManager.products.Count(),Is.GreaterThan(0), "La lista está vacía.");
        Assert.That(product1.Name, Is.EqualTo(resultFindProduct1ByName.Name), "El nombre del producto 1 no se encuentra en la lista");
        Assert.That(product1.Name, Is.EqualTo(resultFindProduct2ByName.Name), "El nombre del producto 2 no se encuentra en la lista");
        Assert.That(product1.Name, Is.EqualTo(resultFindProduct3ByName.Name), "El nombre del producto 3 no se encuentra en la lista");
    }

     [Test]
    public void ValidateCalculateTaxForProducts()
    {       
        var electronicTax = 1.10m;
        var foodTax = 1.05m;

        var product1 = new Product(1, "Televisor Samsung", 500000, "Electrónica");
        var product2 = new Product(2, "PS5", 1500000, "Electrónica");
        var product3 = new Product(3, "Celular Iphone", 1000000, "Electrónica");
        var product4 = new Product(4, "Manzana", 100, "Alimentos");
        
        _productManager.AddProduct(product1);
        _productManager.AddProduct(product2);
        _productManager.AddProduct(product3);
        _productManager.AddProduct(product4);

        decimal totalPrice = _productManager.CalculateTotalPrice();

        Assert.That(totalPrice,Is.EqualTo(3300105), "El cálculo del precio total con impuestos no es correct."); // 500000 * 1.1 + 1500000 * 1.1 + 1000000 * 1.1 + 100 * 1.05 = 3300105
        Assert.That(_productManager.GetTaxRate("Electrónica"), Is.EqualTo(electronicTax), "El % de impuesto para la categoría 'Electrónica' no es correcto.");
        Assert.That(_productManager.GetTaxRate("Alimentos"), Is.EqualTo(foodTax), "El % de impuesto para la categoría 'Alimentos' no es correcto.");
    }

}