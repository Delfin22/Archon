using Archon.API.Models.Domain;

namespace Archon.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
