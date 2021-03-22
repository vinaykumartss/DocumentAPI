using System;
using System.Collections.Generic;
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
using Document.Approve.ApiRequest.Model.Role.RoleRequest;

namespace Document_approve_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private IGenericRepository<Role> _role;
        private readonly IMapper _mapper;
        public RoleController(ILogger<WeatherForecastController> logger,
             IGenericRepository<Role> role,
            IMapper mapper)
        {
            _logger = logger;
            _role = role;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Boolean> CreateAsync(RoleRequest roleRequest)
        {
            try
            {

                var department = _mapper.Map<Role>(roleRequest);
                await _role.AddAsync(department);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IList<Role>> GetAllAsync()
        {
            try
            {
                IList<Role> objResponse = await _role.GetAllAsync();
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
                Role objResponse = await _role.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        [HttpPost]
        [Route("{id}")]
        public async Task<Role> GetByIdAsync(int id)
        {
            try
            {
                Role objResponse = await _role.GetByIdAsync(id);
                return objResponse;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<Role> UpdateAsync(RoleRequest roleRequest)
        {
            try
            {
                Role objResponse = await _role.GetByIdAsync(roleRequest.Id);
                objResponse.Name = roleRequest.Name;
               
                Role result = await _role.UpdateAsync(objResponse);
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
