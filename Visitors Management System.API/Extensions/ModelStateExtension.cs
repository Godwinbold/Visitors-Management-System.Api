using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Visitors_Management_System.API.Extensions
{
	public class ModelStateExtension
	{
		public static IEnumerable<Error> GetErrors(this ModelStateDictionary modelState)
		{
			var errors = modelState
				.Where(e => e.Value!.ValidationState == ModelValidationState.Invalid)
				.SelectMany(e => e.Value!.Errors, (key, error) => new Error(key.Key, error.ErrorMessage));

			return errors;
		}
	}
}
