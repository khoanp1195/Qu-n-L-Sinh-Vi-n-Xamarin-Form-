using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace UngDungQuanLy.Model
{
    public class SinhVien
    {
       [PrimaryKey, AutoIncrement]
       public int SinhVienId { get; set; }
       public string HoTen { get; set; }
       public DateTime NgaySinh { get; set; }
       public  bool GioiTinh { get; set; }
       public string DienThoai { get; set; }
    }
}
