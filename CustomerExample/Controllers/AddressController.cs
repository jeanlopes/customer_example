using CustomerExample.Application.DTOs;
using CustomerExample.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CustomerExampleWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    [SwaggerTag("Addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressAppService _addressAppService;

        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        [HttpPost]
        [SwaggerOperation("CreateAddress", "Creates a new address")]
        [SwaggerResponse(201, "Created", typeof(AddressDTO))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> Create(AddressDTO address)
        {
            await _addressAppService.CreateAddress(address);

            return Ok();
        }

        [HttpGet("{customerId}")]
        [SwaggerOperation("GetAddressByCustomerId", "Gets addresses by customer ID")]
        [SwaggerResponse(200, "Success", typeof(AddressDTO))]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> GetAll(int customerId)
        {
            var addresses = await _addressAppService.GetAddressesByCustomerId(customerId);

            return Ok(addresses);

        }

        [HttpDelete("{addressId}")]
        [SwaggerOperation("DeleteAddress", "Deletes an address")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Delete(int addressId)
        {
            await _addressAppService.DeleteAddress(addressId);

            return Ok();
        }
    }
}
