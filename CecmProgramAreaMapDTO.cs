using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    public class CecmProgramAreaMapDTO
    {
        private string comboboxName_;
        public long? cecmProgramAreaMapId { get; set; }
        public long? cecmProgramId { get; set; }
        public long? cecmProgramAreaId { get; set; }
        public long? cecmProgramStationId { get; set; }
        public double? positionLat { get; set; }
        public double? positionlong { get; set; }
        public string polygon { get; set; }
        public long? parentId { get; set; }
        public long? parentIdDistrict { get; set; }
        public long? parentIdCommune { get; set; }
        public long? villageId { get; set; }
        public string address { get; set; }
        public string code { get; set; }
        public string comboboxName 
        {
            get 
            {
                if (!string.IsNullOrEmpty(comboboxName_))
                {
                    return comboboxName_;
                }
                if (!string.IsNullOrEmpty(address))
                {
                    return code + " - " + address;
                }
                else
                {
                    return code;
                }
            }
            set 
            {
                comboboxName_ = value; 
            } 
        }
        public string polygonGeom { get; set; }
        public string polygonGeomST { get; set; }
        public string pointGeomST { get; set; }
        public string doc_file { get; set; }
        public string photo_file { get; set; }
        public string vn2000 { get; set; } //Tọa độ vn 2000
        public double? positionlongVN2000 { get; set; }
        public double? positionLatVN2000 { get; set; }
        public double? meridian { get; set; }
        public long? pzone { get; set; }
        public double? lx { get; set; }
        public double? ly { get; set; }
        public string cecmProgramStationIdST { get; set; }
        public string cecmProgramIdST { get; set; }
        public double? areamap { get; set; }

        public double? bottom_lat { get; set; }
        public double? top_lat { get; set; }
        public double? left_long { get; set; }
        public double? right_long { get; set; }
    }
}
