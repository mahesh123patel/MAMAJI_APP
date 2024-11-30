<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="DisplayComplaintDetails.aspx.cs" Inherits="MAMAJI_APP.ComplaintPage.DisplayComplaintDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
        <div class="card mb-4">
            <div class="card-header">
                <i class="fas fa-table me-1"></i>
                Complaint Details       
            </div>
            <div class="card-body">
                <asp:GridView runat="server" ID="GV1"></asp:GridView>
            </div>
            <div class="card-body">

                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Complaint Number :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblComplaintID" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Complaint Name :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblComplaintName" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">District :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblDistrict" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Block :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblBlockID" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Complaint Address :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblComplaintAddress" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Complaint Type :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblConTypeID" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Mobile No :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblMobileNo" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Description :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblDescription" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Assign Officer :</label>
                    <div class="col-sm-9">
                        <asp:Label ID="lblAssignOfficerID" runat="server" CssClass="form-control-plaintext" />
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col-sm-9 offset-sm-2">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />

                    </div>
                </div>

            </div>
        </div>
        <div class="card mb-4">
            <div class="card-header">
                <i class="fas fa-table me-1"></i>
                Complaint Remark Details       
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ComplaintRemarkID"
                    CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="Remark By">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarkByName" runat="server" Text='<%# Bind("RemarkBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark Date">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarkDate" runat="server" Text='<%# Bind("RemarkDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
