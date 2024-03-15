<%@ Page Title="" Language="C#" MasterPageFile="~/ql.Master" AutoEventWireup="true" CodeBehind="qlPhongBan.aspx.cs" Inherits="WebApplication1.qlPhongBan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noiDung" runat="server" >

    <h2 class="text-center">DANH SÁCH PHÒNG BAN</h2>

    <asp:SqlDataSource ID="dsPhongBan" runat="server" ConnectionString="<%$ ConnectionStrings:QLNhanVienConnectionString %>" 
        SelectCommand="SELECT * FROM [PhongBan]"></asp:SqlDataSource>
    <asp:DropDownList CssClass="row m-auto w-25" ID="ddlPhongBan" runat="server" DataSourceID="dsPhongBan" DataTextField="TenPhong" AutoPostBack="true" DataValueField="MaPhong"></asp:DropDownList>
    <asp:SqlDataSource ID="dsNhanVienPhongBan" runat="server" ConnectionString="<%$ ConnectionStrings:QLNhanVienConnectionString %>"
        DeleteCommand="DELETE FROM [NhanVien] WHERE [MaNV] = @MaNV" 
        SelectCommand="SELECT * FROM [NhanVien] WHERE ([MaPhong] = @MaPhong)">
       <DeleteParameters>
            <asp:Parameter Name="MaNV" Type="Int32" />
        </DeleteParameters>  
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlPhongBan" Name="MaPhong" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>

    </asp:SqlDataSource>
    <br>
    <asp:GridView ID="gvNhanVien" runat="server" AutoGenerateColumns="False" CssClass="row-cols-6 m-auto w-75" DataKeyNames="MaNV" DataSourceID="dsNhanVienPhongBan" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="MaNV" HeaderText="Mã nhân viên" ReadOnly="True" />
            <asp:BoundField DataField="HoNV" HeaderText="Họ nhân viên" />
            <asp:BoundField DataField="TenNV" HeaderText="Tên nhân viên"/>
            <asp:CheckBoxField DataField="Phai" HeaderText="Phái"/>
            <asp:BoundField DataField="NgaySinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày sinh"/>
            <asp:BoundField DataField="NoiSinh" HeaderText="Nơi sinh"/>
            <asp:BoundField DataField="MaPhong" HeaderText="Mã phòng"/>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" /> 
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />

        <HeaderStyle CssClass="text-light" />  
        <EmptyDataTemplate>
            <div class="alert alert-warning">
                 Không có nhân viên nào thuộc phòng ban này
            </div>
        </EmptyDataTemplate> 
    </asp:GridView>
</asp:Content>
