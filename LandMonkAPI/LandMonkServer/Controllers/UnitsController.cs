using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using Contracts;
using Entities.Models;

namespace LandMonkServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UnitsController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUnits()
        {
            try
            {
                var units = _repository.Unit.GetAllUnits();

                _logger.LogInfo($"Returned all units from database.");

                return Ok(units);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUnits action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}