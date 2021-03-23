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
using Document.Approve.ApiRequest.Exceptions;
using Document.Approve.ApiRequest.Model;

namespace Document_approve_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private IGenericRepository<User> _user;
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, 
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
       
        public async Task<ApiResponse> GetAllAsync()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                IList<User> userList = await _user.GetAllAsync();
                var objResponse = _mapper.Map<IList<User>, IList<UserResponse>>(userList);
                response.IsSuccess = true;
                response.Response = objResponse;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"Something went wrong, please try after some try";
                
            }
            return response;

        }

        [HttpPost]
        [Route("Login")]
        public async Task<ApiResponse> LoginAsync(LoginRequest login)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                User objResponse = await _user.Search(x=>x.UserName == login.UserName);
                if(!BCrypt.Net.BCrypt.Verify(login.Password, objResponse.Password))
                {
                    var mapdata = _mapper.Map<User, UserResponse>(objResponse);
                    response.IsSuccess = true;
                    response.Response = mapdata;
                }

               
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"Something went wrong, please try after some try";
            }

            return response;

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                User objResponse = await _user.GetByIdAsync(id);
                var mapdata = _mapper.Map<User, UserResponse>(objResponse);
                response.IsSuccess = true;
                response.Response = mapdata;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"Something went wrong, please try after some try";
            }
            return response;
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                User objResponse = await _user.DeleteAsync(id);
                var mapdata = _mapper.Map<User, UserResponse>(objResponse);
                response.IsSuccess = true;
                response.Response = mapdata;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"Something went wrong, please try after some try";
            }
            return response;
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
    

