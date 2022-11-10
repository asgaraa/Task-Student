using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class StudentDetailRepository : Repository<StudentDetail>, IStudentDetailRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<StudentDetail> entities;
        public StudentDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = context.Set<StudentDetail>();
        }

        public async Task<List<StudentDetail>> GetStudentById(int id)
        {
            return await entities.Where(x => x.StudentId == id).ToListAsync();
        }
    }
}
