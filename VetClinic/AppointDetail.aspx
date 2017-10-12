<%@ Page Title="OPD Detail" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AppointDetail.aspx.vb" Inherits="VetClinic.AppointDetail" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxTextBox runat="server" ID="hdn_id" ClientVisible="false"></dx:ASPxTextBox>
    <div class="row" style="padding-top:20px;">
        <div class="col-sm-2">
            <a href="Search.aspx" class="btn btn-default">
                <span class="glyphicon glyphicon-arrow-left"></span>  Back to search
            </a>
        </div>
    </div>
    <hr />
    <h4 runat="server" id="header_h4" style="padding-bottom:20px;"></h4>
    <p runat="server" id="para1"></p>
    <p runat="server" id="para2"></p>
    <hr />
    <dx:BootstrapPageControl ID="BootstrapPageControl1" runat="server">
        <TabPages>
            <dx:BootstrapTabPage Text="วันตรวจ">
                <ContentCollection>
                    <dx:ContentControl>
                        <dx:BootstrapGridView ID="gv_detail2" ClientInstanceName="gv_OPD" runat="server" KeyFieldName="detail_id" DataSourceID="ods_detail2" EnableCallBacks="true">
                            <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSelectByRowClick="true" ConfirmDelete="True" />
                            <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                            <SettingsPopup  EditForm-HorizontalAlign="Center" EditForm-VerticalAlign="WindowCenter"
                                EditForm-Height="370px" EditForm-Width="800px" ></SettingsPopup>
                            <SettingsDataSecurity AllowEdit="true" AllowDelete="true" AllowInsert="true" />
                            <Columns>
                                <dx:BootstrapGridViewDataDateColumn EditFormSettings-VisibleIndex="1" PropertiesDateEdit-UseMaskBehavior="true" Caption="Date" FieldName="opd_date"  />
                                <dx:BootstrapGridViewDataMemoColumn EditFormSettings-VisibleIndex="3" PropertiesMemoEdit-Rows="4" EditFormSettings-Caption="CC" Caption="Client Complain" FieldName="opd_details" />
                                <dx:BootstrapGridViewDataTextColumn EditFormSettings-VisibleIndex="2" Caption="BW(Kg)" FieldName="opd_bw" />
                                <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="PE + Lab" FieldName="opd_lab"/>
                                <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="Tx" FieldName="opd_fee"/>
                                <dx:BootstrapGridViewDataMemoColumn PropertiesMemoEdit-Rows="4" Caption="Rx" FieldName="opd_fee2"/>
                                <dx:BootstrapGridViewDataTextColumn Caption="Fee" FieldName="opd_amount"/>
                                <dx:BootstrapGridViewCommandColumn ShowNewButtoninheader="true" ShowEditButton="true">
                                </dx:BootstrapGridViewCommandColumn>
                            </Columns>
                        <ClientSideEvents Init="onInitEdit" EndCallback="onInitEdit" />
                        </dx:BootstrapGridView>
                        <asp:ObjectDataSource ID="ods_detail2" runat="server" TypeName="VetClinic.VetManager"
                            SelectMethod="GetDetailByType"></asp:ObjectDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapTabPage>
            <dx:BootstrapTabPage Text="วันนัด">
                <ContentCollection>
                    <dx:ContentControl>
                        <dx:BootstrapGridView ID="gv_detail" ClientInstanceName="gv_detail" runat="server" KeyFieldName="detail_id" DataSourceID="ods_detail" EnableCallBacks="true">
                            <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSelectByRowClick="true" ConfirmDelete="True" />
                            <SettingsEditing Mode="Inline"></SettingsEditing>
                            <SettingsDataSecurity AllowEdit="true" AllowInsert="true" />
                            <Columns>
                                <dx:BootstrapGridViewDataTextColumn Caption="id" FieldName="opd_id"  Visible="false"/>
                                <dx:BootstrapGridViewDataDateColumn Caption="Date" FieldName="opd_date" />
                                <dx:BootstrapGridViewDataTextColumn Caption="Details" FieldName="opd_details"/>
                                <dx:BootstrapGridViewCommandColumn ShowNewButtonInHeader="True">
                                </dx:BootstrapGridViewCommandColumn>
                            </Columns>
                            <ClientSideEvents Init="onInitEdit" EndCallback="onInitEdit" />
                        </dx:BootstrapGridView>
                        <asp:ObjectDataSource ID="ods_detail" runat="server" TypeName="VetClinic.VetManager"
                            SelectMethod="GetDetailByType"></asp:ObjectDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapTabPage>
        </TabPages>
    </dx:BootstrapPageControl>
</asp:Content>
