namespace CarRentalSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using Application.Features.Identity.Commands.LoginUser;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ApiController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(UserInputModel model)
        {
            var result = await this.identity.Register(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
       => await this.Mediator.Send(command).ToActionResult();

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return this.Ok(this.User.Identity.Name);
        }
    }
}
