using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        // ctor yanına this(input) yapısı ile input ile ctor'a olanlarda çalışsın diyoruz.
        // bu seneryoda ikisi de çalışıyor. sadece success bilgisi gönderilirse sadece alttaki çalışır.
        public Result(bool success)
        {
            Success = success;
        }
    }
}
