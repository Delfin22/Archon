using Archon.API.Data;
using Archon.API.Models.Domain;
using Archon.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Archon.API.Repositories
{
    public class SQLItemRepository : IItemRepository
    {
        //Class for asynchronous DB operations connected to items
        private readonly ArchonDbContext dbContext;

        public SQLItemRepository(ArchonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
     
        public async Task<List<Item>> GetAllAsync(string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber=1, int pageSize=50)
        {
            //for data manipulation using AsQueryable
            var items = dbContext.Items.AsQueryable();

            //Filter based on query
            if (!string.IsNullOrWhiteSpace(filterQuery)) {    
                    items = items.Where(x => x.Name.Contains(filterQuery) || x.Description.Contains(filterQuery));
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    items = isAscending ? items.OrderBy(x => x.Name) : items.OrderByDescending(x=>x.Name);
                }
                else if(sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    items = isAscending ? items.OrderBy(x => x.Price) : items.OrderByDescending(x => x.Price);
                }
            }

            //Pagination
            var skippedResults = (pageNumber - 1) * pageSize;

            return await items.Skip(skippedResults).Take(pageSize).ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Item> CreateAsync(Item item)
        {
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return item;
        }


        public async Task<Item?> UpdateAsync(Guid id, Item item)
        {
            var updateItem = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (updateItem == null)
            {
                return null;
            }
            updateItem.Name = item.Name;
            updateItem.Description = item.Description;
            updateItem.ItemImgUrl = item.ItemImgUrl;
            updateItem.Price = item.Price;
            updateItem.IsAvaliable  = item.IsAvaliable;

            //because updateItem entity was  tracked by Entity framework we can just save changes
            await dbContext.SaveChangesAsync();
            return updateItem;
        }

        public async Task<Item?> DeleteAsync(Guid id)
        {
            var deletedItem = await dbContext.Items.FirstOrDefaultAsync(x=> x.Id == id);
            if(deletedItem == null)
            {
                return null;
            }
            dbContext.Items.Remove(deletedItem);
            await dbContext.SaveChangesAsync();
            return deletedItem;
        }
    }
}

