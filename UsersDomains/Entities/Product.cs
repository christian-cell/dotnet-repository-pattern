using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersDomains.Entities;
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public string Ean { get; set; }
    public int price { get; set; }
    public bool Active { get; set; }

    public Product()
    {
        if (Name == null)
        {
            Name = "";
        }
        
        if (Description == null)
        {
            Description = "";
        }
        
        if (Sku == null)
        {
            Sku = "";
        }
        
        if (Ean == null)
        {
            Ean = "";
        }
    }
}