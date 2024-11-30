<%@ Page Title="Complaint List" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="ComplaintList.aspx.cs" Inherits="MAMAJI_APP.ComplaintPage.ComplaintList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="gvComplaints" runat="server" AutoGenerateColumns="False" 
                  CssClass="table table-striped table-bordered" AllowPaging="True" 
                  PageSize="20" OnPageIndexChanging="gvComplaints_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ComplaintID" HeaderText="Complaint ID" />
            <asp:BoundField DataField="ComplaintName" HeaderText="Complaint Name" />
            <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
            <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
            <asp:BoundField DataField="ComplaintAddress" HeaderText="Address" />
            <asp:BoundField DataField="ConType" HeaderText="Con Type" />
            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="OfficerName" HeaderText="Officer Name" />
        </Columns>
    </asp:GridView>
</asp:Content>