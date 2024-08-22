using Archon.API.Models.Domain;
using Archon.API.Models.DTO;
using AutoMapper;

namespace Archon.API.Mappings
{
    //Auto mapper profiles class
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Item,CreateItemDto>().ReverseMap();
            CreateMap<Item,ResponseItemDto>().ReverseMap();
        }
    }
}
