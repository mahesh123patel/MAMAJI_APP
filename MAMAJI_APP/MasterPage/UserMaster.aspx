<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="MAMAJI_APP.MasterPage.UserMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
    <h1 class="mt-4">Complaint Type Master</h1>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                Complaint Type Details
                               <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Add User</button>
                            </div>
                            <div class="card-body">
                               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PersonInfoID" 
                                    CssClass="table table-striped table-bordered" OnRowEditing="GridView1_RowEditing" 
                                    OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="PersonInfoID" HeaderText="ID" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Mobile">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtMobile" runat="server" Text='<%# Bind("Mobile") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile No is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UserID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtUserID" runat="server" Text='<%# Bind("UserID") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvUserID" runat="server" ControlToValidate="txtUserID" ErrorMessage="UserID is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Password">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPassword" runat="server" Text="*********"></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPassword"  runat="server" Text='<%# Bind("Password") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="District">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("DistrictName") %>'></asp:Label>
                                               
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                 <asp:HiddenField ID="hdnDistrictID" runat="server" Value='<%# Bind("DistrictID") %>' />
                                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Block">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBlock" runat="server" Text='<%# Bind("BlockName") %>'></asp:Label>
                                                 
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hdnBlockID" runat="server" Value='<%# Bind("BlockID") %>' />
                                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("DesignationName") %>'></asp:Label>
                                                 
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hdnDesignationID" runat="server" Value='<%# Bind("DesignationID") %>' />
                                                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control">
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
        <h4 class="modal-title">Add User</h4>
      </div>
      <div class="modal-body">
        <div class="container-fluid">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter New Designation"></asp:TextBox>
                                            <label for="txtName">Name</label>
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"></asp:TextBox>
                                            <label for="txtMobile">Mobile Number</label>
                                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile No is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                            <label for="txtEmail">Email</label>
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" 
                                                CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                            <label for="txtAddress">Address</label>
                                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            <label for="ddlDistrict">District</label>
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            <label for="ddlBlock">Block</label>
                                        </div>
                                    </div>
                                  </div>
                                     <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            <label for="ddlDesignation">Designation</label>
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="Enter UserID"></asp:TextBox>
                                            <label for="txtUserID">UserID</label>
                                             <asp:RequiredFieldValidator ID="rfvUserID" runat="server" ControlToValidate="txtUserID" ErrorMessage="UserID is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                    <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
                                            <label for="txtPassword">Password</label>
                                             <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                  </div>
                                </div>
       </div>
      
      <div class="modal-footer">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" ValidationGroup="vg1" />
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
        </div>
</asp:Content>
