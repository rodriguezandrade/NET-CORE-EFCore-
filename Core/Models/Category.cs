namespace Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int ImageResourceId { get; set; }

        public ImageResource ImageResource { get; set; }
    }
}
