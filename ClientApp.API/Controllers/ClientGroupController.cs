using ClientApp.API.ClientApp.DAL;
using ClientApp.API.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ClientApp.API.Controllers
{
    [ApiController]
    [Route("api/clientGroups")]
    public class ClientGroupController : ControllerBase
    {
        private readonly ILoggerManager _logger;       
        private readonly IClientRepository _clientRepository;
        private readonly IClientGroupRepository _clientGroupRepository;

        public ClientGroupController(ILoggerManager logger, IClientRepository clientRepository, IClientGroupRepository clientGroupRepository)
        {
            _logger = logger;          
            _clientRepository = clientRepository;
            _clientGroupRepository = clientGroupRepository;
        }

        [HttpGet]
        public ActionResult GetClientGroups()
        {
            try
            {
                var clientGroups = _clientGroupRepository.GetClientGroups();
                if (clientGroups == null || clientGroups.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(clientGroups);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                _logger.LogError($"StackTrace: {ex.StackTrace}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{clientGroupId}")]
        public ActionResult GetClientGroupById(int clientGroupId)
        {
            try
            {
                var group = _clientGroupRepository.GetClientGroupById(clientGroupId);
                if (group == null)
                {
                    return NotFound();
                }
                return Ok(group);
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
