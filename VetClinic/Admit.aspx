<%@ Page Title="Admit Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admit.aspx.vb" Inherits="VetClinic.Admit" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#toggle-panel').hide();
            $('#btn_showPanel').click(function () {
                $(this).find('span').toggleClass('glyphicon-plus-sign').toggleClass('glyphicon-minus-sign');
            });
        });
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function btnClick() {
            if (event.keyCode == 13) {
                btn_search.DoClick();
            }
        }
        function showPanel() {
            if ($("#toggle-panel").is(':visible')) {
                $("#toggle-panel").slideUp(500)
            } else {
                $("#toggle-panel").slideDown(500)
            }
        }
        function showGVSearch(s, e) {

        }
    </script>
   <dx:ASPxTextBox runat="server" ClientInstanceName="hdn_addID" ID="hdn_addID" ClientVisible="false"></dx:ASPxTextBox>
   <dx:ASPxTextBox runat="server" ClientInstanceName="hdn_opdnum" ID="hdn_opdnum" ClientVisible="false"></dx:ASPxTextBox>
   <h2>Admit</h2>
   <hr />
   <button type="button" id="btn_showPanel" class="btn btn-success" onclick="showPanel()" ><span class="glyphicon glyphicon-plus-sign"></span> Add OPD</button>

   <div id="toggle-panel" class="form-horizontal" style="padding-top:20px;">
        <div class="form-group">
            <label class="control-label col-sm-1" for="petType">OPD.</label>
            <div class="col-sm-2">
                <input runat="server" type="text" onkeyup="btnClick" onkeypress="return isNumberKey(event)" class="form-control" id="opd_num" placeholder="Number" name="opd_num">
            </div>
            <label class="control-label col-sm-1" for="petName">ชื่อสัตว์</label>
            <div class="col-sm-2">
                <input runat="server" type="text" onkeyup="btnClick" class="form-control" id="petName" placeholder="Pet Name" name="petName">
            </div>
            <label class="control-label col-sm-1" for="contact">เบอร์โทร</label>
            <div class="col-sm-2">
                <input runat="server" type="text" onkeyup="btnClick" onkeypress="return isNumberKey(event)" class="form-control" id="contact" placeholder="Number" name="contact">
            </div>
            <label class="control-label col-sm-1" for="holder_name">ชื่อเจ้าของ</label>
            <div class="col-sm-2">          
                <input runat="server" type="text" onkeyup="btnClick" class="form-control" id="holder_name" placeholder="Holder Name" name="holder_name">
            </div>
        </div>
                <dx:ASPxButton ClientVisible="false" runat="server" ID="btnbt_Search" AutoPostBack="false" ClientInstanceName="btn_search"
                    Text="Search" CssClasses-Button="pull-right btn btn-default">
                    <ClientSideEvents Click="function(s,e){gv_OPD.PerformCallback();gv_OPD.SetVisible(true);}" />
                </dx:ASPxButton>
       <div class="row">
           <div class="col-sm-12">
               <dx:BootstrapGridView runat="server" ID="gv_OPD" ClientVisible="false"
                   DataSourceID="ods_opd" KeyFieldName="id" ClientInstanceName="gv_OPD">
                   <SettingsPager PageSize="5"></SettingsPager>
                   <Columns>
                       <dx:BootstrapGridViewDataTextColumn Caption="OPD" FieldName="opd_num"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Pet Name" FieldName="pet_name"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Age" FieldName="pet_age"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Type" FieldName="pet_type"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Breed" FieldName="pet_breed"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Sex" FieldName="pet_sex"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Holder Name" FieldName="holder_name"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Contact" FieldName="contact"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Status" FieldName="admit_stats"/>
                       <dx:BootstrapGridViewDataColumn Caption="Details">
                           <DataItemTemplate>
                                <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_admit" runat="server" Text="Admit" AutoPostBack="false" ToolTip="Add" />
                           </DataItemTemplate>
                       </dx:BootstrapGridViewDataColumn>
                   </Columns>
                   <ClientSideEvents Init="onInitAdmit" EndCallback="onInitAdmit" />
               </dx:BootstrapGridView>
               <asp:ObjectDataSource runat="server" ID="ods_opd" TypeName="VetClinic.VetManager" 
                   SelectMethod="GetOPDWithoutAdmit" />
           </div>
       </div>
    </div>
    <hr />
    <h4 style="margin-bottom:30px;">Admitted List</h4>
    
    <dx:BootstrapPageControl ID="BootstrapPageControl1" runat="server">
        <%--<ClientSideEvents Init="ChangeTabColor" />--%>
        <TabPages>
            <dx:BootstrapTabPage Text="Admit">
                <ContentCollection>
                    <dx:ContentControl>
                        <div class="row">
                            <div class="col-sm-12">
                                <dx:BootstrapGridView runat="server" ID="gv_admit" 
                                    DataSourceID="ods_admit" KeyFieldName="opd_id;admit_id" ClientInstanceName="CIN_gv_admit" >
                                    <SettingsEditing Mode="Inline"></SettingsEditing>
                                    <SettingsBehavior ConfirmDelete="true" />
                                    <SettingsPager PageSize="10"></SettingsPager>
                                    <Columns>
                                        <dx:BootstrapGridViewDataDateColumn PropertiesDateEdit-AllowNull="false" Caption="Admit Date" FieldName="admit_date" />
                                        <dx:BootstrapGridViewDataTextColumn Caption="OPD" FieldName="opd_num"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Pet Name" FieldName="pet_name"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Type" FieldName="pet_type"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Holder Name" FieldName="holder_name"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Contact" FieldName="contact"/>
                                        <dx:BootstrapGridViewDataColumn Caption="Details">
                                            <DataItemTemplate>
                                                <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_view" runat="server" Text="View" AutoPostBack="false" ToolTip="View Detail" />
                                                <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_del" runat="server" Text="Discharge" AutoPostBack="false" ToolTip="Discharged" />
                                            </DataItemTemplate>
                                        </dx:BootstrapGridViewDataColumn>
                                        <dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true"> </dx:BootstrapGridViewCommandColumn>
                                    </Columns>
                                    <ClientSideEvents Init="onInitAdmit" EndCallback="onInitAdmit" />
                                </dx:BootstrapGridView>
                                <asp:ObjectDataSource runat="server" ID="ods_admit" TypeName="VetClinic.VetManager" 
                                    SelectMethod="GetAdmitByStatus" />
                            </div>
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapTabPage>
            <dx:BootstrapTabPage Text="History">
                <ContentCollection>
                    <dx:ContentControl>
                        <div class="row">
                            <div class="col-sm-12">
                                <dx:BootstrapGridView runat="server" ID="gv_dis" 
                                    DataSourceID="ods_dis" KeyFieldName="admit_id" ClientInstanceName="CIN_gv_dis" >
                                    <SettingsPager PageSize="10"></SettingsPager>
                                    <Columns>
                                        <dx:BootstrapGridViewDataDateColumn Caption="Admit Date" FieldName="admit_date" />
                                        <dx:BootstrapGridViewDataDateColumn Caption="Discharged Date" FieldName="discharge_date" />
                                        <dx:BootstrapGridViewDataTextColumn Caption="OPD" FieldName="opd_num"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Pet Name" FieldName="pet_name"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Type" FieldName="pet_type"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Holder Name" FieldName="holder_name"/>
                                        <dx:BootstrapGridViewDataTextColumn Caption="Contact" FieldName="contact"/>
                                       <%-- <dx:BootstrapGridViewDataColumn Caption="Details">
                                            <DataItemTemplate>
                                                <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_view" runat="server" Text="View" AutoPostBack="false" ToolTip="View Detail" />
                                                <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_del" runat="server" Text="Discharge" AutoPostBack="false" ToolTip="Discharged" />
                                            </DataItemTemplate>
                                        </dx:BootstrapGridViewDataColumn>--%>
                                    </Columns>
                                    <ClientSideEvents Init="onInitAdmit" EndCallback="onInitAdmit" />
                                </dx:BootstrapGridView>
                                <asp:ObjectDataSource runat="server" ID="ods_dis" TypeName="VetClinic.VetManager" 
                                    SelectMethod="GetAdmitByStatus" />
                            </div>
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapTabPage>
        </TabPages>
    </dx:BootstrapPageControl>
    
    
    <dx:BootstrapPopupControl runat="server" ID="popup_add" ClientInstanceName="popup_add" AllowDragging="true" ShowCloseButton="false"
        PopupHorizontalAlign="WindowCenter" CssClasses-Header="control-label" PopupVerticalAlign="WindowCenter" Width="200px" >
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-sm-12">
                    <label id="lbl_addID" runat="server">กรอกวันที่ Admit</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <dx:BootstrapDateEdit runat="server" ID="dedit_addday" ClientInstanceName="dedit">
                            <ClientSideEvents Init="changeGlyph" />
                        </dx:BootstrapDateEdit>
                    </div>
                </div>
                <div class="row" style="margin-top:15px;">
                    <div class="col-sm-12">
                        <div class="pull-right">
                            <dx:BootstrapButton runat="server" ID="btn_pup_submit" Text="Add" AutoPostBack="false">
                                <ClientSideEvents Click="function(s,e){if (dedit.GetValue() == null) {
		                                                    alert('Please fill admit date.');
	                                                    } 
	                                                    else { 
		                                                    CIN_gv_admit.PerformCallback('New');
                                                            popup_add.Hide();
                                                            $('#toggle-panel').slideUp(500, function(){gv_OPD.SetVisible(false);
                                                            $('#btn_showPanel').find('span').toggleClass('glyphicon-plus-sign').toggleClass('glyphicon-minus-sign');});     
	                                                    }}" />
                            </dx:BootstrapButton>
                        <dx:BootstrapButton runat="server" ID="btn_pup_cancel" Text="Cancel" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){popup_add.Hide();}" />
                        </dx:BootstrapButton>
                        </div>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:BootstrapPopupControl>
    <dx:BootstrapPopupControl runat="server" ID="popup_discharged" ClientInstanceName="popup_discharged" AllowDragging="true" ShowCloseButton="false"
        PopupHorizontalAlign="WindowCenter" CssClasses-Header="control-label" PopupVerticalAlign="WindowCenter" Width="200px" >
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-sm-12">
                    <label id="Label1" runat="server">กรอกวันที่ออก</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <dx:BootstrapDateEdit runat="server" ID="dedit_pup_delete" ClientInstanceName="dedit_del">
                            <ClientSideEvents Init="changeGlyph" />
                        </dx:BootstrapDateEdit>
                    </div>
                </div>
                <div class="row" style="margin-top:15px;">
                    <div class="col-sm-12">
                        <div class="pull-right">
                            <dx:BootstrapButton runat="server" ID="btn_pup_del" Text="Disc." AutoPostBack="false">
                                <ClientSideEvents Click="function(s,e){if (dedit_del.GetValue() == null) {
		                                                    alert('Please fill admit date.');
	                                                    } 
	                                                    else { 
		                                                    CIN_gv_admit.PerformCallback('Del');
                                                            CIN_gv_dis.PerformCallback();
                                                            popup_discharged.Hide();    
	                                                    }}" />
                            </dx:BootstrapButton>
                        <dx:BootstrapButton runat="server" ID="btn_pup_del_cancel" Text="Cancel" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){popup_discharged.Hide();}" />
                        </dx:BootstrapButton>
                        </div>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:BootstrapPopupControl>
</asp:Content>
