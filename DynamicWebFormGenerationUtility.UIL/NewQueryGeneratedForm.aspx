<%@ Page Language="C#" MasterPageFile="~/CommonMaster.Master" AutoEventWireup="true" CodeBehind="NewQueryGeneratedForm.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.NewQueryGeneratedForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        
        .panel-heading {
            height: 40px;
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
	Query Builder
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="box box-warning">
        <div class="box-header with-border ">
            <a id="lnkDetails" data-toggle="tooltip" title="Add Details" data-placement="top" runat="server" class="btn btn-primary pull-left" onserverclick="tab_Click">
                <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             
            <span class="pull-right"><a id="lnklist" class="btn btn-success" data-toggle="tooltip" data-placement="left" title="View Details" runat="server" onserverclick="tab_Click">
                <i class="fa fa-eye"></i></a></span>
        </div>
        <div class="box-body">
            <div class="tab-content">
                <div id="Details" class="tab-pane fade in active" clientidmode="static" runat="server">
                    <div class="form-horizontal form-border">
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Query Name</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtQueryName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vgSave" ErrorMessage="Please Select Query Name" ControlToValidate="txtQueryName" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMinInputValue" runat="server" ValidationGroup="vgSave" ErrorMessage="Space not Allow" ControlToValidate="txtQueryName" Display="Dynamic" CssClass="code" ForeColor="Red" ValidationExpression="[^\s]+"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Form Name</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlFormname" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFormname_SelectedIndexChanged" CssClass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Please Select Form name" ControlToValidate="ddlFormname" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="control-form col-sm-1 col-xs-12">
                            </div>
                            <div class="control-form col-sm-10 col-xs-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <h4>Columns Configuration & Filteration </h4>
                                    </div>
                                    <div class="panel-body" style="max-height: 350px; overflow: auto;">
                                        <table id="example3" class="table table-bordered table-striped dt1" style="height: 30%">
                                            <asp:ListView ID="lstvQualifyingHeadMaster" runat="server">
                                                <LayoutTemplate>
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                <asp:CheckBox ID="Chk_selectAll" runat="server" onclick="chkSelectMulti(this,'Chk_selectAll','Chk_select');" /></th>
                                                            <th>Sr.No</th>
                                                            <th>Columns</th>
                                                            <th>Condition</th>
                                                            <th>Condition Value</th>
                                                            <th>Operator</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="Chk_select" runat="server" Checked="false" /></td>
                                                        <td><%# Container.DataItemIndex + 1%></td>
                                                        <td>
                                                            <asp:Label ID="lblColumnName" runat="server" Text='<%# Eval("ConfigurationHeadName")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfDKId" Value='<%# Eval("ConfigurationHeadId")%>' runat="server" />
                                                            <asp:HiddenField ID="hfDKName" Value='<%# Eval("ConfigurationHeadName")%>' runat="server" />

                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlConditon" runat="server">
                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="<"></asp:ListItem>
                                                                <asp:ListItem Text="Grater Than" Value=">"></asp:ListItem>
                                                                <asp:ListItem Text="Like" Value="Like"></asp:ListItem>
                                                                <asp:ListItem Text="Equal To" Value="="></asp:ListItem>
                                                                <asp:ListItem Text="Not Equal To" Value="!="></asp:ListItem>
                                                            </asp:DropDownList>

                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtConditionValue" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlOperator" runat="server">
                                                                <asp:ListItem Text="AND" Value="AND "></asp:ListItem>
                                                                <asp:ListItem Text="OR" Value="OR "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                                            </asp:ListView>
                                            <tr>
                                                <td>&nbsp;&nbsp;&nbsp; </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>

                            </div>
                            <div class="control-form col-sm-1 col-xs-12">
                            </div>
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                            <div class=" col-sm-5 col-xs-6">
                            </div>
                            <div class=" col-sm-6 col-xs-6">
                                <asp:Button ID="btnSave" runat="server" ValidationGroup="vgSave" CssClass="btn btn-submit" Text="Submit" CausesValidation="true" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-reset" Text="Reset" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div id="list" class="tab-pane fade" runat="server" visible="true">
                    <div class="form-group">
                        <div class="control-form col-sm-2 col-xs-3">
                        </div>
                        <label class="control-label col-sm-2 col-xs-1">Query Name</label><div class="control-form col-sm-4 col-xs-4">
                            <asp:DropDownList ID="ddlQuery" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="ddlQuery_selectedindexchanged">
                                <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Please Select Form name" ControlToValidate="ddlFormname" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                        <div class="control-form col-sm-2 col-xs-2">
                            <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-primary" Text="Refresh" Visible="false" OnClick="BtnRefresh_Click" />
                            <%--<asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>--%>

                        </div>
						         <div class="control-form col-sm-2 col-xs-2">
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="delete" Visible="false" OnClick="BtnDelete_Click" />
                            <%--<asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>--%>

                        </div>
                    </div>
                    
                        <asp:GridView ID="QueryGrid" class="table table-bordered table-striped dt1" runat="server" Width="99%" GridLines="Both"  >

                            <Columns>
							<%--	<asp:TemplateField ShowHeader="False" ItemStyle-Width ="5%">
            <ItemTemplate >
               	<asp:Button data-toggle="tooltip"  ID="btnDelete"  runat="server"   OnClientClick="return confirm('Are you sure you want to export all data?');"  Text ="Delete" CssClass="btn btn-danger" > </asp:Button>
                           
            </ItemTemplate>
        </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Sr No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
								
		                
							 </Columns>

                        </asp:GridView>
                    
                </div>


            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#example3').DataTable({
                "paging": false,
                "ordering": false,
                "info": false,
                "searching": false
            });
        });
    </script>
</asp:Content>


