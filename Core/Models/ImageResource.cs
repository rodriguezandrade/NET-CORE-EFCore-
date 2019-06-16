using Core.Models.Enums;

namespace Core.Models
{
    public class ImageResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public ItemType Descriminator { get; set; }
    }
}
