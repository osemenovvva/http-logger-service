using AutoMapper;
using Ixora.Logger.Db;
using Ixora.Logger.Models;

namespace Ixora.Logger.Logic
{
    public class LogMappingProfile : Profile
    {
        public LogMappingProfile()
        {
            CreateMap<Logs, LogDto>();
        }
    }
}
