using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;
using Entities.Extensions;

namespace LandMonkServer.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase

    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public PropertyController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{id}/unit")]
        public IActionResult GetPropertyWithDetails(int id) //use int not GUID
        {
            try
            {
                var property = _repository.Property.GetPropertyWithDetails(id);

                if (property.IsEmptyObject())
                {
                    _logger.LogError($"Property with id {id} was not found");
                    return NotFound();
                }

                _logger.LogInfo($"Returned property with id {id}.");

                return Ok(property);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPropertyWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
         [HttpGet]
        public IActionResult GetAllProperty()

        {
            try
            {
                var properties = _repository.Property.GetAllProperty();

                _logger.LogInfo($"Returned all properties from database");

                return Ok(properties);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProperty action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPropertyById(int id)

        {
            try
            {
                var properties = _repository.Property.GetPropertyById(id);

                if(properties == null)
                {
                    _logger.LogError($"Property with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned property with id: {id}");
                    return Ok(properties);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPropertyById action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}