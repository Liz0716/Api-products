using ApiProducts.Migrations;
using ApiProducts.Models;
using Microsoft.Extensions.Options;
using System.Text;

public class ProductService
{
    private readonly ProductContext _context;

    public ProductService(ProductContext context) {
        _context = context;
    }


    public void TraerProducts()
    {

    }

    public void TraerProduct(int Id)
    {

    }

    public async Task<Products> CrearProduct(Products products)
    {
        _context.Products.Add(products);
        await _context.SaveChangesAsync();
        return products;
    }

    public void ActualizarProduct(int Id, Products products)
    {

    }

    public void BorrarProduct(int Id, Products products)
    {
        
    }
}