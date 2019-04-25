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
    public class UnitController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UnitController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUnits()
        {
            try
            {
                var Units = _repository.Unit.GetAllUnits();

                _logger.LogInfo($"Returned all Units from database.");

                return Ok(Units);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUnits action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "UnitById")]
        public IActionResult GetUnitById(Guid id)
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
         public IActionResult CreateUnit([FromBody]Unit Unit)
        {
            try
            {
                if (Unit.IsObjectNull())
                {
                    _logger.LogError("Unit object sent from client is null");
                    return BadRequest("Unit object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Unit object sent from client");
                    return BadRequest("Invalid Unit object");
                }

                _repository.Unit.CreateUnit(Unit);

                return CreatedAtRoute("UnitById", new  { id = Unit.Id }, Unit);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUnits action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
         public IActionResult UpdateUnit(Guid id, [FromBody]Unit Unit)
        {
            try
            {
                if (Unit.IsObjectNull())
                {
                    _logger.LogError("Unit object sent from client is null");
                    return BadRequest("Unit object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Unit object sent from client");
                    return BadRequest("Invalid Unit object");
                }

                var dbUnit = _repository.Unit.GetUnitById(id);

                if (dbUnit.IsEmptyObject())
                {
                    _logger.LogError($"Unit with id {id} was not found");
                    return NotFound();
                }

                _repository.Unit.UpdateUnit(dbUnit, Unit);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUnit action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
         public IActionResult DeleteUnit(Guid id)
        {
            try
            {
                var Unit = _repository.Unit.GetUnitById(id);

                if (Unit.IsEmptyObject())
                {
                    _logger.LogError($"Unit with id {id} was not found");
                    return NotFound();
                }

                _repository.Unit.DeleteUnit(Unit);
                _logger.LogInfo("Unit was deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUnit action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}