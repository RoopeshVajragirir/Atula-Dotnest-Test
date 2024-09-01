namespace AtulaTechnologies1.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public List<Category> Category { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
