<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.Master" MaintainScrollPositionOnPostback ="true" AutoEventWireup="true" CodeBehind="FormFilling.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.FormFilling" %>

<%@ Register Assembly="USControls" Namespace="USControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    <asp:Label ID="lblFormName" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="box-header with-border ">
        <a id="lnkDetails" data-toggle="tooltip" title="Add Details" data-placement="top" runat="server" class="btn btn-primary pull-left" onserverclick="tab_Click">
            <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             <span class="">
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
             </span>
        <span class="pull-right"><a id="lnklist" class="btn btn-success" data-toggle="tooltip" data-placement="left" title="View Details" runat="server" onserverclick="tab_Click">
            <i class="fa fa-eye"></i></a></span>
    </div>
    <div class="box-body">
        <div class="tab-content">
            <div id="Details" class="tab-pane fade in active" clientidmode="static" runat="server">
                <div class="form-horizontal form-border">
                    <div class="form-group" id="divFormName" runat="server" visible="false">
                        <label class="control-label col-sm-3 col-xs-12">Form Name</label><div class="control-form col-sm-7 col-xs-12">
                            <asp:DropDownList ID="ddlFormname" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="ddlFormname_SelectedIndexChanged">
                                <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgSave" InitialValue="0" ErrorMessage="Please Select Form name" ControlToValidate="ddlFormname" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="panel panel-default">

                        <asp:Repeater ID="sectionLev1" runat="server">
                            <ItemTemplate>
                                <div class="box box-solid box-primary with-border">
                                    <div class="box-header">
                                        <h3 class="box-title"><%# Eval("ComponentName").ToString() %></h3>

                                        <div class="box-tools pull-right">
                                            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                                                <i class="fa fa-minus"></i>
                                            </button>

                                        </div>
                                    </div>
                                    <div class="box-body">
                                        <asp:Repeater ID="sectionLev2" DataSource='<%# BindSubRepeter(Eval("FormComponentMasterId").ToString()) %>' runat="server">
                                            <ItemTemplate>
                                                <US:USPlaceHolder ID="TXT" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "TXT") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USTextBox ID="USTXT" ValidationGroup="vgSave" cssName="form-control" MaxLength='<%# Eval("MaxLength") %>' DBName='<%# Eval("ConfigurationHeadId") %>' Text='<%# Eval("HeadValue").ToString() %>' runat="server"></US:USTextBox>
                                                            <asp:RequiredFieldValidator ID="rfvTXT" ValidationGroup="vgSave" ControlToValidate="USTXT" runat="server" ErrorMessage='<%# Eval("RequireFieldErrorMsg").ToString() %>' Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revtxtQualifyingHeadName" runat="server" ValidationGroup="vgSave" ErrorMessage='<%# Eval("ErrorMessage") %>' Enabled='<%# Convert.ToBoolean(Eval("IsRegex"))==true?true:false %>' ControlToValidate="USTXT" Display="Dynamic" CssClass="code" ForeColor="Red" ValidationExpression='<%# Eval("RegexValidationExpression").ToString() %>'></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>


                                                </US:USPlaceHolder>
                                                <US:USPlaceHolder ID="DATE" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "DATE") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USTextBox ID="USDATE" cssName="form-control" IsDatePickerTextBox="true" ValidationGroup="vgSave" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Text='<%#Eval("HeadValue").ToString() %>' data-date-start-date='<%#(Eval("InputType").ToString() == "DATE" && !(Eval("MinInputValue") is DBNull))? Eval("MinInputValue").ToString() :"" %>' data-date-end-date='<%# (Eval("InputType").ToString() == "DATE" && !(Eval("MaxInputValue") is DBNull)) ? Eval("MaxInputValue").ToString() : "" %>' runat="server"></US:USTextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgSave" ID="RequiredFieldValidator1" ControlToValidate="USDATE" runat="server" ErrorMessage='<%# Eval("RequireFieldErrorMsg").ToString() %>' Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>
                                                <US:USPlaceHolder ID="NUMERIC" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "TXTNUM") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                                        <div class="col-sm-7 col-xs-12" aria-live="polite">
                                                            <US:USTextBox ID="USNUMERIC" cssName="form-control" ValidationGroup="vgSave" TextMode="Number" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Text='<%#Eval("HeadValue").ToString() %>' IsDecimalTextBox='<%# Convert.ToBoolean(Eval("IsDecimalTextBox"))==true?true:false %>' IsIntegerTextBox="true" MinValue='<%# (Eval("InputType").ToString() == "TXTNUM" && !(Eval("MinInputValue") is DBNull))? Eval("MinInputValue").ToString() : "" %>' MaxValue='<%# (Eval("InputType").ToString() == "TXTNUM" && !(Eval("MaxInputValue") is DBNull)) ? Eval("MaxInputValue").ToString() : "" %>' runat="server"></US:USTextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgSave" ID="RequiredFieldValidator2" ControlToValidate="USNUMERIC" runat="server" ErrorMessage='<%# Eval("RequireFieldErrorMsg").ToString() %>' Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>
                                                <US:USPlaceHolder ID="NUMERICDEC" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "NUMERICDEC") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USTextBox ID="USNUMERICDEC" cssName="form-control" ValidationGroup="vgSave" TextMode="Number" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Text='<%#Eval("HeadValue").ToString() %>' IsDecimalTextBox="true" IsIntegerTextBox="false" MinValue='<%# (Eval("InputType").ToString() == "NUMERICDEC" && !(Eval("MinInputValue") is DBNull))? Eval("MinInputValue").ToString() : "" %>' MaxValue='<%# (Eval("InputType").ToString() == "NUMERICDEC" && !(Eval("MaxInputValue") is DBNull)) ? Eval("MaxInputValue").ToString() : "" %>' runat="server"></US:USTextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgSave" ID="RequiredFieldValidator4" ControlToValidate="USNUMERICDEC" runat="server" ErrorMessage='<%# Eval("RequireFieldErrorMsg").ToString() %>' Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>
                                                <US:USPlaceHolder ID="USPlaceHolder1" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "BASEDDL") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>
                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USBaseDropDownList ID="USBaseDropDownList1" AutoPostBack="true" OnSelectedIndexChanged="USBaseDropDownList_SelectedIndexChanged"
                                                                CssClass="form-control select2" IsMinMaxType="false" InitialValue="0" ValidationGroup="vgSave"
                                                                SetValue='<%#Eval("HeadValue").ToString() %>' ChildDBName='<%#Eval("ChildDBId").ToString() %>'
                                                                runat="server" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' DataTextField="ParameterText" DataValueField="ParameterValue" DataSource='<%# BindDropDownFromTemplateDropDownId(Eval("TemplateDropdownMasterId").ToString()) %>'>
                                                            </US:USBaseDropDownList>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgSave" ID="RequiredFieldValidator6" ControlToValidate="USBaseDropDownList1" InitialValue="0" runat="server" ErrorMessage='<%# Eval("RequireFieldErrorMsg").ToString() %>' Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>

                                                <US:USPlaceHolder ID="DDTEMP" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "DDL") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USDropDownList ID="USDDTEMP" CssClass="form-control select2" IsMinMaxType="false" InitialValue="0" ValidationGroup="vgSave" SetValue='<%#Eval("HeadValue").ToString() %>' runat="server" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' DataTextField="ParameterText" DataValueField="ParameterValue" DataSource='<%# BindChildDropDownFromTemplateDropDownId(Eval("TemplateDropdownMasterId").ToString(),Session["SeqId"].ToString(),Eval("ConfigurationHeadId").ToString()) %>'></US:USDropDownList>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgSave" ID="RequiredFieldValidator3" ControlToValidate="USDDTEMP" InitialValue="0" runat="server" ErrorMessage='<%# Eval("RequireFieldErrorMsg").ToString() %>' Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>

                                                <US:USPlaceHolder ID="USPlaceHolder3" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "RBLIST") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USRadioButtonList ID="USRadioButtonList1" RepeatDirection="Horizontal" IsMinMaxType="false" ValidationGroup="vgSave" SetValue='<%#Eval("HeadValue").ToString() %>' runat="server" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' DataTextField="ParameterText" DataValueField="ParameterValue" DataSource='<%# BindRadioButtionListByTemplateDropDownId(Eval("TemplateDropdownMasterId").ToString()) %>'></US:USRadioButtonList>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgSave" ID="RequiredFieldValidator5" ControlToValidate="USRadioButtonList1" InitialValue="" runat="server" ErrorMessage="Plese Select Data" Display="Dynamic" ForeColor="Red" Enabled='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry"))==true?true:false %>'></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-1 col-xs-12">
                                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>

                                                <US:USPlaceHolder ID="CHKYN" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "CHKYN") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>
                                                        <div class="col-sm-7 col-xs-12">
                                                            <US:USCheckBox ID="USCHKYN" IsCompulsaryEntry='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry")) && ((Eval("InputType").ToString() == "CHKYN"))==true?true:false %>' runat="server" ValidationGroup="vgSave" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Checked='<%#Eval("HeadValue").ToString() == "True" ? true : false %>' />
                                                            <i class="fa fa-info-circle" data-toggle="popover" title='<%# Eval("ConfigurationHeadName") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>

                                                    </div>

                                                </US:USPlaceHolder>

                                                <US:USPlaceHolder ID="USPlaceHolder2" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "LBL") %>'>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>
                                                        <div class="col-sm-7 col-xs-12">
                                                            <label class="control-label"><%# Eval("HeadNote") %></label>
                                                            <i class="fa fa-info-circle" data-toggle="popover" title='<%# Eval("ConfigurationHeadName") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                                        </div>
                                                    </div>

                                                </US:USPlaceHolder>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="form-group center-block text-center">
                            <asp:ValidationSummary HeaderText="You must enter a value in the following fields:" ValidationGroup="vgSave" DisplayMode="List" EnableClientScript="true" runat="server" />
                        </div>
                        <div class="form-group center-block text-center">
                            <%--<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-submit" Text="Add New Data" CausesValidation="true" OnClick="btnAdd_Click" />--%>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="vgSave" CssClass="btn btn-submit" Text="Save" CausesValidation="true" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-reset" Text="Reset" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnDelete" runat="server" Visible="false" CssClass="btn btn-danger dang" Text="Delete" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="list" class="tab-pane fade" clientidmode="static" runat="server" style="overflow-x: auto;">
                <div class="panel panel-default">

                    <div class="box-body">
                        <asp:Repeater Visible="false" ID="sectionSerach" runat="server">
                            <ItemTemplate>
                                <US:USPlaceHolder ID="TXT" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "TXT") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                        <div class="col-sm-7 col-xs-12">
                                            <US:USTextBox ID="USTXT" ValidationGroup="vgSearch" cssName="form-control" MaxLength='<%# Eval("MaxLength") %>' DBName='<%# Eval("ConfigurationHeadId") %>' Text='<%# Eval("HeadValue").ToString() %>' runat="server"></US:USTextBox>
                                            <asp:RegularExpressionValidator ID="revtxtQualifyingHeadName" runat="server" ValidationGroup="vgSearch" ErrorMessage='<%# Eval("ErrorMessage") %>' Enabled='<%# Convert.ToBoolean(Eval("IsRegex"))==true?true:false %>' ControlToValidate="USTXT" Display="Dynamic" CssClass="code" ForeColor="Red" ValidationExpression='<%# Eval("RegexValidationExpression").ToString() %>'></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>


                                </US:USPlaceHolder>
                                <US:USPlaceHolder ID="DATE" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "DATE") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                        <div class="col-sm-7 col-xs-12">
                                            <US:USTextBox ID="USDATE" cssName="form-control" IsDatePickerTextBox="true" ValidationGroup="vgSearch" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Text='<%#Eval("HeadValue").ToString() %>' data-date-start-date='<%#(Eval("InputType").ToString() == "DATE" && !(Eval("MinInputValue") is DBNull))? Eval("MinInputValue").ToString() :"" %>' data-date-end-date='<%# (Eval("InputType").ToString() == "DATE" && !(Eval("MaxInputValue") is DBNull)) ? Eval("MaxInputValue").ToString() : "" %>' runat="server"></US:USTextBox>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>
                                <US:USPlaceHolder ID="NUMERIC" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "TXTNUM") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                        <div class="col-sm-7 col-xs-12" aria-live="polite">
                                            <US:USTextBox ID="USNUMERIC" cssName="form-control" ValidationGroup="vgSearch" TextMode="Number" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Text='<%#Eval("HeadValue").ToString() %>' IsDecimalTextBox='<%# Convert.ToBoolean(Eval("IsDecimalTextBox"))==true?true:false %>' IsIntegerTextBox="true" MinValue='<%# (Eval("InputType").ToString() == "TXTNUM" && !(Eval("MinInputValue") is DBNull))? Eval("MinInputValue").ToString() : "" %>' MaxValue='<%# (Eval("InputType").ToString() == "TXTNUM" && !(Eval("MaxInputValue") is DBNull)) ? Eval("MaxInputValue").ToString() : "" %>' runat="server"></US:USTextBox>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>
                                <US:USPlaceHolder ID="NUMERICDEC" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "NUMERICDEC") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                        <div class="col-sm-7 col-xs-12">
                                            <US:USTextBox ID="USNUMERICDEC" cssName="form-control" ValidationGroup="vgSearch" TextMode="Number" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Text='<%#Eval("HeadValue").ToString() %>' IsDecimalTextBox="true" IsIntegerTextBox="false" MinValue='<%# (Eval("InputType").ToString() == "NUMERICDEC" && !(Eval("MinInputValue") is DBNull))? Eval("MinInputValue").ToString() : "" %>' MaxValue='<%# (Eval("InputType").ToString() == "NUMERICDEC" && !(Eval("MaxInputValue") is DBNull)) ? Eval("MaxInputValue").ToString() : "" %>' runat="server"></US:USTextBox>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>
                                <US:USPlaceHolder ID="USPlaceHolder1" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "BASEDDL") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>
                                        <div class="col-sm-7 col-xs-12">
                                            <US:USBaseDropDownList ID="USBaseDropDownList1" AutoPostBack="true" OnSelectedIndexChanged="USBaseDropDownList1_SelectedIndexChanged"
                                                CssClass="form-control select2" IsMinMaxType="false" InitialValue="0" ValidationGroup="vgSearch"
                                                SetValue='<%#Eval("HeadValue").ToString() %>' ChildDBName='<%#Eval("ChildDBId").ToString() %>'
                                                runat="server" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' DataTextField="ParameterText" DataValueField="ParameterValue" DataSource='<%# BindDropDownFromTemplateDropDownId(Eval("TemplateDropdownMasterId").ToString()) %>'>
                                            </US:USBaseDropDownList>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>

                                <US:USPlaceHolder ID="DDTEMP" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "DDL") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                        <div class="col-sm-7 col-xs-12">
                                            <US:USDropDownList ID="USDDTEMP" CssClass="form-control select2" IsMinMaxType="false" InitialValue="0" ValidationGroup="vgSearch" SetValue='<%#Eval("HeadValue").ToString() %>' runat="server" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' DataTextField="ParameterText" DataValueField="ParameterValue" DataSource='<%# BindChildDropDownFromTemplateDropDownId(Eval("TemplateDropdownMasterId").ToString(),Session["SeqId"].ToString(),Eval("ConfigurationHeadId").ToString()) %>'></US:USDropDownList>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>

                                <US:USPlaceHolder ID="USPlaceHolder3" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "RBLIST") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>

                                        <div class="col-sm-7 col-xs-12">
                                            <US:USRadioButtonList ID="USRadioButtonList1" RepeatDirection="Horizontal" IsMinMaxType="false" ValidationGroup="vgSearch" SetValue='<%#Eval("HeadValue").ToString() %>' runat="server" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' DataTextField="ParameterText" DataValueField="ParameterValue" DataSource='<%# BindRadioButtionListByTemplateDropDownId(Eval("TemplateDropdownMasterId").ToString()) %>'></US:USRadioButtonList>
                                        </div>
                                        <div class="col-sm-1 col-xs-12">
                                            <i class="fa fa-info-circle" style="font-size: 20px; color: #3c8dbc" data-toggle="popover" title='<%# Eval("HeadNote") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>

                                <US:USPlaceHolder ID="CHKYN" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "CHKYN") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>
                                        <div class="col-sm-7 col-xs-12">
                                            <US:USCheckBox ID="USCHKYN" IsCompulsaryEntry='<%# Convert.ToBoolean(Eval("IsCompulsaryEntry")) && ((Eval("InputType").ToString() == "CHKYN"))==true?true:false %>' runat="server" ValidationGroup="vgSearch" DBName='<%#Eval("ConfigurationHeadId").ToString() %>' Checked='<%#Eval("HeadValue").ToString() == "True" ? true : false %>' />
                                            <i class="fa fa-info-circle" data-toggle="popover" title='<%# Eval("ConfigurationHeadName") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>

                                    </div>

                                </US:USPlaceHolder>

                                <US:USPlaceHolder ID="USPlaceHolder2" InputType='<%# Eval("InputType").ToString() %>' DBName='<%#Eval("ConfigurationHeadId").ToString() %>' runat="server" Visible='<%# (Eval("InputType").ToString() == "LBL") %>'>
                                    <div class="form-group">
                                        <label class="control-label col-sm-3 col-xs-12"><%# Eval("ConfigurationHeadName") %></label>
                                        <div class="col-sm-7 col-xs-12">
                                            <label class="control-label"><%# Eval("HeadNote") %></label>
                                            <i class="fa fa-info-circle" data-toggle="popover" title='<%# Eval("ConfigurationHeadName") %>' data-content='<%# Eval("HeadNote") %>'></i>
                                        </div>
                                    </div>

                                </US:USPlaceHolder>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>
                   <div class="form-group center-block text-center">
                     
                  <asp:Button Visible="false" ID="btnSearch" runat="server" ValidationGroup="vgSearch" CssClass="btn btn-submit" Text="Search" CausesValidation="true" OnClick="btnSearch_Click" />
                          </div>
                <table id="example1" class="table table-bordered table-striped dt1">
                    <asp:GridView ID="dgFormFilling" OnRowCommand="dgFormFilling_RowCommand" class="table table-bordered table-striped dt1" runat="server" OnRowDataBound="dgFormFilling_RowDataBound">

                        <Columns>
                            <asp:TemplateField HeaderText="Sr No">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="aEdit" CommandName="AEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SeqId") %>' runat="server" title="Edit" class="fa fa-edit" data-placement="bottom" rel="tooltip" data-original-title="Edit"><i class="icon-edit"></i></asp:LinkButton></td>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="aDelete" CommandName="ADelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SeqId") %>' runat="server" title="Delete" class="btn-danger fa fa-trash" data-placement="bottom" rel="tooltip" data-original-title="Edit"><i class="icon-edit"></i></asp:LinkButton></td>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </table>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input:visible:enabled:first').focus();
        });

    </script>

</asp:Content>
