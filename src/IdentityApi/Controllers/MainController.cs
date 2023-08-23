using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdentityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainController : ControllerBase
{
    protected ICollection<string> Errors = new List<string>();

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) ReportModelInvalidError(modelState);


        return CustomResponse();
    }
    protected ActionResult CustomResponse(object result = null)
    {

        if (ValidOperation())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = Errors.ToArray()
        });



    }


    protected void ReportModelInvalidError(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
            AddProcessingError(errorMessage);
        }
    }
    protected bool ValidOperation()
    {
        return !Errors.Any();
    }

    protected void AddProcessingError(string erro)
    {
        Errors.Add(erro);
    }

    protected void ClearProcessingError()
    {
        Errors.Clear();
    }
}
