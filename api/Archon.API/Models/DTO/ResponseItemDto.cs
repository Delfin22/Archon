namespace Archon.API.Models.DTO
{
    public class ResponseItemDto
    {
        //Dto which provides abstraction layer while sending data back to client
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? ItemImgUrl { get; set; }
        public double Price { get; set; }
        public bool IsAvaliable { get; set; }
    }
}
