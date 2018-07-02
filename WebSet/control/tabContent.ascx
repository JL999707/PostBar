<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tabContent.ascx.cs" Inherits="tabContent" %>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="postID" DataSourceID="SqlDataSource1" GridLines="None">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div class="dynamic_hot_barName">
                    <h4><a href="../Bar.aspx">
                        <asp:Label ID="barName" runat="server" Text='<%# Eval("barID") %>'></asp:Label>
                    </a></h4>
                </div>
                <div class="dynamic_hot_postName">
                    <h4><a href="../Bar.aspx">
                        <asp:Label ID="postName" runat="server" Text='<%# Eval("postName") %>'></asp:Label>
                    </a></h4>
                </div>
                <div class="dynamic_hot_postContent">
                    <asp:Label ID="postContent" runat="server" Text='<%# Eval("postContent") %>'></asp:Label>
                </div>
                <div class="dynamic_hot_postImg"></div>
                <div class="dynamic_hot_postAuthor">
                    <asp:Label ID="postAuthor" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="postTime" runat="server" Text='<%# Eval("postTime") %>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostBarConnectionString %>" SelectCommand="SELECT * FROM [T_Post]"></asp:SqlDataSource>
