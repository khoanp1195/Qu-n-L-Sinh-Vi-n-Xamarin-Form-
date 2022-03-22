using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungQuanLy.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UngDungQuanLy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSV : ContentPage
    {
        int id = 0;

        public AddSV(SinhVien sv = null)
        {
            InitializeComponent();

            if (sv != null)
            {
                id = sv.SinhVienId;
                txtHoTen.Text = sv.HoTen;
                txtDienThoai.Text = sv.DienThoai;
                txtNgaySinh.Date = sv.NgaySinh;
                pkGioiTinh.SelectedIndex = (sv.GioiTinh == true) ? 0 : 1;
            }
            else
                id = 0;

        }
        

        private void btnThem_Clicked(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.SinhVienId = id;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = txtNgaySinh.Date;
            sv.GioiTinh = (pkGioiTinh.SelectedItem.ToString() == "Nam") ? true : false;
            sv.DienThoai = txtDienThoai.Text;
            App.db.SinhVienSave(sv);
            Navigation.PopAsync();


        }
    }
}   