using Contracts;
using Microsoft.AspNetCore.Mvc;
using System; 


namespace TenantServer.Controllers
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

        [HttpGet("{id}")]
        public IActionResult GetTenantById(Guid id)
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


    
    }
}


