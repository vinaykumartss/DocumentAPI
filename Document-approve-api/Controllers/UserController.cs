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
using Microsoft.AspNetCore.Cors;

namespace Document_approve_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private IGenericRepository<User> _user;
        private readonly IMapper _mapper;
        public UserController(ILogger<WeatherForecastController> logger, 
            IGenericRepository<User> user,
            IMapper mapper)
        {
            _logger = logger;
            _user = user;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Boolean> CreateUserAsync(UserRequest user)
        {
            try
            {
                var userMapped = _mapper.Map<User>(user);
                userMapped.Password = BCrypt.Net.BCrypt.HashPassword(userMapped.Password);
                userMapped.CreatedOn = DateTime.Now;
                await _user.AddAsync(userMapped);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("GetAll")]
       
        public async Task<IList<User>> GetAllAsync()
        {
            try
            {
                IList<User> objResponse = await _user.GetAllAsync();
                return objResponse;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<Boolean> LoginAsync(LoginRequest login)
        {
            try
            {
                User objResponse = await _user.Search(x=>x.UserName == login.UserName);
                if(!BCrypt.Net.BCrypt.Verify(login.Password, objResponse.Password))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
               return false;
            }
        }


        [HttpPost]
        [Route("ForgotUserName")]
        public async Task<IList<User>> GetUserName()
        {
            try
            {
                IList<User> objResponse = await _user.GetAllAsync();
                return objResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IList<User>> ForgotPassword()
        {
            try
            {
                IList<User> objResponse = await _user.GetAllAsync();
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
                User objResponse = await _user.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        [HttpPost]
        [Route("{id}")]
        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                User objResponse = await _user.GetByIdAsync(id);
                return objResponse;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<User> UpdatePassAsync(PasswordChange user)
        {
            try
            {
                User objResponse = await _user.GetByIdAsync(user.UserId);
                objResponse.Password = user.NewPassword;
                User result = await _user.UpdateAsync(objResponse);
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
    

