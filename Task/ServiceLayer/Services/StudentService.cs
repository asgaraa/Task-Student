using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Student;
using ServiceLayer.DTOs.StudentDetail;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IUserDetailService _userDetail;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, IMapper mapper, IUserDetailService userDetail)
        {
            _repository = repository;
            _mapper = mapper;
            _userDetail = userDetail;
        }

        public async Task CreateAsync(StudentDto studentDto)
        {
            var userid = _userDetail.GetUserId();
           
            var model = _mapper.Map<Student>(studentDto);
            model.UserId = userid.Id;
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _repository.GetAsync(id);
            await _repository.DeleteAsync(student);
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<StudentDto>>(model);
            return res;
        }
        public async Task<List<StudentDto>> GetAllWithAdminAsync(string userId)
        {

            var model = await _repository.GetAllAdminWithAsync( userId);
            var res = _mapper.Map<List<StudentDto>>(model);
                return res;
            
        }

        public async Task<StudentDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<StudentDto>(model);
            return res;
        }

        public async Task UpdateAsync(int Id, StudentEditDto studentEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            _mapper.Map(studentEditDto, entity);

            await _repository.UpdateAsync(entity);
        }
        
        
    }
}
