<%@ Page Title="Management" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Detail.aspx.vb" Inherits="VetClinic.Detail" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function editForm(s, e) {
            $(".form-horizontal input,textarea").removeAttr("readonly", "readonly");
            $(".form-horizontal select").removeAttr("disabled", "disabled");
            $("#btn_group_label button[value = 'Confirm']").css("display", "");
            $("#btn_group_label button[value = 'Cancel']").css("display", "");
            $("#btn_group_label button[value = 'Edit']").css("display", "none");
        }
        function cancelForm(s, e) {
            $(".form-horizontal input,textarea").attr("readonly", "readonly");
            $(".form-horizontal select").attr("disabled", "disabled");
            $("#btn_group_label button[value = 'Confirm']").css("display", "none");
            $("#btn_group_label button[value = 'Cancel']").css("display", "none");
            $("#btn_group_label button[value = 'Edit']").css("display", "");
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function isNumberKeyDecimal(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <dx:ASPxTextBox runat="server" ID="hdn_id" ClientVisible="false"></dx:ASPxTextBox>
    <div class="row" style="padding-top:20px;">
        <div class="col-sm-2">
            <a href="Management.aspx" class="btn btn-default">
                <span class="glyphicon glyphicon-arrow-left"></span>  Back to Editing
            </a>
        </div>
    </div>
    <hr />
    <h4>General</h4>
    <div class="form-horizontal" style="padding-top:20px;">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="opd_num">OPD Number</label>
                    <div class="col-sm-2">
                        <input readonly="readonly" onkeypress="return isNumberKey(event)" runat="server" type="text" class="form-control" id="opd_num" placeholder="OPD Number" name="opd_num" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="name">ชื่อสัตว์เลี้ยง</label>
                    <div class="col-sm-2">
                        <input required="required" readonly="readonly" runat="server" type="text" 
                            class="form-control" id="petName" placeholder="Pet Name" name="petName">
                    </div>
                    <label class="control-label col-sm-1"  for="age" >อายุ</label>
                    <div class="col-sm-1" >
                        <input readonly="readonly" onkeypress="return isNumberKey(event)" runat="server" type="text" class="form-control" id="age" placeholder="Age" name="age" />
                    </div>
                     <label class="control-label col-sm-1" for="month" >เดือน</label>
                    <div class="col-sm-1" >
                        <input readonly="readonly" onkeypress="return isNumberKey(event)" runat="server" type="text" class="form-control" id="month" placeholder="Month" name="month" />
                    </div>
                    <label class="control-label col-sm-1" for="breed">พันธุ์</label>
                    <div class="col-sm-2" >
                        <input readonly="readonly" runat="server" type="text" class="form-control" id="breed" placeholder="Breed" name="breed" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="petType">ชนิด</label>
                    <div class="col-sm-4">
                        <%--<input type="text" class="form-control" id="petType" placeholder="Pet Type" name="petType">--%>
                        <select disabled="disabled" runat="server" class="form-control" id="pet_Type">
                            <option selected="selected" style="display:none"></option>
                            <option>สุนัข</option>
                            <option>แมว</option>
                          </select>
                    </div>
                    <%--<label class="control-label col-sm-1"  for="weight" >น้ำหนัก</label>
                    <div class="col-sm-1" >
                        <input readonly="readonly" runat="server" type="text" class="form-control" id="weight" placeholder="Kg" name="weight" />
                    </div>--%>
                    <label class="control-label col-sm-1" for="sex">เพศ</label>
                    <div class="col-sm-2" >
                          <select disabled="disabled" runat="server" class="form-control" id="sex">
                            <option selected="selected" style="display:none"></option>
                            <option>ผู้</option>
                            <option>เมีย</option>
                          </select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="holder_name-name">ชื่อเจ้าของ</label>
                    <div class="col-sm-4">          
                        <input readonly="readonly" runat="server" type="text" class="form-control" id="holder_name" placeholder="Holder Name" name="holder_name">
                    </div>
                    <label class="control-label col-sm-1" for="contact">เบอร์ติดต่อ</label>
                    <div class="col-sm-2">          
                        <input readonly="readonly" runat="server" onkeypress="return isNumberKey(event)" type="text" class="form-control" id="contact" placeholder="Phone Num." name="contact">
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="address">ที่อยู่เจ้าของ</label>
                    <div class="col-sm-4">
                        <textarea readonly="readonly" id="address" runat="server" rows="3" class="form-control" placeholder="Address"></textarea> 
                    </div>
                </div>
                <div class="form-group" id="btn_group_label">
                    <div class="col-sm-offset-2 col-sm-4">
                        <dx:BootstrapButton runat="server" ID="btn_edit" Text="Edit" AutoPostBack="false">
                            <ClientSideEvents Click="editForm" />
                        </dx:BootstrapButton>
                        <dx:BootstrapButton ClientVisible="false" runat="server" ID="btn_update" Text="Confirm" AutoPostBack="true">
                           <%-- <ClientSideEvents Click="function(s,e){gv_OPD.PerformCallback();}"/>--%>
                        </dx:BootstrapButton>
                        <dx:BootstrapButton ClientVisible="false" runat="server" ID="btn_cancel" Text="Cancel" AutoPostBack="false">
                            <ClientSideEvents Click="cancelForm" />
                        </dx:BootstrapButton>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btn_update" />--%>
                <asp:AsyncPostBackTrigger ControlID="btn_update" />
            </Triggers>
        </asp:UpdatePanel>
        <hr />
        <h4>Vet Detail</h4>
        <div class="row">
            <div class="col-sm-12">
                <dx:BootstrapGridView ID="gv_OPD" ClientInstanceName="gv_OPD" runat="server" KeyFieldName="detail_id" DataSourceID="ods_detail" EnableCallBacks="true">
                    <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSelectByRowClick="true" ConfirmDelete="True" />
                    <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                    <SettingsPopup EditForm-HorizontalAlign="Center" EditForm-VerticalAlign="WindowCenter"
                                EditForm-Height="460px" EditForm-Width="800px" ></SettingsPopup>
                    <SettingsDataSecurity AllowEdit="true" AllowDelete="true"  />
                    <Columns>
                        <dx:BootstrapGridViewDataColumn Caption="OPD" FieldName="opd_num"/>
                        <dx:BootstrapGridViewDataComboBoxColumn Caption="Type" FieldName="opd_type">
                            <PropertiesComboBox  DropDownStyle="DropDown">
                        </PropertiesComboBox>
                        </dx:BootstrapGridViewDataComboBoxColumn>
                        <dx:BootstrapGridViewDataDateColumn Caption="Date" FieldName="opd_date" />
                        <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="CC" FieldName="opd_details"/>
                        <dx:BootstrapGridViewDataTextColumn Caption="BW(Kg)" FieldName="opd_bw" />
                        <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="PE + Lab" FieldName="opd_lab"/>
                        <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="Tx" FieldName="opd_fee"/>
                        <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="Rx" FieldName="opd_fee2" />
                        <dx:BootstrapGridViewDataTextColumn Caption="Fee" FieldName="opd_amount"/>
                        <dx:BootstrapGridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" >
                        </dx:BootstrapGridViewCommandColumn>
                    </Columns>
                    <ClientSideEvents Init="onInitEdit2" EndCallback="onInitEdit2" />
                </dx:BootstrapGridView>
                <asp:ObjectDataSource ID="ods_detail" runat="server" TypeName="VetClinic.VetManager"
                    SelectMethod="GetDetail"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
