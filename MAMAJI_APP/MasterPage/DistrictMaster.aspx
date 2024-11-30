<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="DistrictMaster.aspx.cs" Inherits="MAMAJI_APP.MasterPage.DistrictMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid px-4">
    <h1 class="mt-4">District Master</h1>
                        <div class="card mb-4">
                            <div class="card-body">
                               <div class="container text-center">
                                  <div class="row">
                                   <%-- <div class="col-3">
                                      Designation
                                    </div>--%>
                                    <div class="col-4">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtDistrictEng" runat="server" CssClass="form-control" placeholder="Enter District English Name"></asp:TextBox>
                                            <label for="inputFirstName">District (English)</label>
                                             <asp:RequiredFieldValidator ID="rfvDistrictEng" runat="server" ControlToValidate="txtDistrictEng" ErrorMessage="District English Name is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                      <div class="col-4">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtDistrictHin" runat="server" CssClass="form-control" placeholder="Enter District Hindi Name"></asp:TextBox>
                                            <label for="inputFirstName">District (Hindi)</label>
                                              <asp:RequiredFieldValidator ID="rfvDistrictHin" runat="server" ControlToValidate="txtDistrictHin" ErrorMessage="District Hindi Name is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                    <div class="col-4">
                                      <asp:Button ID="btnAddDistrict" runat="server" Text="Add Designation" ValidationGroup="vg1" CssClass="btn btn-primary btn-block" OnClick="btnAddDistrict_Click"/>
                                    </div>
                                  </div>
                                </div>
                            </div>
                        </div>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                District Details
                            </div>
                            <div class="card-body">
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DistrictID" 
                                    CssClass="table table-striped table-bordered" OnRowEditing="GridView1_RowEditing" 
                                    OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="DistrictID" HeaderText="ID" ReadOnly="True" />
        
                                        <asp:TemplateField HeaderText="District Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistrictName" runat="server" Text='<%# Bind("DistrictName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDistrictName" runat="server" Text='<%# Bind("DistrictName") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvDistrictName" runat="server" ControlToValidate="txtDistrictName" ErrorMessage="District English Name is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                           
                                        </asp:TemplateField>
        
                                        <asp:TemplateField HeaderText="District Hindi Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistrictHindiName" runat="server" Text='<%# Bind("DistrictHindiName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDistrictHindiName" runat="server" Text='<%# Bind("DistrictHindiName") %>' CssClass="form-control" />
                                         <asp:RequiredFieldValidator ID="rfvDistrictHindiName" runat="server" ControlToValidate="txtDistrictHindiName" ErrorMessage="District Hindi Name is required." CssClass="text-danger" ValidationGroup="vg2" />
                                            </EditItemTemplate>
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("ISBlocked").ToString() == "A" ? "Active" : "Block" %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="A">Active</asp:ListItem>
                                                    <asp:ListItem Value="B">Block</asp:ListItem>
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
                    </div>
</asp:Content>
