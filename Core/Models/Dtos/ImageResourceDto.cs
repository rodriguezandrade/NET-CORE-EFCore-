using Core.Models.Enums;

namespace Core.Models.Dtos
{
    public class ImageResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public ItemType Descriminator { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
