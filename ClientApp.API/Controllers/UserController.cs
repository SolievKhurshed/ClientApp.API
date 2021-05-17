using AutoMapper;
using ClientApp.API.ClientApp.DAL;
using ClientApp.API.Models;
using ClientApp.API.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public UserController(ILoggerManager logger, IMapper mapper, IUserRepository userRepository, IClientRepository clientRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if (users == null)
            {
                return NotFound();
            }            
            return Ok(users);
        }

        [HttpGet("{userId}/clients")]
        public ActionResult GetClientsForUser(int userId)
        {
            try
            {
                var clients = _clientRepository.GetLastViewedClientsByUserId(userId);
                if (clients == null || clients.Count() == 0)
                {
                    return NotFound();
                }

                IEnumerable<ClientShortInfoModel> model = _mapper.Map<IEnumerable<ClientShortInfoModel>>(clients);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                _logger.LogError($"StackTrace: {ex.StackTrace}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
