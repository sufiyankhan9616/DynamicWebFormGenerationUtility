<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.Master" AutoEventWireup="true" CodeBehind="ConfigurationForm.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.ConfigurationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Configuration Form
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="box box-warning">
        <div class="box-header with-border ">
            <a id="lnkDetails" data-toggle="tooltip" title="Add Details" data-placement="top" runat="server" class="btn btn-primary pull-left" onserverclick="tab_Click">
                <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             <span class="">
                 <asp:linkbutton data-toggle="tooltip" data-placement="top" title="Delete Detail(s)" id="btnDeleteSelected" runat="server" cssclass="btn btn-danger" onclientclick="return CheckBoxValidate();" onclick="btnDeleteSelected_Click"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:linkbutton>
                 &nbsp; 
                 <asp:linkbutton data-toggle="tooltip" data-placement="top" title="Export To Excel" id="btnExportExcel" runat="server" onclientclick="return confirm('Are you sure you want to export all data?');" cssclass="btn btn-info" onclick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:linkbutton>
             </span>
            <span class="pull-right"><a id="lnklist" class="btn btn-success" data-toggle="tooltip" data-placement="left" title="View Details" runat="server" onserverclick="tab_Click">
                <i class="fa fa-eye"></i></a></span>
        </div>
        <div class="box-body">
            <asp:hiddenfield id="hfPKEdit" value="0" runat="server" />
            <div class="tab-content">
                <div id="Details" class="tab-pane fade in active" clientidmode="static" runat="server">
                    <div class="form-horizontal form-border">
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Form Name</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:dropdownlist id="ddlFormname" autopostback="true" onselectedindexchanged="ddlFormname_SelectedIndexChanged" runat="server" cssclass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" validationgroup="vgSave" initialvalue="0" errormessage="Please Select Form name" controltovalidate="ddlFormname" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Form Component</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:dropdownlist id="ddlFormComponent" runat="server" cssclass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" validationgroup="vgSave" initialvalue="0" errormessage="Please Select Form Component" controltovalidate="ddlFormComponent" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Head Name<b class="redAstric">*</b></label><div class="control-form col-sm-6 col-xs-12">
                                <asp:textbox id="txtQualifyingHeadName" runat="server" cssclass="form-control" maxlength="200"></asp:textbox>
                                <asp:requiredfieldvalidator id="rfvtxtQualifyingHeadName" runat="server" validationgroup="vgSave" initialvalue="" errormessage="Please Enter Head Name" controltovalidate="txtQualifyingHeadName" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Head Note<%--<b class="redAstric">*</b>--%></label><div class="control-form col-sm-6 col-xs-12">
                                <asp:textbox id="txtHeadNoteforStudent" runat="server" cssclass="form-control" maxlength="500"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Input Type<b class="redAstric">*</b></label><div class="control-form col-sm-6 col-xs-12">
                                <asp:dropdownlist id="ddlInputType" runat="server" cssclass="form-control select2" autopostback="true" onselectedindexchanged="ddlInputType_SelectedIndexChanged">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                                <asp:requiredfieldvalidator id="rfvddlInputType" runat="server" validationgroup="vgSave" initialvalue="0" errormessage="Please Select Input Type " controltovalidate="ddlInputType" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>
                            </div>
                            <div class="control-label col-sm-10 col-xs-12">
                                <asp:label id="lblDescription" class="text-green" runat="server" visible="false"></asp:label>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="divMinMaxValues" visible="false">
                            <label class="control-label col-sm-4 col-xs-12">Minimum Input Value </label>
                            <div class="control-form col-sm-1 col-xs-12">
                                <asp:textbox id="txtMinInputValue" maxlength="10" runat="server" cssclass="form-control"></asp:textbox>
                                <asp:regularexpressionvalidator id="revMinInputValue" runat="server" validationgroup="vgSave" errormessage="Value Be More Than Zero" controltovalidate="txtMinInputValue" display="Dynamic" cssclass="code" forecolor="Red" validationexpression="^?[0-9]\d*(\.\d+)?$"></asp:regularexpressionvalidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4 col-xs-12">Maximum Input Value</label>
                                <div class="control-form col-sm-1 col-xs-12">
                                    <asp:textbox id="txtMaxInputValue" maxlength="10" runat="server" cssclass="form-control"></asp:textbox>
                                    <asp:regularexpressionvalidator id="revtxtMaxInputValue" runat="server" validationgroup="vgSave" errormessage="Value Be More Than Zero" controltovalidate="txtMaxInputValue" display="Dynamic" cssclass="code" forecolor="Red" validationexpression="^?[0-9]\d*(\.\d+)?$"></asp:regularexpressionvalidator>

                                </div>
                                <asp:comparevalidator id="CompareValidator2" runat="server" type="Double" controltocompare="txtMinInputValue"
                                    controltovalidate="txtMaxInputValue" operator="GreaterThan" errormessage="Maximum Input Value should be greater than Minimum Input Value" forecolor="Red" validationgroup="vgSave"></asp:comparevalidator>
                            </div>

                        </div>
                        <div class="form-group" runat="server" id="divMinMaxDate" visible="false">
                            <label class="control-label col-sm-4 col-xs-12">Minimum Date Value </label>
                            <div class="control-form col-sm-2">
                                <asp:textbox id="txtMinDate" maxlength="10" runat="server" cssclass="form-control datepicker1"></asp:textbox>
                                <%-- <asp:RequiredFieldValidator ID="rfvtxtMinDate" runat="server" ValidationGroup="vgSave" ErrorMessage="Please Enter Minimum Date" ControlToValidate="txtMinDate" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2 col-xs-12">Maximum Date Value</label>
                                <div class="control-form col-sm-2">
                                    <asp:textbox id="txtMaxDate" runat="server" maxlength="10" cssclass="form-control datepicker1"></asp:textbox>
                                    <%--  <asp:RequiredFieldValidator ID="rfvtxtMaxDate" runat="server" ValidationGroup="vgSave" ErrorMessage="Please Enter Maximum Date" ControlToValidate="txtMaxDate" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>

                        </div>
						 <div class="form-group" runat="server"  >
                            <Div class="control-label col-sm-12 col-xs-12">
						     <%--<asp:comparevalidator id="CompareValidatordate" runat="server" type="Date" controltocompare="txtMinDate"
                                    controltovalidate="txtMaxDate" operator="GreaterThan" errormessage="Maximum Input date should be greater than Minimum  Input date" forecolor="Red" validationgroup="vgSave"></asp:comparevalidator>--%>

                           </div> 
							 </div> 
                        <div class="form-group" runat="server" id="divRegex" visible="false">
                            <label class="control-label col-sm-4 col-xs-12">Validation Type</label>
                            <div class="control-form col-sm-6 col-xs-12">
                                <asp:dropdownlist id="ddlValidationType" runat="server" cssclass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="DivMaxLength" visible="false">
                            <label class="control-label col-sm-4 col-xs-12">Max Length</label>
                            <div class="control-form col-sm-6 col-xs-12">
                                <asp:textbox id="txtMaxLength" maxlength="5" textmode="Number" runat="server" cssclass="form-control"></asp:textbox>
                            </div>
                        </div>


                        <div class="form-group" runat="server" id="divTemplateDropdownMaster" visible="false">
                            <label class="control-label col-sm-4 col-xs-12">Template Dropdown Master</label>
                            <div class="control-form col-sm-6 col-xs-12">
                                <asp:dropdownlist id="ddlTemplateDropdownMaster" runat="server" cssclass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                                <asp:requiredfieldvalidator id="rfvddlTemplateDropdownMaster" runat="server" validationgroup="vgSave" initialvalue="0" errormessage="Please Select Template Dropdown Master" controltovalidate="ddlTemplateDropdownMaster" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>

                            </div>
                        </div>

                        <div class="form-group" runat="server" id="divChildDropdown" visible="false">
                            <label class="control-label col-sm-4 col-xs-12">Child Dropdown Head</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:dropdownlist id="ddlChildDropDownHead" runat="server" cssclass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" validationgroup="vgSave" initialvalue="0" errormessage="Please Select Child DropDown Head" controltovalidate="ddlChildDropDownHead" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Head Display Preference No<b class="redAstric">*</b></label><div class="control-form col-sm-6 col-xs-12">
                                <asp:textbox id="txtQualifyingHeadDisplayPreferenceNo" maxlength="10" runat="server" cssclass="form-control"></asp:textbox>
                                <asp:requiredfieldvalidator id="rfvtxtQualifyingHeadDisplayPreferenceNo" runat="server" validationgroup="vgSave" initialvalue="" errormessage="Please Enter Head Display Preference No" controltovalidate="txtQualifyingHeadDisplayPreferenceNo" display="Dynamic" cssclass="code" forecolor="Red"></asp:requiredfieldvalidator>
                                <asp:regularexpressionvalidator id="revtxtQualifyingHeadDisplayPreferenceNo" runat="server" validationgroup="vgSave" errormessage="Value Be More Than Zero" controltovalidate="txtQualifyingHeadDisplayPreferenceNo" display="Dynamic" cssclass="code" forecolor="Red" validationexpression="[0-9]?[0-9]?(\.[0-9][0-9][0-9]?)?"></asp:regularexpressionvalidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Is Compulsory Entry</label><div class="control-form col-sm-2 col-xs-12">
                                <asp:checkbox id="chkIsCompulsaryEntry" runat="server" checked="false" />
                            </div>
							<label class="control-label col-sm-2 col-xs-12">Is Searchable Control</label><div class="control-form col-sm-2 col-xs-6">
                                <asp:checkbox id="chkSarchableDrp" runat="server" checked="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Is Unique Key</label>
                            <div class="control-form col-sm-2 col-xs-12">
                                <asp:checkbox id="chkUniqueKey" runat="server" checked="false" />
                            </div>

                            <label class="control-label col-sm-2 col-xs-12">Is Composite Unique Key</label>
                            <div class="control-form col-sm-2 col-xs-12">
                                <asp:checkbox id="chkCompositeUniqueKey" runat="server" checked="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Remark</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:textbox id="txtRemark" runat="server" textmode="MultiLine" cssclass="form-control" maxlength="500"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class=" col-sm-4 col-xs-12"></div>
                            <div class=" col-sm-6 col-xs-12">
                                <asp:button id="btnSave" runat="server" validationgroup="vgSave" cssclass="btn btn-submit" text="Submit" onclick="btnSave_Click" causesvalidation="true" />
                                <asp:button id="btnCancel" runat="server" cssclass="btn btn-reset" text="Reset" onclick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="list" class="tab-pane fade" clientidmode="static" runat="server">

                <table id="example1" class="table table-bordered table-striped dt1">
                    <asp:listview id="lstvQualifyingHeadMaster" runat="server" onitemcommand="lstvQualifyingHeadMaster_ItemCommand">
                        <LayoutTemplate>
                            <thead>

                                <tr>
                                    <th>
                                        <asp:CheckBox ID="Chk_selectAll" runat="server" onclick="chkSelectMulti(this,'Chk_selectAll','Chk_select');" /></th>
                                    <th>Edit</th>
                                    <th>Sr No.</th>
                                    <th>Form Name</th>
									<th>Form Title</th>
                                    <th>Head Name</th>
                                    <th>Head Note</th>
                                    <th>Input Type </th>
                                    <th>Min. Input Value</th>
                                    <th>Max. Input Value</th>
                                    <th>Display Preference No</th>
                                    <th>Is compulsory Entry</th>
                                    <th>Template Dropdown</th>
                                    <th>Remark</th>

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
                                    <asp:LinkButton ID="aEdit" CommandName="EditData" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ConfigurationHeadId") %>' runat="server" title="Edit" class="fa fa-edit" data-placement="bottom" rel="tooltip" data-original-title="Edit"><i class="icon-edit"></i></asp:LinkButton></td>
                                <td><%# Container.DataItemIndex + 1%></td>
								<td><%# Eval("FormName")%></td>
                                <td><%# Eval("FormTitle")%></td>
                                <td>
                                    <asp:HiddenField ID="hfDKId" Value='<%# Eval("ConfigurationHeadId")%>' runat="server" />
                                    <%# Eval("ConfigurationHeadName")%></td>
                                <td><%# Eval("HeadNote")%></td>
                                <td><%# Eval("InputType")%></td>
                                <td><%# Eval("MinInputValue")%></td>
                                <td><%# Eval("MaxInputValue")%></td>
                                <td><%# Eval("DisplayPreferenceNo")%></td>
                                <td><span class="label" style='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry")) ? "background-color:#5cb85c" + ";": "background-color:#c9302c" + ";" %>'>
                                    <%# (Boolean.Parse(Eval("IsCompulsaryEntry").ToString())) == true ? "True" : "False"%></td>
                                <td><%# Eval("TemplateDropdownName")%></td>
                                <td><%# Eval("Remark")%></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                    </asp:listview>
                </table>

            </div>
        </div>
    </div>
</asp:Content>

