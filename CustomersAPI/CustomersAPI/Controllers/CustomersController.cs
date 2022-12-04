using CustomersAPI.Data;
using CustomersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace CustomersAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerAPIDbContext dbContext;

        public CustomersController(CustomerAPIDbContext dbContext) {
            this.dbContext = dbContext;
        }
        [Route("/customer")]
        [HttpPost]
        public async Task<IActionResult> PostCustomer(CreateCustomer createCustomer)
        {

            var customer = new Customer()
            {
                CustomerID = Guid.NewGuid(),
                FirstName = createCustomer.FirstName,
                LastName = createCustomer.LastName,
                UserName = createCustomer.FirstName + "" + createCustomer.LastName,
                EmailAddress = createCustomer.EmailAddress,
                DateOfBirth = createCustomer.DateOfBirth,
                Age = CreateAge(createCustomer.DateOfBirth),
                DateCreated = DateTime.Now,
            };

            if (!EmailValid(customer.EmailAddress)) {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            await dbContext.Customer.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return Ok(customer);
        }


        [Route("/customers")]
        [HttpGet]

        public async Task<IActionResult> GetCustomers()
        {

            return Ok(await dbContext.Customer.ToListAsync());
        }



        [HttpGet]
        [Route("customer/{CustomerID:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid CustomerID)
        {

            var customer = await dbContext.Customer.FindAsync(CustomerID);

            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("customer/{CustomerID:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid CustomerID, UpdateCustomer updateCustomer) 
        {
            var customer = await dbContext.Customer.FindAsync(CustomerID);

            if (customer != null)
            {
                customer.FirstName = updateCustomer.FirstName;
                customer.LastName = updateCustomer.LastName;
                customer.UserName = updateCustomer.FirstName + ""+ updateCustomer.LastName;
                customer.EmailAddress = updateCustomer.EmailAddress;
                customer.DateOfBirth = updateCustomer.DateOfBirth;
                customer.Age = CreateAge(updateCustomer.DateOfBirth);
                customer.DateEdited = DateTime.Now;
                
                if (!EmailValid(customer.EmailAddress))
                {
                    return Redirect(Request.Headers["Referer"].ToString());
                }

                await dbContext.SaveChangesAsync();
                return Ok(customer);

            }
            else { 
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("customer/{CustomerID:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid CustomerID)
        {

            var customer = await dbContext.Customer.FindAsync(CustomerID);

            if (customer != null)
            {
                dbContext.Remove(customer);
                customer.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        public static bool EmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static int CreateAge(string dateOfbirth)
        {
            var year = dateOfbirth.Split("-")[2];

            var currentYear = DateTime.Now.Year.ToString();
            var age = Int32.Parse(currentYear) - Int32.Parse(year);
            return age;
        }

}
}
