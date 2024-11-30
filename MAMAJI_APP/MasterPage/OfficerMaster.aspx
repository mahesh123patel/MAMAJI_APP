<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="OfficerMaster.aspx.cs" Inherits="MAMAJI_APP.MasterPage.OfficerMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid px-4">
    <h1 class="mt-4">Officer Master</h1>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                Officer Details
                               <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Add Officer</button>
                            </div>
                            <div class="card-body">
                               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OfficerID" 
                                    CssClass="table table-striped table-bordered" OnRowEditing="GridView1_RowEditing" 
                                    OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="OfficerID" HeaderText="ID" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("OfficerName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("OfficerName") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Officer Name is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("OfficerMobile") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtMobile" runat="server" Text='<%# Bind("OfficerMobile") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Officer Mobile is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfficerEmail" runat="server" Text='<%# Bind("OfficerEmail") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtOfficerEmail" runat="server" Text='<%# Bind("OfficerEmail") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtOfficerEmail" ErrorMessage="Officer Email is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfficerDesignation" runat="server" Text='<%# Bind("OfficerDesignation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtOfficerDesignation" runat="server" Text='<%# Bind("OfficerDesignation") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="txtOfficerDesignation" ErrorMessage="Officer Designation is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfficerDistrict" runat="server" Text='<%# Bind("OfficerDistrictName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                 <asp:HiddenField ID="hdnOfficerDistrictID" runat="server" Value='<%# Bind("OfficerDistrict") %>' />
                                                <asp:DropDownList ID="ddlOfficerDistrict" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("ISBlocked").ToString() == "A" ? "Active" : "Blocked" %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("ISBlocked") %>' />
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="A">Active</asp:ListItem>
                                                    <asp:ListItem Value="B">Blocked</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-sm" />
                                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger btn-sm" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm" ValidationGroup="vg2"/>
                                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-sm" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                   

  <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog modal-lg"> <!-- Adjust modal size if needed (e.g., modal-lg for large) -->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Add Officer</h4>
      </div>
      <div class="modal-body">
        <div class="container-fluid">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtOfficerName" runat="server" CssClass="form-control" placeholder="Enter Officer Name"></asp:TextBox>
                                            <label for="txtOfficerName">Officer Name</label>
                                             <asp:RequiredFieldValidator ID="rfvOfficerName" runat="server" ControlToValidate="txtOfficerName" ErrorMessage="Officer Name is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtOfficerMobile" runat="server" CssClass="form-control" placeholder="Enter Officer Mobile Number"></asp:TextBox>
                                            <label for="txtOfficerMobile">Officer Mobile Number</label>
                                             <asp:RequiredFieldValidator ID="rfvOfficerMobile" runat="server" ControlToValidate="txtOfficerMobile" ErrorMessage="Officer Mobile Number is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtOfficerEmail" runat="server" CssClass="form-control" placeholder="Enter Officer Email"></asp:TextBox>
                                            <label for="txtOfficerEmail">Officer Email</label>
                                             <asp:RequiredFieldValidator ID="rfvOfficerEmail" runat="server" ControlToValidate="txtOfficerEmail" ErrorMessage="Officer Email is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:DropDownList ID="ddlOfficerDistrict" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            <label for="ddlOfficerDistrict">Officer District</label>

                                        </div>
                                    </div>
                                  </div>
                                      <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtOfficerDesignation" runat="server" CssClass="form-control" placeholder="Enter Officer Designation"></asp:TextBox>
                                            <label for="txtOfficerDesignation">Officer Designation</label>
                                             <asp:RequiredFieldValidator ID="rfvOfficerDesignation" runat="server" ControlToValidate="txtOfficerDesignation" ErrorMessage="Officer Designation is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                </div>
       </div>
      
      <div class="modal-footer">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click1" ValidationGroup="vg1" />
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
        </div>
</asp:Content>
