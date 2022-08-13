using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities
{
    public class BaseResult
    {
        public BaseResult()
        {
            this.Data = null;
            Success = true;
            Message = "";
            Code = 200;
        }
        public BaseResult(object? Data)
        {
            this.Data = Data;
            Success = true;
            Message = "";
            Code = 200;
        }

        public BaseResult(Exception exception)
        {
            Data = null;
            Success = false;
            Message = exception.Message;
            Code = 400;
        }
        public bool Success { get; set; }
        public int Code { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
