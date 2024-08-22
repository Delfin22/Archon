using Archon.API.Models.Domain;

namespace Archon.API.Services
{
    public interface IItemRepository
    {   
        //Interface for DB operations connected to items, providing flexibility of code
        Task<List<Item>> GetAllAsync(string? filterQuery=null, string? sortBy=null, bool isAscending=true, int pageNumber = 1, int pageSize = 50);
        Task<Item?> GetByIdAsync(Guid id);
        Task<Item> CreateAsync(Item item);
        Task<Item?> UpdateAsync(Guid id, Item item);
        Task<Item?> DeleteAsync(Guid id);
    }
}
