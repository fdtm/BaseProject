using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Core.Models;

namespace WebApplication2.Core.Services
{
    public interface IStudentService : IService<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByNumber(int number);
    }
}
