using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.Interface
{
    public interface IObjService<T, CreateDto, UpdateDto> where T : class where CreateDto : class where UpdateDto : class
    {
        void SetEndpoint(string endpoint);
        Task<List<T>> GetObjects();
        Task<T> GetObjectById(Guid id);
        Task CreateObject(CreateDto obj);
        Task DeleteObject(Guid id);
        Task UpdateObject(UpdateDto obj);
    }
}
