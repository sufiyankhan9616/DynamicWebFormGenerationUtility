<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.Master" AutoEventWireup="true" CodeBehind="SummaryQueryBuilder.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.SummaryQueryBuilder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
	Summary Query Builder
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="box box-warning">

        <div class="box-header with-border ">
            <a id="lnkDetails" data-toggle="tooltip" title="Add Details" data-placement="top" runat="server" class="btn btn-primary pull-left" onserverclick="tab_Click">
                <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             <span class="">
                 <%--     <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Delete Detail(s)" ID="btnDeleteSelected" runat="server" CssClass="btn btn-danger" OnClientClick="return CheckBoxValidate();" OnClick="btnDeleteSelected_Click"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>
                 &nbsp; 
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>--%>
             </span>
            <span class="pull-right"><a id="lnklist" class="btn btn-success" data-toggle="tooltip" data-placement="left" title="View Details" runat="server" onserverclick="tab_Click">
                <i class="fa fa-eye"></i></a></span>
        </div>
        <div class="box-body">

            <div id="Details" class="tab-pane fade in active" clientidmode="static" runat="server">
                <div class="form-horizontal form-border">
					
					<div class="form-group"><label class="control-label col-sm-4 col-xs-12">Form Name</label><div class="control-form col-sm-6 col-xs-12">
					<asp:dropdownlist id="ddlFormname" autopostback="true" onselectedindexchanged="ddlFormMaster_SelectedIndexChanged" runat="server" cssclass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Please Select Form Name" ControlToValidate="ddlFormname" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
						</div>
                    <div class="form-group">
                        <label class="control-label col-sm-4 col-xs-12">Query Name</label><div class="control-form col-sm-6 col-xs-12">
                            <asp:DropDownList ID="ddlColumn" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="ddlFormname_SelectedIndexChanged">
                                <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                            </asp:DropDownList>
	 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Please Select Query Name" ControlToValidate="ddlColumn" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                   
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-4 col-xs-12">Summary Query Name</label><div class="control-form col-sm-6 col-xs-12">
                            <asp:TextBox ID="txtQueryName" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vgSave" InitialValue="" ErrorMessage="Please Enter Summary Query Name" ControlToValidate="txtQueryName" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>


                        </div>
                    </div>

                    <div class="form-group">
                        <div class="control-form col-sm-1 col-xs-12">
                        </div>
                        <div class="control-form col-sm-10 col-xs-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4>Query Configuration</h4>
                                </div>
                                <div class="panel-body" style="max-height: 350px; overflow: auto;">
                                    <table id="example3" class="table table-bordered table-striped dt1" style="height: 30%">
                                        <asp:ListView ID="lstSummaryQueryBuilder" runat="server" OnSelectedIndexChanged="lstSummaryQueryBuilder_SelectedIndexChanged">
                                            <LayoutTemplate>
                                                <thead>
                                                    <tr>
                                                        <th></th>
                                                        <th>Column Name</th>
                                                        <th>Group By </th>
                                                        <th>Alias</th>
                                                        <th>Is Group by</th>

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

                                                    <td>
                                                        <asp:Label ID="lblColumnName" runat="server" Text='<%# Eval("ConfigurationHeadName")%>'></asp:Label>
                                                        <asp:HiddenField ID="hfDKId" Value='<%# Eval("ConfigurationHeadId")%>' runat="server" />
                                                        <asp:HiddenField ID="HiddenField1" Value='<%# Eval("ConfigurationHeadId")%>' runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAggrigate" DataTextField="ParameterName" AutoPostBack="true" DataValueField="ParameterValue" DataSource='<%# BindChildDropDownFromTemplateDropDownId(Eval("InputTypeId").ToString()) %>' runat="server" OnSelectedIndexChanged="ddlAggrigate_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblinputtypid"   runat="server" Visible="false" Text='<%# Eval("InputTypeId")%>'></asp:Label>
                                                        <asp:TextBox ID="txtAliyas" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsgroupby" runat="server" Checked="true" Enabled="false" AutoPostBack="true" OnCheckedChanged="chkIsgroupby_CheckedChanged" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                                        </asp:ListView>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class=" col-sm-5 col-xs-6">
                        </div>
                        <div class=" col-sm-6 col-xs-6">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="vgSave" CssClass="btn btn-submit" Text="Submit" CausesValidation="true" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-reset" Text="Reset" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="list" class="tab-pane fade" clientidmode="static" runat="server">
                <div class="form-group">
                    
                    <label class="control-label col-sm-2 col-xs-1">Summary Query Name</label><div class="control-form col-sm-4 col-xs-4">
                        <asp:DropDownList ID="ddlQuery" runat="server" CssClass="form-control select2" >
                            <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="srh" InitialValue="0" ErrorMessage="Please Select Summary Query name" ControlToValidate="ddlQuery" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="control-form col-sm-2 col-xs-2">
                        <asp:Button ID="btnRefresh" runat="server" ValidationGroup="srh" CssClass="btn btn-primary" Text="Search" Visible="true" OnClick="btnRefresh_Click" />
                        <%--<asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>--%>
                    </div>
					 <div class="control-form col-sm-2 col-xs-2">
                        <asp:Button ID="btnDelete" runat="server"  CssClass="btn btn-danger" Text="Delete" Visible="true" OnClick="btnDelete_Click" />
                        <%--<asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>--%>
                    </div>
                </div>
			
                
                    <asp:GridView ID="QueryGrid" class="table table-bordered table-striped dt1" runat="server" Width="99%" GridLines="Both"  >

                        <Columns>
                            <asp:TemplateField HeaderText="Sr No">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
							<%--<asp:TemplateField ShowHeader="False" ItemStyle-Width ="5%">
            <ItemTemplate >
               	<asp:Button data-toggle="tooltip"  ID="btnDelete"  runat="server"   OnClientClick="return confirm('Are you sure you want to export all data?');"  Text ="Delete" CssClass="btn btn-danger" > </asp:Button>
                           
            </ItemTemplate>
        </asp:TemplateField>--%>
                        </Columns>

                    </asp:GridView>
               

            </div>

        </div>
    </div>

</asp:Content>
