using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using Contracts;
using Entities.Models;
using Entities.Extensions;

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
        [HttpGet("{id}", Name = "UnitById")]
        public IActionResult GetUnitById(int id)
        {
            try
            {
                var Unit = _repository.Unit.GetUnitById(id);

                if (Unit.IsEmptyObject())
                {
                    _logger.LogError($"Unit with id {id} was not found");
                    return NotFound();
                }
                _logger.LogInfo($"Returned Unit with id {id}");
                return Ok(Unit);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUnitById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
         public IActionResult CreateUnit([FromBody]Unit unit)
        {
            try
            {
                if (unit.IsObjectNull())
                {
                    _logger.LogError("Unit object sent from client is null");
                    return BadRequest("Unit object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid unit object sent from client");
                    return BadRequest("Invalid Unit object");
                }

                _repository.Unit.CreateUnit(unit);

                return CreatedAtRoute("UnitById", new  { id = unit.Id }, unit);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUnits action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}