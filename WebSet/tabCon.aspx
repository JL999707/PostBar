<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="tabCon.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/control/tableCon.ascx" TagPrefix="uc1" TagName="tableCon" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:tableCon runat="server" id="tableCon" />
</asp:Content>

