using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration; 

namespace WebApplication1
{
    public partial class ThemNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //lay gia tri ket noi trong webconfig
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["QLNhanVienConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sql = "INSERT INTO NhanVien(honv,tennv,phai,ngaysinh,noisinh,maphong) values(@honv,@tennv,@phai,@ngaysinh,@noisinh,@maphong)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@honv", txtHoNV.Text);
            cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
            if (rdNam.Checked)
                cmd.Parameters.AddWithValue("@phai", true);
            else
                cmd.Parameters.AddWithValue("@phai", false);
            cmd.Parameters.AddWithValue("@ngaysinh", txtNgaySinh.Text);
            cmd.Parameters.AddWithValue("@noisinh", txtNoiSinh.Text);
            cmd.Parameters.AddWithValue("@maphong", ddlPhong.SelectedValue);
            //thuc hien truy van them nhan vien
            try
            {
                // Các dòng code để mở kết nối và thực thi câu lệnh SQL ở đây...

                if (cmd.ExecuteNonQuery() > 0)
                {
                    lbThongBao.Text = "Thêm Nhân Viên Thành Công!!!";
                    Response.Redirect("qlNhanVien.aspx");
                }
                else
                {
                    lbThongBao.Text = "Thêm Nhân Viên Thất Bại!!!";
                }
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Đã xảy ra lỗi: " + ex.Message;
            }
        }
    }
}