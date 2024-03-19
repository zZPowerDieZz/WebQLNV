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
    public partial class ThemTinTuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //lấy giá trị chuỗi kết nối trong web.config
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["QLNhanVienConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sql = "INSERT INTO bantin(tieude,tomtat,noidung,hinh,ngaydang,trangthai,theloaiid)" + " values(@tieude,@tomtat,@noidung,@hinh,@ngaydang,@trangthai,@theloaiid)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tieude", txtTieuDe.Text);
            cmd.Parameters.AddWithValue("@tomtat", txtTomTat.Text);
            cmd.Parameters.AddWithValue("@noidung", txtNoiDung.Text);
            if (FHinh.HasFile)
            {
                //xử lý upload hình
                string duong_dan = Server.MapPath("~/Upload/") + FHinh.FileName;
                FHinh.SaveAs(duong_dan);
                cmd.Parameters.AddWithValue("@hinh", FHinh.FileName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@hinh", "no_image.png");
            }
                
            cmd.Parameters.AddWithValue("@ngaydang", txtNgayDang.Text);
            cmd.Parameters.AddWithValue("@trangthai", chkTrangThai.Checked);
            cmd.Parameters.AddWithValue("@theloaiid", ddlTheLoai.SelectedValue);
            //thực hiện câu lệnh truy vấn đến CSDL
                if (cmd.ExecuteNonQuery() > 0)
                    Response.Redirect("qlTinTuc.aspx");
                else
                    lbThongBao.Text = "Thao tác thêm tin Thất Bại!!!";
           
        }
    }
}