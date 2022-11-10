using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Student> entities;
        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = context.Set<Student>();
        }

        public async Task<List<Student>> GetAllAdminWithAsync(string userId)
        {
            return await entities.Where(m=>m.UserId == userId).ToListAsync();
        }
    }
}
