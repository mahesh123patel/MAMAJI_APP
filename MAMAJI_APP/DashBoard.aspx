<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="MAMAJI_APP.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
                        <h1 class="mt-4">Dashboard</h1>
                        <ol class="breadcrumb mb-4">
                            <li class="breadcrumb-item active">Dashboard</li>
                        </ol>
                        <div class="row">
                            <div class="col-xl-4 col-md-6">
                                <div class="card bg-primary text-white mb-4">
                                    <div class="card-body"style="text-align:center;font-weight:bolder">Open Complaint
                                         <h1><asp:Label ID="lblOpenCount" runat="server" Text="15"></asp:Label></h1>
                                    </div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <%--<a class="small text-white stretched-link" href="#">View Details</a>--%>
                                        <%--<asp:HyperLink CssClass="small text-white stretched-link"  runat="server" NavigateUrl="~/ComplaintPage/DisplayComplaintDetails.aspx">View Details</asp:HyperLink>--%>
                                        <asp:LinkButton ID="btnOpenDetails" CssClass="small text-white stretched-link"  runat="server" PostBackUrl="~/ComplaintPage/ComplaintList.aspx?st=o">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                           <%-- <div class="col-xl-3 col-md-6">
                                <div class="card bg-warning text-white mb-4">
                                    <div class="card-body">WIP Complaint</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <a class="small text-white stretched-link" href="#">View Details</a>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-xl-4 col-md-6">
                                <div class="card bg-success text-white mb-4">
                                    <div class="card-body" style="text-align:center;font-weight:bolder">Closed Complaint 
                                        <h1><asp:Label ID="lblClosedCount" runat="server" Text="250"></asp:Label></h1></div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <%--<a class="small text-white stretched-link" href="#">View Details</a>--%>
                                        <asp:LinkButton ID="btnClosedDetails" CssClass="small text-white stretched-link"  runat="server" PostBackUrl="~/ComplaintPage/ComplaintList.aspx?st=c">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-4 col-md-6">
                                <div class="card bg-danger text-white mb-4">
                                    <div class="card-body"style="text-align:center;font-weight:bolder">WIP Complaint
                                        <h1><asp:Label ID="lblWIPCount" runat="server" Text="150"></asp:Label></h1>
                                    </div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <%--<a class="small text-white stretched-link" href="#">View Details</a>--%>
                                        <asp:LinkButton ID="btnWipDetails" CssClass="small text-white stretched-link"  runat="server" PostBackUrl="~/ComplaintPage/ComplaintList.aspx?st=w">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-6">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-area me-1"></i>
                                        Area Chart Example
                                    </div>
                                    <div class="card-body"><canvas id="myAreaChart" width="100%" height="40"></canvas></div>
                                </div>
                            </div>
                            <div class="col-xl-6">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-bar me-1"></i>
                                        Bar Chart Example
                                    </div>
                                    <div class="card-body"><canvas id="myBarChart" width="100%" height="40"></canvas></div>
                                </div>
                            </div>
                        </div>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                DataTable Example
                            </div>
                            <div class="card-body">
                               
                            </div>
                        </div>
                    </div>
</asp:Content>
    