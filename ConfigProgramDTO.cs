using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    class ConfigProgramDTO
	{
		public string defaultSortField { get; set; }
		public string gid { get; set; }
		public string cecm_program_id { get; set; }
		public string cecm_program_idST { get; set; }
		public string cecm_program_code { get; set; }
		public string username { get; set; }
		public string config_id { get; set; }
		public string config_idST { get; set; }
		public string config_code { get; set; }

		

		public string config_name { get; set; }     //Tên cấu hình
		public string time { get; set; }        //Thời gian
		public string speed { get; set; }       //Tốc độ
		public string is_checkIP { get; set; }
		public string is_checkIPST { get; set; }
		public string status { get; set; }
		public string statusST { get; set; }
		public string ip_address { get; set; }  //Địa chỉ IP"":null
		
		public string fwmodelId { get; set; }
	}
}
