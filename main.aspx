<%@ Page Title="Talkz - Main" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="main.aspx.vb" Inherits="main" %>

<asp:Content ID="mainPage" runat="server" ContentPlaceHolderID="head">
    <script src="resources/scripts/main.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">

    <h1 class="header-title">Talkz</h1>

    <div id="content">
        <div class="top-tools">
            <i class="material-icons refresh-btn">refresh</i>
        </div>
        
        <div class="chat-box">
            <div class="sender">
                <i class="material-icons sender-face">account_circle</i>
                <p class="senders-name">Spalqui</p>
            </div>
            <div class="message-content"><p>Yo</p></div>
            <div class="sent-time">12:00AM</div>
        </div>
           


        <div class="message-box">
            <textarea id="message"></textarea>
            <div class="message-tools">
                <i id="sendMessage" class="material-icons">send</i>     
            </div>                  
        </div>


    </div>

</asp:Content>

