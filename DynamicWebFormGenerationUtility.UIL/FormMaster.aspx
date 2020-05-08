<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.Master" AutoEventWireup="true" CodeBehind="FormMaster.aspx.cs" Inherits="DynamicWebFormGenerationUtility.UIL.FormMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Form Master
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="box box-warning">
        <div class="box-header with-border ">
            <a id="lnkDetails" data-toggle="tooltip" title="Add Details" data-placement="top" runat="server" class="btn btn-primary pull-left" onserverclick="tab_Click">
                <i class="fa fa-plus" aria-hidden="false"></i></a>&nbsp;
             <span class="">
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Delete Detail(s)" ID="btnDeleteSelected" runat="server" CssClass="btn btn-danger" OnClientClick="return CheckBoxValidate();" OnClick="btnDeleteSelected_Click"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>
                 &nbsp; 
                 <asp:LinkButton data-toggle="tooltip" data-placement="top" title="Export To Excel" ID="btnExportExcel" runat="server" OnClientClick="return confirm('Are you sure you want to export all data?');" CssClass="btn btn-info" OnClick="btnExportExcel_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
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
                            <label class="control-label col-sm-4 col-xs-12">Form Name</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtFormName" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
							 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vgSave" ErrorMessage="Allows Only Alphanumeric & Space (A-Z,a-z, 0-9 ,.&\\/ \-\'() )" ControlToValidate="txtFormName" Display="Dynamic" CssClass="code" ForeColor="Red" ValidationExpression="[A-Za-z0-9 ,.&?\\/ \-\'() ]*"></asp:RegularExpressionValidator>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="vgSave" InitialValue="" ErrorMessage="Please Enter Form Name" ControlToValidate="txtFormName" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                               
								</div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Form Title</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtFormTitle" runat="server" CssClass="form-control" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vgSave" InitialValue="" ErrorMessage="Please Enter Form Title" ControlToValidate="txtFormTitle" Display="Dynamic" CssClass="code" ForeColor="Red"></asp:RequiredFieldValidator>
                               
                            </div>
                        </div>
                        <div runat="server" id="Divform" class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Copy Controls From Form</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlFormname" runat="server" CssClass="form-control select2">
                                    <asp:ListItem Text="-Please Select-" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Component Name</label>

                            <div class="control-form col-sm-3 col-xs-3">
                                <asp:TextBox ID="txtComponent" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                            </div>
                            <div class="control-form col-sm-2 col-xs-2">
                                <label>Component Sequence No</label>
                            </div>
                            <div class="control-form col-sm-1 col-xs-1">
                                <asp:TextBox ID="txtCompSeqNo" runat="server"  onkeypress="return onlyDotsAndNumbers(this, event);" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                            <div class="control-form col-sm-2 col-xs-2">
                            <asp:Button ID="btnAdd" runat="server"  CssClass="btn btn-submit" Text="Add" OnClick="btnAdd_Click"  />
                        </div>
                             </div>
                        <div class="form-group">
                                 <div class="control-form col-sm-4 col-xs-4">
                                     </div> 
                              <div class="control-form col-sm-6 col-xs-6">
                           <table id="tblComponent" class="table table-bordered table-striped dt1">
                    <asp:ListView ID="LWComponent" runat="server" OnItemCommand="lstvComponent_ItemCommand">
                        <LayoutTemplate>
                            <thead>

                                <tr>
              
                                    <th>Sr No.</th>
                                    <th>Component Name</th>
                                    <th>Sequence No</th>
                                    <th></th>
                                    <th></th>
       
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                
                               
                                <td><%# Container.DataItemIndex + 1%></td>
                                <td><%# Eval("ComponentName")%></td>
                                <td><%# Eval("SeqNo")%>
                                    <asp:HiddenField ID="hfDKId" Value='<%# Eval("Id")%>' runat="server" />
                                    <asp:HiddenField ID="hfDKValidationId" Value='<%# Eval("Validationid")%>' runat="server" />
                                </td>
                                  <td >
                                    <asp:LinkButton ID="Edit" CommandName="EditData" CommandArgument='<%# Container.DataItemIndex + 1%>' runat="server" class="fa fa-edit" data-placement="bottom" rel="tooltip" data-original-title="Delete"><i class="icon-edit"></i></asp:LinkButton></td>
                                 <td >
                                    <asp:LinkButton ID="Delete" CommandName="DeleteData" CommandArgument='<%# Container.DataItemIndex + 1%>' runat="server" class="btn-danger fa fa-trash" data-placement="bottom" rel="tooltip" data-original-title="Delete"><i class="icon-delete"></i></asp:LinkButton></td>
                                 
                                </tr>
                                
                        </ItemTemplate>
                        <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                    </asp:ListView>
                </table>  </div> 
                              <div class="control-form col-sm-2 col-xs-2">
                                  </div> 
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4 col-xs-12">Remark</label><div class="control-form col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="500"></asp:TextBox>
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
            <div id="list" class="tab-pane fade" clientidmode="static" runat="server">

                <table id="example1" class="table table-bordered table-striped dt1">
                    <asp:ListView ID="lstvFormMaster" runat="server" OnItemCommand="lstvFormMaster_ItemCommand">
                        <LayoutTemplate>
                            <thead>

                                <tr>
                                    <th>
                                        <asp:CheckBox ID="Chk_selectAll" runat="server" onclick="chkSelectMulti(this,'Chk_selectAll','Chk_select');" /></th>
                                    <th>Edit</th>
                                     <th><asp:Label runat="server" ID ="lblFreez" Text =""></asp:Label></th>
                                    <th>Sr No.</th>
                                    <th>Form Name</th>
                                    <th>Form Title</th>
                                    <th>Remarks</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="Chk_select" runat="server" Checked="false"  /></td>
                                    <td style="text-align: center;">
                                    <asp:LinkButton ID="aEdit" CommandName="EditData" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FormId") %>' runat="server" title="Edit" class="fa fa-edit" data-placement="bottom" rel="tooltip" data-original-title="Edit"><i class="icon-edit"></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  ID="Btn_freez" runat="server" Text ='<%# Eval("Is_Freez")%>' Width ="80px" CssClass='<%# Eval("Is_Freez").ToString() .Equals ( "Freez") ? "btn btn-success" : " btn btn-danger" %>'  CommandName="FreezData" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Is_Freez") %>'   data-placement="bottom" rel="tooltip" ></asp:LinkButton></td>
                                <td><%# Container.DataItemIndex + 1%></td>
                                <td><%# Eval("FormName")%></td>
                                <td><%# Eval("FormTitle")%>
                                    <asp:HiddenField ID="hfDKId" Value='<%# Eval("FormId")%>' runat="server" />
                                </td>
                                <td><%# Eval("Remarks")%></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>No Records Found</EmptyDataTemplate>
                    </asp:ListView>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
