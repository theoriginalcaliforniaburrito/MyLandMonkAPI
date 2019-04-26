using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;


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