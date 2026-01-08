using ProjectName.Application.Common;

namespace ProjectName.Api.Extensions;

public static class ResultResponseExtensions
{
    public static object ToApiResponse(this ResultResponse result)
    {
        var dataProperties = result.GetType()
                                   .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                                   .Where(p => p.DeclaringType != typeof(ResultResponse))
                                   .ToDictionary(p => p.Name, p => p.GetValue(result));

        return new
        {
            success = result.IsSuccess,
            data = result.IsSuccess ? dataProperties : null,
            errors = result.IsSuccess ? null : result.Errors
        };
    }
}
