using AutoMapper;
using CustomerExample.Application.DTOs;
using CustomerExample.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerExampleWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerAppService customerAppService, IMapper mapper)
        {
            _customerAppService = customerAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerAppService.GetAllCustomers();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDTO customerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerAppService.CreateCustomer(customerDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerAppService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerEditDTO { 
                Email= customer.Email, 
                Name = customer.Name, 
                Id = customer.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditDTO customerEditDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customerDto = _mapper.Map<CustomerDTO>(customerEditDto);
                    await _customerAppService.UpdateCustomer(customerDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }

            return View(customerEditDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerAppService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerAppService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _customerAppService.DeleteCustomer(id);
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
