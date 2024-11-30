<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="SearchComplaint.aspx.cs" Inherits="MAMAJI_APP.ComplaintPage.SearchComplaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
    <h1 class="mt-4">Complaint Search</h1>
        <div class="card mb-4">
            <div class="card-body">
                <div class="container text-center">
                    <div class="row">
                    <%-- <div class="col-3">
                        Designation
                    </div>--%>
                    <div class="col-8">
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtComplaintNo" runat="server" CssClass="form-control" placeholder="Enter Complaint number"></asp:TextBox>
                            <label for="txtComplaintNo">Complaint Number</label>
                        </div>
                    </div>
                    <div class="col-4">
                        <asp:Button ID="btnSearchComplaint" runat="server" Text="Search Complaint" CssClass="btn btn-primary btn-block" OnClick="btnSearchComplaint_Click"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-block" OnClick="btnReset_Click"/>
                    </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card mb-4" id="CompDetailsDiv" runat="server" visible="false">
            <div class="card-header">
                <i class="fas fa-table me-1"></i>
                Complaint Details       
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
            </div>
        </div>
        <div class="card mb-4" id="CompRemarkDiv" runat="server" visible="false">
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
