using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Store.Extension
{
    public static class ApiResponseExtension
    {
        public static ApiResponse<T> ResultSuccess<T>(this T data)
        {
            return new ApiResponse<T> { Success = true, Data = data };
        }

        public static ApiResponse<List<T>> ResultSuccess<T>(this List<T> data)
        {
            return new ApiResponse<List<T>> { Success = true, Data = data };
        }

        public static ApiResponse<T> ResultError<T>(this T data, string error)
        {
            return new ApiResponse<T> { Success = false, Data = data , Messages = new List<string>() { error } };
        }

        public static ApiResponse<T> ResultError<T>(this T data, List<string> errors)
        {
            return new ApiResponse<T> { Success = false, Data = data , Messages = errors };
        }

        public static ApiResponse<T> ResultError<T>(this T data, ModelStateDictionary dictionary)
        {
            List<string> errors = new List<string>();

            foreach (var modelState in dictionary.Values) 
            {
                foreach (ModelError error in modelState.Errors) 
                    errors.Add(error.ErrorMessage);
            }
            
            return new ApiResponse<T> { Success = false, Data = data , Messages = errors };
        }
    }
}