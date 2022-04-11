using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    public class ServiceResult
    {
        public long id { get; set; }
        public string error { get; set; }
        public string errorType { get; set; }
        public string constraintName { get; set; }
        public bool hasError { get; set; }
    }
}
