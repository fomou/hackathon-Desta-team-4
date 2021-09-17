using DestaNationConnect.DataAccessLayer;
using DestaNationConnect.DataAccessLayer.Models;
using DestaNationConnect.DTO;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace DestaNationConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {

        //Logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AccountController));

        private readonly DestaNationConnectContext _context;
        public PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        public AccountController(DestaNationConnectContext context)
        {
            _context = context;
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var loginDto = JsonConvert.DeserializeObject<LoginDTO>(apiInput.Data.ToString());
                
                //TODO: faire le Login process icite
                var account = _context.User.FirstOrDefault(x => x.Username == loginDto.Username);

                bool passwordValidation = false;
                if (account != null)
                {
                    passwordValidation = VerifiedHashedPassword(account, loginDto.Password);
                }

                statusCode = 200;

                //If account is found 
                if (account != null && passwordValidation)
                {
                    var userProfile = await _context.Set<UserProfile>()
                        .Where(x => x.UserId == account.UserId)
                        .SingleOrDefaultAsync();

                    var userDetails = await _context.Set<User>()
                        .Where(x => x.Username == account.Username)
                        .Include(x => x.UserTags)
                        .Include(x => x.UserFeeds)
                        .SingleOrDefaultAsync();

                    //It is a business or Customer account ?
                    var customer = await _context.Set<Customer>().Where(c => c.UserId == account.UserId).SingleOrDefaultAsync();
                    var business = await _context.Set<Business>().Where(c => c.UserId == account.UserId).SingleOrDefaultAsync();
                    
                    //ApiResponse
                    apiResponse.Response = $"User {account.Username} successfully logged in";
                    apiResponse.Message = $"User {account.Username} found with success !";
                    apiResponse.Data = new {
                        Account = account,
                        Profile = userProfile,
                        Details = userDetails,
                        IsCustomer = customer != null && business ==null,
                        CustomerInfo = customer,
                        BusinessInfo = business
                    };
                    apiResponse.Code = ApiResponseCode.ReceivedAndSuccess;
                    statusCode = 200;
                }
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }

        // POST: api/Account/OAuthLogin
        [HttpPost("OAuthLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> OAuthLogin([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var oAuthAccountDto = JsonConvert.DeserializeObject<AccountOAuthDTO>(apiInput.Data.ToString());

                var account = await _context.Set<UserOAuth>()
                    .Where(x => x.OAuthProviderId == oAuthAccountDto.ProviderId && x.Email == oAuthAccountDto.Email)
                    .SingleOrDefaultAsync(); ;

                apiResponse.Code = ApiResponseCode.ReceivedAndFailure;
                if (account != null)
                {
                    //ApiResponse
                    apiResponse.Response = $"User {account.Email} found for OAuthProvider ${oAuthAccountDto.ProviderId}";
                    apiResponse.Message = $"User {account.Email} found for OAuthProvider ${oAuthAccountDto.ProviderId}!";
                    apiResponse.Data = account;
                    apiResponse.Code = ApiResponseCode.ReceivedAndSuccess;
                    statusCode = 200;
                }
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }

        // Post: api/Account/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var logoutDto = JsonConvert.DeserializeObject<LogoutQueryDTO>(apiInput.Data.ToString());
                
                apiResponse.Code = ApiResponseCode.ReceivedAndSuccess;
                apiResponse.Data = $"User {logoutDto.UserName} logged Out with Success";
                statusCode = 200;
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return await Task.FromResult(StatusCode(statusCode, apiResponse));
        }

        // POST: api/Account/Register
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var registrationDto = JsonConvert.DeserializeObject<RegistrationDTO>(apiInput.Data.ToString());

                //
                var createdUser = await CreateAccountAsync(registrationDto);

                //ApiResponse
                apiResponse.Response = $"User {registrationDto.Username} successfully registered";
                apiResponse.Message = $"User {registrationDto.Username} created!";
                apiResponse.Data = new { UserId = createdUser.UserId, User = createdUser };
                apiResponse.Code = ApiResponseCode.ReceivedAndSuccess;
                statusCode = 200;
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }

        private async Task<User> CreateAccountAsync(RegistrationDTO registrationDto)
        {
            //Create User
            var user = new User
            {
                Password = passwordHasher.HashPassword(registrationDto.Username.ToString(), registrationDto.Password),
                CreationDate = DateTime.UtcNow,
                AccessCode = registrationDto.AccessCode,
                IsBIPOC = registrationDto.IsBIPOC
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            //Create Address If provided
            if (registrationDto.Address != null)
            {
                await CreateAccountAddress(registrationDto, user);
            }

            //Bind to Account Type.
            if (registrationDto.IsCustomer)
            {
                await CreateCustomerAccount(registrationDto, user);
            }
            else
            {
                await CreateBusinessAccount(registrationDto, user);
            }

            //Create Tags if any
            await CreateAccountTags(registrationDto, user);

            return user;
        }

        private async Task CreateBusinessAccount(RegistrationDTO registrationDto, User user)
        {
            var business = new Business
            {
                AboutUs = registrationDto.AboutUs,
                Website = registrationDto.Website,
                MarketingName = registrationDto.DisplayName,
                CreationDate = DateTime.UtcNow,
                UserId = user.UserId,
                User = user
            };
            _context.Business.Add(business);
            await _context.SaveChangesAsync();
        }

        private async Task CreateCustomerAccount(RegistrationDTO registrationDto, User user)
        {
            var customer = new Customer
            {
                Age = registrationDto.Age,
                Occupation = registrationDto.Occupation,
                CreationDate = DateTime.UtcNow,
                UserId = user.UserId,
                User = user
            };
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }

        private async Task CreateAccountAddress(RegistrationDTO registrationDto, User user)
        {
            var address = new Address
            {
                Door = registrationDto.Address.Door,
                Street = registrationDto.Address.Street,
                City = registrationDto.Address.City,
                State = registrationDto.Address.State,
                Country = registrationDto.Address.Country,
                UserId = user.UserId,
                User = user
            };
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
        }

        private async Task CreateAccountTags(RegistrationDTO registrationDto, User user)
        {
            var tagPurposes = await _context.TagPurpose.ToListAsync();
            if (registrationDto.TagsOfInterests.Any())
            {
                var tagOfInterest = tagPurposes.FirstOrDefault(x => x.Name == "Interest");
                foreach (var tagname in registrationDto.TagsOfInterests)
                {
                    var tag = await _context.Tag.SingleOrDefaultAsync(e => e.Name == tagname);
                    if (tag != null)
                    {
                        var userTag = new UserTag
                        {
                            TagId = tag.Id,
                            UserId = user.UserId,
                            TagPurposeId = tagOfInterest.Id,
                            CreationDate = DateTime.UtcNow
                        };
                        _context.UserTag.Add(userTag);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            if (registrationDto.TagsOfDescriptions.Any())
            {
                var tagOfDescription = tagPurposes.FirstOrDefault(x => x.Name == "Descriptive");
                foreach (var tagname in registrationDto.TagsOfDescriptions)
                {
                    var tag = await _context.Tag.SingleOrDefaultAsync(e => e.Name == tagname);
                    if (tag != null)
                    {
                        var userTag = new UserTag
                        {
                            TagId = tag.Id,
                            UserId = user.UserId,
                            TagPurposeId = tagOfDescription.Id,
                            CreationDate = DateTime.UtcNow
                        };
                        _context.UserTag.Add(userTag);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        private bool VerifiedHashedPassword(User user, string password)
        {
            PasswordVerificationResult verification = passwordHasher.VerifyHashedPassword(user.UserId.ToString(), user.Password, password);
            bool result = true;


            if (verification.Equals(PasswordVerificationResult.Failed))
            {
                result = false;

            }

            return result;
        }
    }
}
