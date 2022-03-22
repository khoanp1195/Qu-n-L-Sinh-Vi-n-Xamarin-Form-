using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungQuanLy.Model;
using Xamarin.Forms;

namespace UngDungQuanLy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        async protected override void OnAppearing()
        {
            //base.OnAppearing();
            lstSinhVien.ItemsSource = await App.db.SinhVienList();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddSV());
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Grid grid = (Grid)button.Parent;
            Label id = grid.FindByName<Label>("lblId");
            Label name = grid.FindByName<Label>("lblName");
            Label ngaysinh = grid.FindByName<Label>("lblNgaySinh");
            Label gioitinh = grid.FindByName<Label>("lblGioiTinh");
            Label dienthoai = grid.FindByName<Label>("lblDienThoai");

            SinhVien sv = new SinhVien();
            sv.SinhVienId = Convert.ToInt32(id.Text);
            sv.HoTen = name.Text;
            sv.NgaySinh =Convert.ToDateTime(ngaysinh.Text);
            sv.GioiTinh = (gioitinh.Text == "True") ? true : false;
            sv.DienThoai = dienthoai.Text;
            Navigation.PushAsync(new AddSV(sv));
            

        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Grid grid = (Grid)button.Parent;
            Label id = grid.FindByName<Label>("lblId");
            SinhVien sv = await App.db.SinhVienGet(Convert.ToInt32(id.Text));
            int deleteId =  await App.db.SinhVienDelete(sv);
            lstSinhVien.ItemsSource = await App.db.SinhVienList(); // xóa xong nạp lại danh sách sv
        }
    }   
}
