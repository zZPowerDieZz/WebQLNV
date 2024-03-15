<%@ Page Title="" Language="C#" MasterPageFile="~/ql.Master" AutoEventWireup="true" CodeBehind="ThemNhanVien.aspx.cs" Inherits="WebApplication1.ThemNhanVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noiDung" runat="server">
    <h2 class="text-center">Thêm nhân viên</h2>
    <div class="row mt-3 mb-2 ">
        <div class="col-md-2">Họ nhân viên</div>
        <div class="col-md-10">
            <asp:TextBox ID="txtHoNV" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-2">Tên nhân viên</div>
        <div class="col-md-10">
            <asp:TextBox ID="txtTenNV" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-2">Phái</div>
        <div class="col-md-10 ">
            <asp:RadioButton ID="rdNam" runat="server" GroupName="GT" Text="Nam" Checked="true"/>
            <asp:RadioButton ID="rdNu" runat="server" GroupName="GT" Text="Nữ"/>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-2">Ngày sinh</div>
        <div class="col-md-10">
            <asp:TextBox ID="txtNgaySinh" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-2">Nơi sinh</div>
        <div class="col-md-10">
            <asp:TextBox ID="txtNoiSinh" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-2">Phòng</div>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlPhong" runat="server" CssClass="form-control" DataSourceID="dsPhong" DataTextField="TenPhong" DataValueField="MaPhong"></asp:DropDownList>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-2"></div>
        <div class="col-md-10">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-primary"/>
            <asp:Label ID="lbThongBao" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <asp:SqlDataSource ID="dsPhong" runat="server" ConnectionString="<%$ ConnectionStrings:QLNhanVienConnectionString %>" SelectCommand="SELECT * FROM [PhongBan]"></asp:SqlDataSource>
</asp:Content>
