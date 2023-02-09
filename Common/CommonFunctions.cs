using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketClient
{
    class CommonFunctions
    {
        //MULTIPOLYGON(((106.90945 21.24169,107.2214 21.11845,107.2214 20.87967,106.68994 20.79495,106.65913 21.28405,106.88635 21.38033,106.90945 21.24169)))
        public static List<PointF[]> convertMultiPolygon(CecmProgramAreaMapDTO dto, Size size)
        {
            List<PointF[]> lst = new List<PointF[]>();
            if(dto == null || size == null)
            {
                return lst;
            }
            string multiPolygon = dto.polygonGeom;
            if (string.IsNullOrEmpty(multiPolygon))
            {
                return lst;
            }
            multiPolygon = multiPolygon.Replace("MULTI", "");
            multiPolygon = multiPolygon.Replace("POLYGON", "");
            multiPolygon = multiPolygon.Replace(")))(((", "_");
            multiPolygon = multiPolygon.Replace("(((", "");
            multiPolygon = multiPolygon.Replace(")))", "");
            //multiPolygon.Replace("((", "(");
            //multiPolygon.Replace("))", ")");
            multiPolygon = multiPolygon.Replace(")),((", "_");
            string[] polygons = multiPolygon.Split("_".ToCharArray());
            foreach(string polygon in polygons)
            {
                if (dto.left_long != null && dto.right_long != null
                    && dto.top_lat != null && dto.bottom_lat != null
                    && dto.left_long < dto.right_long && dto.bottom_lat < dto.top_lat)
                {
                    List<PointF> points = new List<PointF>();
                    string[] coordinates = polygon.Split(",".ToCharArray());
                    foreach (string coordinate in coordinates)
                    {
                        string[] latLong = coordinate.Split(" ".ToCharArray());
                        double lat = double.Parse(latLong[1]);
                        double lon = double.Parse(latLong[0]);
                        //if (lat > dto.top_lat || lat < dto.bottom_lat ||
                        //   lon > dto.right_long || lon < dto.left_long)
                        //{
                        //    continue;
                        //}
                        float x = (float)(size.Width * (lon - dto.left_long) / (dto.right_long - dto.left_long));
                        float y = (float)(size.Height * (1 - (lat - dto.bottom_lat) / (dto.top_lat - dto.bottom_lat)));
                        PointF point = new PointF(x, y);
                        points.Add(point);
                    }
                    if(points.Count > 0)
                    {
                        lst.Add(points.ToArray());
                    }
                }
            }
            return lst;
        }

        private const string pathKey = "Software\\WEBSOCKET\\RecentInput";

        public static void SaveRecentInput(Control ctrl)
        {
            string key = string.Format("${0}${1}", ctrl./*Parent*/TopLevelControl.Name, ctrl.Name);

            string value = ctrl.Text;
            if (ctrl is RadioButton)
            {
                value = (ctrl as RadioButton).Checked == true ? "true" : "false";
            }
            else if (ctrl is CheckBox)
            {
                value = (ctrl as CheckBox).Checked == true ? "true" : "false";
            }
            SaveRecentInput(key, value);
        }

        public static bool SaveRecentInput(string name, string value)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(pathKey);
                if (key == null)
                {
                    return false;
                }
                else
                {
                    key.SetValue(name, value);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                ////MyLogger.Log("Không ghi được registry {0}", ex.Message);
                return false;
            }
        }

        public static void LoadRecentInput(Control ctrl, string def)
        {
            string key = string.Format("${0}${1}", ctrl./*Parent*/TopLevelControl.Name, ctrl.Name);
            string value = GetRecentInput(key);
            if (value != null)
            {
                if (ctrl is ComboBox)
                {
                    var combobox = ctrl as ComboBox;
                    if (combobox.Items.Count == 0)
                        return;
                    int index = combobox.FindStringExact(value);
                    if (index != -1)
                        combobox.SelectedIndex = index;
                }
                else if (ctrl is RadioButton)
                {
                    if (value == "true" || value == "false")
                    {
                        var rad = ctrl as RadioButton;
                        rad.Checked = value == "true" ? true : false;
                    }
                }
                else if (ctrl is CheckBox)
                {
                    if (value == "true" || value == "false")
                    {
                        var rad = ctrl as CheckBox;
                        rad.Checked = value == "true" ? true : false;
                    }
                }
                else
                    ctrl.Text = value;
            }
            else
            {
                if (ctrl is ComboBox || ctrl is RadioButton || ctrl is CheckBox)
                {
                    return;
                }
                if (string.IsNullOrEmpty(def) == false)
                    ctrl.Text = def;
            }
        }

        public static string GetRecentInput(string name)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(pathKey);
                if (key == null)
                {
                    return null;
                }
                else
                {
                    var obj = key.GetValue(name);
                    if (obj != null && key.GetValueKind(name) == RegistryValueKind.String)
                    {
                        return obj.ToString();
                    }
                }
                return null;
            }
            catch (System.Exception ex)
            {
                ////MyLogger.Log("Không đọc được registry {0}", ex.Message);
                return null;
            }
        }
    }
}
