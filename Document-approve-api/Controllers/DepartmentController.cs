using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Document.Approve.Domain.Entities;
using Document.Approve.Infrastructure.Configuration.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Document.Approve.ApiRequest.Model.UserResponse;
using System.Collections;
using AutoMapper;
using Document.Approve.ApiRequest.Model.UserRequest;
using Document.Approve.ApiRequest.Model.Department.DepartmentRequest;

namespace Document_approve_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private IGenericRepository<Department> _department;
        private readonly IMapper _mapper;
        public DepartmentController(ILogger<WeatherForecastController> logger,
            IGenericRepository<Department> department,
            IMapper mapper)
        {
            _logger = logger;
            _department = department;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Boolean> CreateAsync(DepartmentRequest departmentRequest)
        {
            try
            {

                var department = _mapper.Map<Department>(departmentRequest);
                await _department.AddAsync(department);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IList<Department>> GetAllAsync()
        {
            try
            {
                IList<Department> objResponse = await _department.GetAllAsync();
                return objResponse;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<Boolean> Delete(int id)
        {
            try
            {
                Department objResponse = await _department.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        [HttpPost]
        [Route("{id}")]
        public async Task<Department> GetByIdAsync(int id)
        {
            try
            {
                Department objResponse = await _department.GetByIdAsync(id);
                return objResponse;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<Department> UpdateAsync(DepartmentRequest department)
        {
            try
            {
                Department objResponse = await _department.GetByIdAsync(department.Id);
                objResponse.Name = department.Name;
               
                Department result = await _department.UpdateAsync(objResponse);
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
