<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.Master" AutoEventWireup="true" CodeBehind="TemplateDataBinding.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.TemplateDataBinding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Template Data Configuration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script>
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45' || keyEntry == '13' || keyEntry == '44' || keyEntry != '46' && keyEntry > '31' && (keyEntry < '48' || keyEntry > '57'))
                return true;
            else {
                alert('Please Enter Only Character values.');
                return false;
            }
        }
    </script>
    <div class="box box-warning">
        <div class="box-header with-border ">
            <a id="lnkDetails" data-toggle="tooltip" title="Add Details" onserverclick="tab_Click" data-placement="top" runat="server" class="btn btn-primary pull-left">
                <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             <span class="">
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Delete Detail(s)" ID="btnDeleteSelected" runat="server" CssClass="btn btn-danger" OnClick="btnDeleteSelected_Click"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>
                 &nbsp; 
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
             </span>
            <span class="pull-right"><a id="lnklist" class="btn btn-success" data-toggle="tooltip" data-placement="left" title="View Details" runat="server" onserverclick="tab_Click">
                <i class="fa fa-eye"></i></a></span>
        </div>
        <div class="box-body">
            <asp:HiddenField ID="hfPKEdit" Value="0" runat="server" />
            <div class="tab-content">
                <div class="form-horizontal form-border">

                    <div runat="server" id="divRadioButton" class="form-group">
                        <label class="control-label col-sm-4 col-xs-12">Select DataBinding Type</label>
                        <div class="control-form col-sm-6 col-xs-12">
                            <asp:RadioButtonList ID="rblDataBinding" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblDataBinding_SelectedIndexChanged">
                                <asp:ListItem Value="1">Normal Dropdown &nbsp; &nbsp; </asp:ListItem>

                                <asp:ListItem Value="2">  Cascading Dropdown</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div runat="server" id="DivNormal" class="tab-pane fade in active" clientidmode="static" visible="false">
                    <div class="form-horizontal form-border">

                        <div runat="server" id="Divform" class="form-group">
                            <div class="form-group">
                                <label class="control-label col-sm-4 col-xs-4">Template Master</label><div class="control-form col-sm-6 col-xs-6">
                                    <asp:DropDownList ID="ddlTamplateMaster" runat="server" CssClass="form-control select2">
                                        <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Please Select Template Master" ControlToValidate="ddlTamplateMaster" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4 col-xs-4">Enter Value</label><div class="control-form col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtDropdownValue" runat="server"  CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Enter Textbox Value." ControlToValidate="txtDropdownValue" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class=" col-sm-4 col-xs-12"></div>
                                <div class=" col-sm-6 col-xs-12">
                                    <asp:Button ID="btnSave" runat="server" ValidationGroup="vgSave" CssClass="btn btn-submit" Text="Submit" OnClick="btnSave_Click" CausesValidation="true" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-reset" Text="Reset" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <div runat="server" id="DivCascading" class="tab-pane fade in active" clientidmode="static" visible="false">
                    <div class="form-horizontal form-border">
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Base Tamplate</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlBaseTamplate" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="ddlBaseTamplate_SelectedIndexChanged">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="VGCascadingSave" InitialValue="0" ErrorMessage="Please Select Base Template" ControlToValidate="ddlBaseTamplate" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Base Tamplate Values</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlBaseTemplateValue" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="ddlBaseTemplateValue_SelectedIndexChanged">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="VGCascadingSave" InitialValue="0" ErrorMessage="Please Select Base Template Value" ControlToValidate="ddlBaseTemplateValue" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Tamplate</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlTemplate" runat="server" CssClass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="VGCascadingSave" InitialValue="0" ErrorMessage="Please Select Template " ControlToValidate="ddlTemplate" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Tamplate Value</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:TextBox ID="txttemplate" TextMode="MultiLine" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="VGCascadingSave" InitialValue="0" ErrorMessage="Enter Textbox Value." ControlToValidate="txttemplate" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class=" col-sm-4 col-xs-12"></div>
                            <div class=" col-sm-6 col-xs-12">
                                <asp:Button ID="btnCascadingSave" runat="server" ValidationGroup="VGCascadingSave" CssClass="btn btn-submit" Text="Submit" OnClick="btnCascadingSave_Click" CausesValidation="true" />
                                <asp:Button ID="btnCascadingReset" runat="server" CssClass="btn btn-reset" Text="Reset" OnClick="btnCascadingReset_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-body">
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
                                            <th>ParameterName</th>
                                            <th>BaseParameterName</th>
                                            <th>CreatedDate</th>
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
                                            <asp:LinkButton ID="aEdit" CommandName="EditData" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ParameterId") %>' runat="server" title="Edit" class="fa fa-edit" data-placement="bottom" rel="tooltip" data-original-title="Edit"><i class="icon-edit"></i></asp:LinkButton></td>
                                        <td><%# Container.DataItemIndex + 1%></td>
                                        <td><%# Eval("ParameterName")%></td>
                                        <td><%# Eval("BaseParameterName")%></td>
                                        <td><%# Eval("CreateDate")%></td>
                                        <asp:HiddenField ID="hfDKId" Value='<%# Eval("TamplateDropDownId")%>' runat="server" />
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                            </asp:ListView>
                        </table>
                    </div>

                </div>
            </div>
        </div>
</asp:Content>


