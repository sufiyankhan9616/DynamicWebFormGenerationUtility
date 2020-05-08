<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.Master" AutoEventWireup="true" CodeBehind="TemplateMaster.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.TemplateMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Template Drop Down Form
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="box box-warning">
        <div class="box-header with-border ">
            <a id="lnkDetails" data-toggle="tooltip" title="Add Details" data-placement="top" runat="server" class="btn btn-primary pull-left" onserverclick="tab_Click">
                <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             <span class="">
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Delete Detail(s)" ID="btnDeleteSelected" runat="server" CssClass="btn btn-danger" OnClientClick="return CheckBoxValidate();" OnClick="btnDeleteSelected_Click"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>
                 &nbsp; 
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click1"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
             </span>
            <span class="pull-right"><a id="lnklist" class="btn btn-success" data-toggle="tooltip" data-placement="left" title="View Details" runat="server" onserverclick="tab_Click">
                <i class="fa fa-eye"></i></a></span>
        </div>
        <div class="box-body">
            <asp:HiddenField ID="hfPKEdit" Value="0" runat="server" />
            <div class="tab-content">
                <div id="Details" class="tab-pane fade in active" clientidmode="static" runat="server">
                    <div class="form-horizontal form-border">
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Template Drop Down Name<b class="redAstric">*</b></label><div class="control-form col-sm-6 col-xs-12">
                                <asp:TextBox ID="txttemplatename" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtQualifyingHeadName" runat="server" ValidationGroup="vgSave" InitialValue="" ErrorMessage="Please Enter Head Name" ControlToValidate="txttemplatename" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                             
                            </div>
                        </div>
                        <div class="form-group">
                            <div class=" col-sm-4 col-xs-12"></div>
                            <div class=" col-sm-6 col-xs-12">
                                <asp:Button ID="btnSave" runat="server" ValidationGroup="vgSave" CssClass="btn btn-submit" Text="Submit" OnClick="btnSave_Click" CausesValidation="true" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="list" class="tab-pane fade" clientidmode="static" runat="server">

                <table id="example1" class="table table-bordered table-striped dt1">
                    <asp:ListView ID="lstvTemplateMaster" runat="server" OnItemCommand="lstvTemplateMaster_ItemCommand">
                        <LayoutTemplate>
                            <thead>

                                <tr>
                                    <th>
                                        <asp:CheckBox ID="Chk_selectAll" runat="server" onclick="chkSelectMulti(this,'Chk_selectAll','Chk_select');" /></th>
                                    <th>Edit</th>
                                    <th>Sr No.</th>
                                    <th>Template DropDown Name</th>
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
                                <td style="text-align: center;">
                                    <asp:LinkButton ID="aEdit" CommandName="EditData" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TemplateDropDownId") %>' runat="server" title="Edit" class="fa fa-edit" data-placement="bottom" rel="tooltip" data-original-title="Edit"><i class="icon-edit"></i></asp:LinkButton></td>
                                <td><%# Container.DataItemIndex + 1%></td>
                                <td><%# Eval("TemplateDropDownName")%></td>
                                <asp:HiddenField ID="hfDKId" Value='<%# Eval("TemplateDropDownId")%>' runat="server" />
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
