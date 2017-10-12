<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VetClinic._Default" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Home</h2>
    <hr />
    <asp:UpdatePanel runat="server" ID="udp_Calendar">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-3">
                        <label class="control-label">Appointment Calendar</label>
                        <asp:Calendar  runat="server"  ID="calen_Note" Width="100%" FirstDayOfWeek="Sunday"
                                BackColor="White" BorderColor="#999999" CellPadding="4" 
                                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                                Height="180px" style="margin-top:10px;">
                        <DayHeaderStyle BackColor="#EEEEEE" Font-Bold="false" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#AAAAAA" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#4a60a2" ForeColor="White" BorderColor="Black" Font-Bold="false" />
                        <TodayDayStyle BackColor="#E5EEFF" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#DDDDDD" />
                        </asp:Calendar>
                </div>
                <div class="col-sm-9">
                    <label runat="server" id="lbl_date" class="control-label"></label>
                    <dx:BootstrapGridView ID="gv_detail" ClientInstanceName="gv_detail" runat="server" KeyFieldName="detail_id" EnableCallBacks="true">
                            <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSelectByRowClick="true" ConfirmDelete="True" />
                            <SettingsEditing Mode="Inline"></SettingsEditing>
                            <SettingsDataSecurity AllowEdit="true" AllowInsert="true" />
                            <Columns>
                                <dx:BootstrapGridViewDataDateColumn Caption="Date" FieldName="opd_date" />
                                <dx:BootstrapGridViewDataTextColumn Caption="Details" FieldName="opd_details"/>
                                <dx:BootstrapGridViewDataTextColumn Caption="OPD" FieldName="opd_num" />
                                <dx:BootstrapGridViewDataColumn Caption="#">
                               <DataItemTemplate>
                                    <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_detail" runat="server" Text="View" AutoPostBack="false" ToolTip="View Detail" />
                               </DataItemTemplate>
                            </dx:BootstrapGridViewDataColumn>
                            </Columns>
                        </dx:BootstrapGridView>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-sm-12">
                   <label class="control-label">Recently Added OPD</label>
                   <dx:BootstrapGridView runat="server" ID="gv_OPD" 
                       DataSourceID="ods_opd" KeyFieldName="id" ClientInstanceName="gv_OPD" >
                       <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSelectByRowClick="true" />
                       <SettingsPager PageSize="6"></SettingsPager>
                       <Columns>
                           <dx:BootstrapGridViewDataTextColumn Caption="OPD" FieldName="opd_num"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Pet Name" FieldName="pet_name"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Age" FieldName="pet_age"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Type" FieldName="pet_type"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Breed" FieldName="pet_breed"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Sex" FieldName="pet_sex"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Holder Name" FieldName="holder_name"/>
                           <dx:BootstrapGridViewDataTextColumn Caption="Contact" FieldName="contact"/>
                           <dx:BootstrapGridViewDataColumn Caption="Add Appointment">
                               <DataItemTemplate>
                                    <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_detail" runat="server" Text="Add/View" AutoPostBack="false" ToolTip="View Detail" />
                               </DataItemTemplate>
                            </dx:BootstrapGridViewDataColumn>
                           
                       </Columns>
                       <ClientSideEvents Init="onInitHome" EndCallback="onInitHome" />
                    </dx:BootstrapGridView>
                    <asp:ObjectDataSource runat="server" ID="ods_opd" TypeName="VetClinic.VetManager" 
                        SelectMethod="GetOPD" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
 <%--   <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <img src="Images/Shop.jpg" class="home-img" />
        </div>
    </div>--%>

</asp:Content>
