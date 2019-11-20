using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skopei.Models
{
    public class Result<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
    }
}