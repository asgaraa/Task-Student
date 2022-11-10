﻿using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetAllAdminWithAsync(string userId);
    }
}
