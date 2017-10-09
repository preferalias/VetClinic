<%@ Page Title="Login" Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="VetClinic.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Images/favi.ico.png" rel="icon"  />
    <title></title>
    <link rel="stylesheet" href="Content/Bootstrap.css" />
    <link rel="stylesheet" href="Content/Site.css"/>
</head>
<body style="background-color:#94b8b8;" id="box-wrapper">
    <div class="col-xs-2 visible-xs"></div>
    <div id="loginbox" style="margin-top:100px;" class="vertical-align mainbox col-xs-8 col-lg-offset-2 col-lg-3 col-md-4 col-md-offset-2 col-sm-5 col-sm-offset-2 ">                    
        <div class="panel panel-info login-panel" >
            <div class="panel-heading login-heading">
                <div class="panel-title" style="margin-top:10px; font-size:20px; font-weight:bold;">Veterinary Manager</div>
            </div>     
            <div style="padding-top:30px" class="panel-body" >
                <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>                         
                <form id="loginform" class="form-horizontal" role="form" runat="server">
                    <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon login-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox runat="server" ID="txt_user" cssclass="form-control" placeholder="username or email"></asp:TextBox>                            
                            </div>                
                    <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon login-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox runat="server" ID="txt_pass" TextMode="Password" CssClass="form-control" placeholder="password"></asp:TextBox>
                            </div>
                        <div class="form-group">
                            <div class="col-md-12 control">
                                <div style="padding-top:15px; font-size:85%" > 
                                    <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="form-control btn btn-primary" />
                                </div>
                            </div>
                        </div>    
                    </form>     
                </div>                     
            </div>  
        </div>
</body>
</html>
