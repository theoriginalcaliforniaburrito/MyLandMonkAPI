using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Entities.Extensions;
using Entities.Models;


namespace LandMonkServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public TenantController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllTenants()
        {
            try
            {
                var tenants = _repository.Tenant.GetAllTenants();
                _logger.LogInfo($"Returned al tenants from database.");
                return Ok(tenants);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAlltenants action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "TenantById")]
        public IActionResult GetTenantById(int id)
        {
            try
            {
                var tenant = _repository.Tenant.GetTenantById(id);

                if (tenant == null)
                {
                    _logger.LogError($"Tenant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned tenant with id: {id}");
                    return Ok(tenant);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetTenantById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateTenant([FromBody]Tenant tenant)
        {
            try
            {
                if (tenant == null)
                {
                    _logger.LogError("Tenant object sent from client is null.");
                    return BadRequest("Tenant object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Tenant object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Tenant.CreateTenant(tenant);
                return CreatedAtRoute("TenantById", new { id = tenant.Id }, tenant);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateTenant action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }


        }

        [HttpPut("{id}")]
        public IActionResult UpdateTenant(int id, [FromBody]Tenant tenant)
        {
            try
            {
                if (tenant.IsObjectNull())
                {
                    _logger.LogError("Tenant object sent from client is null.");
                    return BadRequest("Tenant object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid tenant object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbTenant = _repository.Tenant.GetTenantById(id);
                if (dbTenant.IsEmptyObject())
                {
                    _logger.LogError($"Tenant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Tenant.UpdateTenant(dbTenant, tenant);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateTenant action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTenant(int id)
        {
            try
            {
                var tenant = _repository.Tenant.GetTenantById(id);
                if (tenant.IsEmptyObject())
                {
                    _logger.LogError($"Tenant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Tenant.DeleteTenant(tenant);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTenant action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}



