using System;

namespace JWTOnNetCore.Models
{
    public class SimpleMessage
    {
        public string Message { get; set; }
        public string By { get; set; }
        public DateTime DateTime { get; set; }
    }
}