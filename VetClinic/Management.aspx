﻿<%@ Page Title="Editing" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Management.aspx.vb" Inherits="VetClinic.Management" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
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
    </script>
    <h2>OPD Management</h2>
    <hr />
   <div class="form-horizontal" style="padding-top:20px;">
        <div class="form-group">
            <label class="control-label col-sm-1" for="petType">OPD.</label>
            <div class="col-sm-2">
                <input runat="server" type="text" onkeyup="btnClick" onkeypress="return isNumberKey(event)" class="form-control" id="opd_num" placeholder="Number" name="opd_num">
            </div>
            <label class="control-label col-sm-1" for="petName">ชื่อสัตว์</label>
            <div class="col-sm-2">
                <input runat="server" type="text" onkeyup="btnClick" class="form-control" id="petName" placeholder="Pet Name" name="petName">
            </div>
            <label class="control-label col-sm-1" for="petType">เบอร์โทร</label>
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
                    <ClientSideEvents Click="function(s,e){gv_OPD.PerformCallback();}" />
       </dx:ASPxButton>
       <hr />
       <div class="row">
           <div class="col-sm-12">
               <dx:BootstrapGridView runat="server" ID="gv_OPD" 
                   DataSourceID="ods_opd" KeyFieldName="id" ClientInstanceName="gv_OPD" >
                   <Columns>
                       <dx:BootstrapGridViewDataTextColumn Caption="OPD" FieldName="opd_num"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Pet Name" FieldName="pet_name"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Age" FieldName="pet_age"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Type" FieldName="pet_type"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Breed" FieldName="pet_breed"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Sex" FieldName="pet_sex"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Holder Name" FieldName="holder_name"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Contact" FieldName="contact"/>
                       <dx:BootstrapGridViewDataTextColumn Caption="Address" FieldName="address"/>
                       <dx:BootstrapGridViewDataColumn Caption="#">
                           <DataItemTemplate>
                                <dx:BootstrapButton CssClasses-Button="btn btn-link" ID="btn_detail" runat="server" Text="Edit" AutoPostBack="false" ToolTip="View Detail" />
                           </DataItemTemplate>
                       </dx:BootstrapGridViewDataColumn>

                   </Columns>
                   <ClientSideEvents Init="onInitSearch" EndCallback="onInitSearch" />

               </dx:BootstrapGridView>
               <asp:ObjectDataSource runat="server" ID="ods_opd" TypeName="VetClinic.VetManager" 
                   SelectMethod="GetOPD" />
           </div>
       </div>
    </div>
</asp:Content>
