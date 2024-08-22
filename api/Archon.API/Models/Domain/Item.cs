using System.ComponentModel.DataAnnotations;

namespace Archon.API.Models.Domain
{
    //Domain Model of Cyberware item
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //api accepts items without uploaded photo
        public string? ItemImgUrl { get; set; }
        public double Price { get; set; }
        public bool IsAvaliable { get; set; }
    }
}
