using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KouMobilio.WebAPI;

public static class CustomValidationResponse
{
    public static IActionResult ValidationResponse(ActionContext context)
    {
        var messages = new List<string>();
        
        string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
                "The input was not valid." :
                error.ErrorMessage;
        }

        foreach (var keyModelStatePair in context.ModelState)
        {
            var errors = keyModelStatePair.Value.Errors.Select(GetErrorMessage);
            messages.AddRange(errors);
        }

        return new BadRequestObjectResult(new
        {
            StatusCode = (int) HttpStatusCode.BadRequest,
            Messages = messages
        });
    }
}