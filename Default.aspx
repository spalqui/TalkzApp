<%@ Page Title="Talkz - Login" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="loginPage"  runat="server" ContentPlaceHolderID="mainContent">

    <div runat="server">

        <!-- Hidden Fields -->
        <asp:HiddenField ID="validationFeedback" runat="server" />




        <!--Title-->
        <h1 class="header-title">Talkz</h1>

        <div id="content">
        
            <!--Login Screen-->
            <div class="login-screen">

                <div class="ls-top-half"><i id="login-face" class="material-icons">account_circle</i></div>
                <div class="login-details">
                    <p><asp:TextBox ID="emailTxt" cssClass="login-details-txt" runat="server" placeHolder="Please enter your email"></asp:TextBox></p>
                    <p><asp:TextBox ID="passwordTxt" cssClass="login-details-txt" runat="server" placeHolder="Password" TextMode="Password"></asp:TextBox></p>
                </div>
                <div class="ls-bottom-half">
                    <p><asp:Button ID="loginBtn" cssClass="button login-btn" runat="server" Text="Sign In" /></p>
                </div>

            </div>
            <div class="create-account-box">
                <asp:LinkButton ID="createAccLbl" runat="server" Text="Create an account" cssClass="create-account-lbl" BorderStyle="None"></asp:LinkButton>
            </div>    

        </div>
      
    </div>


</asp:Content>

