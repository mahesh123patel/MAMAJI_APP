<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="MAMAJI_APP.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
    <h2 class="mt-4">Complaint Registration</h2>
                        <div class="card mb-4">
                            <div class="card-body">
                               <div class="container text-center">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating">
                                           Public Key
                                        </div>
                                    </div>
                                  </div>
                                   <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating">
                                            <asp:Label ID="PublicKey" runat="server" ></asp:Label>
                                           
                                        </div>
                                    </div>
                                  </div>
                                   <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            Private Key
                                        </div>
                                    </div>
                                  </div>
                                   <div class="row">
                                    <div class="col-12">
                                        <div class="form-floating mb-3">
                                            <asp:Label ID="PrivateKey" runat="server" ></asp:Label>
                                           
                                        </div>
                                    </div>
                                  </div>
                                   </div>
                                </div></div>
        </div>
</asp:Content>
