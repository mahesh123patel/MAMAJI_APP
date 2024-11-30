<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ComplaintRegistration.aspx.cs" Inherits="MAMAJI_APP.ComplaintPage.ComplaintRegistration1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://hinkhoj.com/api/hindi-typing/js/keyboard.js"></script>
    <link rel="stylesheet" type="text/css"
        href="https://hinkhoj.com/api/hindi-typing/css/keyboard.css" />

    <div class="container-fluid px-4">
        <%--  	AssignOfficerID	ISBlocked--%>
        <h2 class="mt-4">Complaint Registration</h2>
        <div class="card mb-4">
            <div class="card-body">
                <div class="container text-center">
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtComplaintName" runat="server" CssClass="form-control" placeholder="Enter Complaint Name"></asp:TextBox>
                                <label for="txtComplaintName">Complaint Name</label>
                                <asp:RequiredFieldValidator ID="rfvComplaintName" runat="server" ControlToValidate="txtComplaintName" ErrorMessage="Complaint Name is required." CssClass="text-danger" ValidationGroup="vg1" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtComplaintAddress" runat="server" CssClass="form-control" placeholder="Enter Complaint Address"></asp:TextBox>
                                <label for="txtComplaintAddress">Complaint Address</label>
                                <asp:RequiredFieldValidator ID="rfvComplaintAddress" runat="server" ControlToValidate="txtComplaintAddress" ErrorMessage="Complaint Address is required." CssClass="text-danger" ValidationGroup="vg1" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Enter Mobile No"></asp:TextBox>
                                <label for="txtMobileNo">Mobile No</label>
                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Complaint Mobile No is required." CssClass="text-danger" ValidationGroup="vg1" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label for="ddlDistrict">District</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlVidhanshabha" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlVidhanshabha_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label for="ddlVidhanshabha">Vidhanshabha</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlUpkhand" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlUpkhand_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label for="ddlUpkhand">Upkhand</label>
                            </div>
                        </div>
                    </div>
                      <div class="row">
      <div class="col-12">
          <div class="form-floating mb-3">
              <asp:DropDownList ID="ddlBlock" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
              </asp:DropDownList>
              <label for="ddlBlock">Block </label>
          </div>
      </div>
  </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlTahsil" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlTahsil_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label for="ddlTahsil">Tahsil</label>
                            </div>
                        </div>
                    </div>
                  
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlThana" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <label for="ddlThana">Thana</label>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="visibility:hidden">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <label for="ddlVillage">Village</label>
                            </div>
                        </div>
                    </div>
             
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlConType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <label for="ddlConType">Complaint Type</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="form-floating mb-3">
                                <%--<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter Complaint Description"></asp:TextBox>--%>
                                <script language="javascript">
                                    CreateHindiTextArea("txtDescription");
                                </script>
                                <label for="txtDescription">Complaint Description</label>
                                <%--<asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Complaint Description is required." CssClass="text-danger" ValidationGroup="vg1" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-floating mb-3">
                            <asp:FileUpload ID="FileUploadControl" runat="server" AllowMultiple="true" CssClass="form-control" />
                            <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-floating mb-3">
                            <asp:DropDownList ID="ddlOfficer" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <label for="ddlOfficer">Officer</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-floating mb-3">
                            <asp:Button ID="ComplaintSubmit" runat="server" OnClick="ComplaintSubmit_Click" Text="Submit" CssClass="btn btn-primary" ValidationGroup="vg1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
