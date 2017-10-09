<%@ Page Title="NewData" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddData.aspx.vb" Inherits="VetClinic.About" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
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
    <h2>New OPD</h2>
    <hr />
    <h4>General</h4>
    <div class="form-horizontal" style="padding-top:20px;">
        <div class="form-group">
            <label class="control-label col-sm-2" for="name">ชื่อสัตว์เลี้ยง</label>
            <div class="col-sm-2">
                <input runat="server" type="text" class="form-control" id="petName" placeholder="Pet Name" name="petName" required="required">
            </div>
            <label class="control-label col-sm-1" for="age" >อายุ</label>
            <div class="col-sm-1" >
                <input runat="server" type="text" class="form-control" id="age" onkeypress="return isNumberKey(event)" placeholder="Age" name="age" />
            </div>
            <label class="control-label col-sm-1" for="month" >เดือน</label>
            <div class="col-sm-2" >
                <input runat="server" type="text" class="form-control" id="month" onkeypress="return isNumberKey(event)" placeholder="Month" name="month" />
            </div>
            <label class="control-label col-sm-1" for="breed">พันธุ์</label>
            <div class="col-sm-2" >
                <input runat="server" type="text" class="form-control" id="breed" placeholder="Breed" name="breed" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="petType">ชนิด</label>
            <div class="col-sm-4">
                <select runat="server" class="form-control" id="pet_Type">
                    <option selected="selected" style="display:none"></option>
                    <option>สุนัข</option>
                    <option>แมว</option>
                  </select>
            </div>
            <%--<label class="control-label col-sm-1" for="weight" >น้ำหนัก</label>
            <div class="col-sm-1" >
                <input runat="server" type="text" class="form-control" id="weight" placeholder="Kg" name="weight" />
            </div>--%>
            <label class="control-label col-sm-1" for="sex">เพศ</label>
            <div class="col-sm-2" >
                  <select runat="server" class="form-control" id="sex">
                    <option selected="selected" style="display:none"></option>
                    <option>ผู้</option>
                    <option>เมีย</option>
                  </select>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="holder_name-name">ชื่อเจ้าของ</label>
            <div class="col-sm-4">          
                <input runat="server" type="text" class="form-control" id="holder_name" placeholder="Holder Name" name="holder_name">
            </div>
            <label class="control-label col-sm-1" for="contact">เบอร์ติดต่อ</label>
            <div class="col-sm-2">          
                <input runat="server" onkeypress="return isNumberKey(event)" type="text" class="form-control" id="contact" placeholder="Phone Num." name="contact">
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="address">ที่อยู่เจ้าของ</label>
            <div class="col-sm-4">
                <textarea id="address" runat="server" rows="3" class="form-control" placeholder="Address"></textarea> 
            </div>
        </div>
        <hr />
        <h4>Vet Detail</h4>
        <div class="form-group">
            <label class="control-label col-sm-2" for="address">วันที่</label>
            <div class="col-sm-2">
                <dx:BootstrapDateEdit ID="date" runat="server" required="required"></dx:BootstrapDateEdit>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="details">Client Complain</label>
            <div class="col-sm-5">
                <textarea runat="server" id="details" rows="4" class="form-control" placeholder="CC. / HX. / Drug allergy / Vac.Done? / Previous MED. / Food type / PE."></textarea> 
            </div>
            <div class="col-sm-3" style="font-size:9px; color:red; padding-top:6px;">*PE. : Weight / Temp. / Heart Rate. /Pulse Rate./ Heart Sound / Lung Sound / CRT / MM / Parasite</div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="bw">Body Weight</label>
            <div class="col-sm-2">
                <input runat="server" type="text" class="form-control" id="bw" onkeypress="return isNumberKeyDecimal(evt)" placeholder="Kilogram" name="bw" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="lab">PE + Lab</label>
            <div class="col-sm-5">
                <textarea runat="server" id="lab" rows="5" class="form-control" placeholder="Lab / Treatment / Prevention"></textarea> 
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="address">Tx</label>
            <div class="col-sm-5">
                <textarea runat="server" id="fee" rows="4" class="form-control" placeholder="Fee Details Tx"></textarea> 
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="rx">Rx</label>
            <div class="col-sm-5">
                <textarea runat="server" id="rx" rows="4" class="form-control" placeholder="Fee Details Rx"></textarea> 
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="amount">Fee</label>
            <div class="col-sm-4">
                <input type="text" onkeypress="return isNumberKeyDecimal(evt)" runat="server" id="amount" class="form-control" placeholder="Amount (Baht)" name="amount">
            </div>
        </div>
        <div class="form-group">        
            <div class="col-sm-offset-2 col-sm-10">
            <asp:Button runat="server" ID="btn_Submit" CssClass="btn btn-default" Text="Submit" />
            <%--<button runat="server" id="btn_Submit" class="btn btn-default">Submit</button>--%>
          </div>
        </div>
    </div>
</asp:Content>
