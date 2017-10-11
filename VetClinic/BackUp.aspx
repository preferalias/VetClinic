<%@ Page Title="Backup" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BackUp.aspx.vb" Inherits="VetClinic.BackUp" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Backup Database</h2>
    <hr />
    <div class="form-horizontal" style="padding-top:20px;">
        <div class="form-group">
            <label class="control-label col-sm-2" for="petType">Backup File .bak</label>
            <div class="col-sm-2">
                <dx:BootstrapButton runat="server" ID="btnbt_bkup" AutoPostBack="true" 
                    Text="Download" CssClasses-Button="btn btn-default">
                </dx:BootstrapButton>
            </div>
        </div>
    </div>
</asp:Content>
