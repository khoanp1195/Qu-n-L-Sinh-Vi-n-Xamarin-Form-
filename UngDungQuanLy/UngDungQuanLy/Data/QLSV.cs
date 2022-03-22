using System;
using System.Collections.Generic;
using System.Text;
using UngDungQuanLy.Model;
using SQLite;
using System.Threading.Tasks;

namespace UngDungQuanLy.Data
{
   public class QLSV
    {
        private SQLiteAsyncConnection csdl;
        public QLSV(string duongdan)
        {
            csdl = new SQLiteAsyncConnection(duongdan);
            csdl.CreateTableAsync<SinhVien>().Wait();   //tạo bảng 
            //Wait() chờ đến khi nào tạo xong
        }

        //Thêm danh sách sinh vien
        public Task <List<SinhVien>> SinhVienList()
        {
            return csdl.Table<SinhVien>().ToListAsync();
        }

        //Tìm Sinh Viên theo ID
        public Task <SinhVien> SinhVienGet(int id)
        {
            return csdl.Table<SinhVien>().Where(s => s.SinhVienId == id).FirstOrDefaultAsync();
        }

        //Cập nhật Sinh Viên
        public Task <int> SinhVienSave(SinhVien sv)
        {
            if (sv.SinhVienId == 0)
                return csdl.InsertAsync(sv);
            else
                return csdl.UpdateAsync(sv);
        }

        //Xóa Sinh Viên
        public Task<int> SinhVienDelete(SinhVien sv)
        {
            return csdl.DeleteAsync(sv);
        }


    }
}
