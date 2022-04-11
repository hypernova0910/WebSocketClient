using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
     public class HistoryConnectDTO
    {
        public string defaultSortField { get; set; }
        public long gid { get; set; }
        public long cecm_program_id { get; set; }
        public string cecm_program_idST { get; set; }
        public string cecm_program_name { get; set; }
        public string cecm_program_code { get; set; }
        public string username { get; set; }
        public string deptid { get; set; }
        public string deptidST { get; set; }
        public string dept_name { get; set; }
        public string dept_address { get; set; }
        public string dept_email { get; set; }
        public string dept_phone { get; set; }
        public string dept_manager { get; set; }
        public string dept_managerST { get; set; }
        public string status { get; set; }
        public string statusST { get; set; }
        public string time_start { get; set; }
        public string time_startST { get; set; }
        public string time_end { get; set; }
        public string time_endST { get; set; }
        public long fwmodelId { get; set; }
    }
}
