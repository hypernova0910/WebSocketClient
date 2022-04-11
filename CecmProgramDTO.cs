using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    public class CecmProgramDTO
    {

        public long cecmProgramId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int isActive { get; set; }
        public string address { get; set; }
        public string startTimeST { get; set; }
        public string endTimeST  { get; set; }

        public string deptId { get; set; }
        public string deptName { get; set; }
        public string stt { get; set; }
        public long departmentMaster { get; set; }



    }
}
