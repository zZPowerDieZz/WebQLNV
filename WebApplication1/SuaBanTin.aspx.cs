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
    public partial class SuaBanTin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //b1.lấy giá trị id của bản tin
                int id = int.Parse(Request.QueryString["id"]);
                //b2.truy cập CSDL để đọc bản tin theo ID
                //lấy giá trị chuỗi kết nối trong web.config
                string chuoi_ket_noi = ConfigurationManager.ConnectionStrings["QLNhanVienConnectionString"].ConnectionString;
                //  Tạo đối tượng Connection
                SqlConnection conn = new SqlConnection(chuoi_ket_noi);
                conn.Open();
                //tạo đối tượng thực thi truy vấn dữ liệu
                SqlCommand cmd = new SqlCommand("select * from bantin where id=" + id, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                //b3.hiển thị trong tin lên trang sửa tin tức
                if (rd.Read())
                {
                    txtTieuDe.Text = rd["tieude"].ToString();
                    txtTomTat.Text = rd["tomtat"].ToString();
                    txtNoiDung.Text = rd["noidung"].ToString();
                    txtNgayDang.Text = rd["ngaydang"].ToString();
                    ddlTheLoai.SelectedValue = rd["theloaiid"].ToString();
                    chkTrangThai.Checked = bool.Parse(rd["trangthai"].ToString());
                    oldImg.ImageUrl = "upload/" + rd["hinh"].ToString();
                    lbOldImg.Text = rd["hinh"].ToString();


                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //lấy giá trị chuỗi kết nối trong Web.config
            string chuoi_ket_noi = ConfigurationManager.ConnectionStrings["QLNhanVienConnectionString"].ConnectionString;
            //tạo đối tượng Connection
            SqlConnection conn = new SqlConnection(chuoi_ket_noi);
            conn.Open();
            //tạo câu sql để sửa tin tức
            string sql = "update bantin set tieude=@tieude,tomtat=@tomtat,noidung=@noidung,hinh=@hinh,ngaydang=@ngaydang,trangthai=@trangthai,theloaiid=@theloaiid " +
               " where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //truyền giá trị cho các tham số trong câu lệnh sql
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
            else //không chọn hình mới
            {
                cmd.Parameters.AddWithValue("@hinh", lbOldImg.Text);
            }

            cmd.Parameters.AddWithValue("@ngaydang", txtNgayDang.Text);
            cmd.Parameters.AddWithValue("@trangthai", chkTrangThai.Checked);
            cmd.Parameters.AddWithValue("@theloaiid", ddlTheLoai.SelectedValue);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

            //thực hiện câu lệnh truy vấn đến CSDL
            if (cmd.ExecuteNonQuery() > 0)
                Response.Redirect("qlTinTuc.aspx");
            else
                lbThongBao.Text = "Thao tác cập nhật bản tin thất bại";
        }
    }
}