using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Core.Models;
using WebApplication2.Core.Repositories;

namespace WebApplication2.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetStudentsByNumber(int number)
        {
            return await _context.Students.OrderByDescending(f => f.Id).Take(number).ToListAsync();
        }
    }
}
