<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="NewBroadcast.aspx.cs" Inherits="MAMAJI_APP.Utilities.NewBroadcast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
        <h2 class="mb-4">Broadcast</h2>
       <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                Broadcast Details
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Add New Broadcast</button>
                            </div>
                            <div class="card-body">
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BroadcastID" 
                                    CssClass="table table-striped table-bordered" OnRowEditing="GridView1_RowEditing" 
                                    OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowDeleting="GridView1_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="BroadcastID" HeaderText="ID" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Broadcast">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBroadCastType" runat="server" Text='<%# Bind("BroadcastType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                               <asp:Label ID="lblBroadCastType" runat="server" Text='<%# Bind("BroadcastType") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Broadcast Message">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBroadcastMessage" runat="server" Text='<%# Bind("Broadcast") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtBroadcastMessage" runat="server" Text='<%# Bind("Broadcast") %>' CssClass="form-control" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Broadcast Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBroadcastRemark" runat="server" Text='<%# Bind("BroadcastRemark") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtBroadcastRemark" runat="server" Text='<%# Bind("BroadcastRemark") %>' CssClass="form-control" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Release Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReleaseStatus" runat="server" Text='<%# Eval("ReleaseStatus").ToString() == "Y" ? "Yes" : "No" %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlReleaseStatus" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("BroadcastStatus").ToString() == "A" ? "Active" : "Block" %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlBroadcastStatus" runat="server" CssClass="form-control">
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
                                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm" />
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
        <h4 class="modal-title">Add New Broadcast</h4>
      </div>
      <div class="modal-body">
    <div class="form-group">
                 <div class="row">
                     
                     
                    <div class="col-3">   
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="functionality" id="radioMessage" value="message" checked onclick="toggleFunctionality()">
                    <label class="form-check-label" for="radioMessage">Broadcast Message</label>
                </div>
                        </div>
                      <div class="col-3">
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="functionality" id="radioImage" value="image" onclick="toggleFunctionality()">
                    <label class="form-check-label" for="radioImage">Upload Image</label>
                </div>
                          </div>
                      <div class="col-3">
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="functionality" id="radioVideo" value="video" onclick="toggleFunctionality()">
                    <label class="form-check-label" for="radioVideo">Upload Video Link</label>
                </div>
                          </div>
                     
            </div>
               
            <div class="form-group" id="messageGroup">
                <label for="message">Message</label>
                <asp:TextBox ID="message" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>

            <div class="form-group" id="imageGroup" style="display: none;">
                <div class="row">
                <label for="imageUpload">Upload Image</label>
                <asp:FileUpload ID="imageUpload" runat="server" CssClass="form-control-file" />
                    </div>
                <div class="row">
                    <label for="ImageRemark">Remark</label>
                <asp:TextBox ID="ImageRemark" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group" id="videoGroup" style="display: none;">
                <div class="row">
                <label for="videoLink">Video Link</label>
                <asp:TextBox ID="videoLink" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                <div class="row">
                    <label for="VideoRemark">Remark</label>
                <asp:TextBox ID="VideoRemark" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>       
    </div>
   </div>
      
      <div class="modal-footer">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
         </div>
    <script>
        function toggleFunctionality() {
            var messageGroup = document.getElementById('messageGroup');
            var imageGroup = document.getElementById('imageGroup');
            var videoGroup = document.getElementById('videoGroup');

            if (document.getElementById('radioMessage').checked) {
                messageGroup.style.display = 'block';
                imageGroup.style.display = 'none';
                videoGroup.style.display = 'none';
            } else if (document.getElementById('radioImage').checked) {
                messageGroup.style.display = 'none';
                imageGroup.style.display = 'block';
                videoGroup.style.display = 'none';
            } else if (document.getElementById('radioVideo').checked) {
                messageGroup.style.display = 'none';
                imageGroup.style.display = 'none';
                videoGroup.style.display = 'block';
            }
        }
    </script>
</asp:Content>
