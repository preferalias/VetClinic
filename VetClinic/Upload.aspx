<%@ Page Title="Upload" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Upload.aspx.vb" Inherits="VetClinic.Exel_Upload" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[type=file]").addClass("btn btn-default");
        });
    </script>
    <h2>Upload OPD</h2>
    <hr />
    <div class="form-horizontal" style="padding-top:20px;">
        <div class="form-group">
            <label class="control-label col-sm-2" for="petName">Upload OPD</label>
            <div class="col-sm-4">
                <asp:FileUpload ID="upload_opd" runat="server" />         
            </div>
            <div class="col-sm-2">
                <dx:BootstrapButton ID="btn_upload" runat="server" Text="Upload"></dx:BootstrapButton>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="petName">Upload Status</label>
            <div class="col-sm-2" style="padding-top:7px; color:red;">
                <asp:Label runat="server" id="lbl_upload_status"></asp:Label>
            </div>         
        </div>
    </div>
</asp:Content>
