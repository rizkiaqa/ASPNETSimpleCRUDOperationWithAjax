using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDWithAjax.EF;

public partial class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public int Price { get; set; }
    public int Stock { get; set; }
    public bool Active { get; set; }    
    public string FilePath { get; set; }
    public DateTime ExpiredDate { get; set; }
}