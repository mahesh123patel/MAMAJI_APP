<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="DesignationMaster.aspx.cs" Inherits="MAMAJI_APP.MasterPage.DesignationMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
                        <h1 class="mt-4">Designation Master</h1>
                        <div class="card mb-4">
                            <div class="card-body">
                               <div class="container text-center">
                                  <div class="row">
                                   <%-- <div class="col-3">
                                      Designation
                                    </div>--%>
                                    <div class="col-9">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" placeholder="Enter New Designation"></asp:TextBox>
                                            <label for="inputFirstName">Designation</label>
                                            <asp:RequiredFieldValidator ID="rfvTextBox1" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation is required." CssClass="text-danger" ValidationGroup="vg1" />
                                        </div>
                                    </div>
                                    <div class="col-3">
                                      <asp:Button ID="btnAddDesignation" runat="server" Text="Add Designation" CssClass="btn btn-primary btn-block" OnClick="btnAddDesignation_Click" ValidationGroup ="vg1"/>
                                    </div>
                                  </div>
                                </div>
                            </div>
                        </div>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                Designation Details
                            </div>
                            <div class="card-body">
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DesignationID" 
                                     CssClass="table table-striped table-bordered" OnRowEditing="GridView1_RowEditing" 
                                     OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                     OnRowDeleting="GridView1_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="DesignationID" HeaderText="ID" ReadOnly="True" />
                                         <asp:TemplateField HeaderText="Designation Name" >
                                             <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("DesignationName") %>'></asp:Label>
                                             </ItemTemplate>
                                             <EditItemTemplate>
                                                <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Bind("DesignationName") %>' CssClass="form-control" />
                                                 <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation is required." CssClass="text-danger" ValidationGroup="vg2" />

                                             </EditItemTemplate>
                                             </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Statuss">
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
