using System.Collections.Generic;

namespace Store.Extension
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public IEnumerable<string> Messages { get; set; }
    }
}