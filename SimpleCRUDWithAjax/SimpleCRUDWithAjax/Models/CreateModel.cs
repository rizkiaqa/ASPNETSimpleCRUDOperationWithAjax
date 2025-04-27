namespace SimpleCRUDWithAjax.Models
{
    public class CreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
        public IFormFile FileUploaded { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
