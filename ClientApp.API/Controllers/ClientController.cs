using AutoMapper;
using ClientApp.API.ClientApp.DAL;
using ClientApp.API.Models;
using ClientApp.API.Services.Logger;
using ClientApp.API.Services.MailService;
using ClientApp.API.Services.ReportEvent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IClientRepository _clientRepository;
        private readonly ICardMetadataRepository _cardMetadataRepository;
        private readonly INotificationSubscribersRepository _notificationSubscribersRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public ClientController(ILoggerManager logger, IMapper mapper, 
                                IClientRepository clientRepository, ICardMetadataRepository cardMetadataRepository,
                                INotificationSubscribersRepository notificationSubscribersRepository, IMailService mailService)
        {
            _logger = logger;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _cardMetadataRepository = cardMetadataRepository;
            _notificationSubscribersRepository = notificationSubscribersRepository;
            _mailService = mailService;
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int Id)
        {
            try
            {
                var client = _clientRepository.GetClientById(Id);
                if (client == null)
                {
                    return NotFound();
                }

                var card = _cardMetadataRepository.GetCardMetadataById(client.Card.MetaDataId);

                var model = _mapper.Map<ClientFullInfoModel>(client);
                model.MetaData = card.Metadata;

                var eventReport = new ReportEventModel()
                {
                    UserFullName = model.UserFullName,
                    CreatedDT = DateTime.Now,
                    ClientId = model.Id,
                    OrganizationShortName = model.OrganizationShortName,
                    Comment = "Подробный запрос информации по клиенту",
                    ReportEventType = ReportEventType.RequestFullInformation
                };
                _logger.LogInfo($"Client requested: {JsonConvert.SerializeObject(eventReport)}");

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                _logger.LogError($"StackTrace: {ex.StackTrace}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("byUserId/{userId}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetClientsByUserId(int userId)
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

        [HttpGet("byClientGroupId/{clientGroupId}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetClientsByClientGroupId(int clientGroupId)
        {
            try
            {
                var clients = _clientRepository.GetClientsByGroupId(clientGroupId);
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

        [HttpPut("{clientId}")]
        public IActionResult UpdateClient(int clientId, ClientUpdateDto model)
        {
            if (!_clientRepository.IsClientExists(clientId))
            {
                return NotFound();
            }

            var clientFromRepository = _clientRepository.GetClientById(clientId);
            _mapper.Map(model, clientFromRepository);

            bool result = _clientRepository.Save();
            if (result)
            {
                var eventReport = new ReportEventModel()
                {
                    UserFullName = $"{clientFromRepository.User.LastName} {clientFromRepository.User.FirstName} {clientFromRepository.User.MiddleName}",
                    CreatedDT = DateTime.Now,
                    ClientId = clientFromRepository.Id,
                    OrganizationShortName = clientFromRepository.OrganizationShortName,
                    Comment = "Запрос на изменение реквизитов клиента",
                    ReportEventType = ReportEventType.UpdateClient
                };
                _logger.LogInfo($"Client updated: {JsonConvert.SerializeObject(eventReport)}");
                _logger.LogInfo($"Updated data: {JsonConvert.SerializeObject(model)}");

                var message = "Зафиксировано измение реквизитов клиента";
                _mailService.Send(_notificationSubscribersRepository.GetSubscribersForClient(clientFromRepository.Id), message);
            }

            return NoContent();
        }
    }
}
