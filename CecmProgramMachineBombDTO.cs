using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    class CecmProgramMachineBombDTO
    {
		public long gid { get; set; }       //Khóa tự sinh
		public long cecm_machinebomb_id { get; set; }       //Máy dò
		public string cecm_machinebomb_idST { get; set; }
		public long dept_id { get; set; }       //Đơn vị
		public string dept_idST { get; set; }
		public long cecm_program_id { get; set; }       //Dự án
		public string cecm_program_idST { get; set; }
		public long staff_id { get; set; }      //Người phụ trách
		public string staff_idST { get; set; }
		public string description { get; set; }     //Mô tả
		public string code { get; set; }        //Số đăng ký
		public string mac_id { get; set; }      //MAC id
		public long type_machine { get; set; }      //Dòng máy
		public string type_machineST { get; set; }
		public long status { get; set; }        //Trạng thái
		public string statusST { get; set; }
		public string time_test { get; set; }       //Thời gian KĐ tới
		public string time_testST { get; set; }
		public long type_standart { get; set; }     //Loại thiết bị
		public string type_standartST { get; set; }
		public long type_standart_detail { get; set; }      //Loại tiêu chuẩn
		public string type_standart_detailST { get; set; }
	}
}
