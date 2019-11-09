using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Core;
using WebApplication2.Core.Models;
using WebApplication2.Core.Repositories;
using WebApplication2.Core.Services;

namespace WebApplication2.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork) : base(studentRepository, unitOfWork)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudentsByNumber(int number)
        {
            return await _studentRepository.GetStudentsByNumber(number);
        }
    }
}
