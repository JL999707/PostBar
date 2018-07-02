<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tabContent.ascx.cs" Inherits="tabContent" %>



<%--<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>--%>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="postID" DataSourceID="SqlDataSource1" GridLines="None">
    <Columns>
        <asp:TemplateField>

            <ItemTemplate>
                <div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">
                    <asp:Label ID="barName" runat="server" Text='<%# Eval("barID") %>'></asp:Label>
                                                     </a></h4></div>
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


<%--<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button5" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button6" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button7" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button8" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button9" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>

<div class="dynamic_hot_barName"><h4><a href="../Bar.aspx">废土行动吧</a></h4></div>
<div class="dynamic_hot_title"><h4><a href="../Bar.aspx">【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
<div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
<div class="dynamic_hot_img"></div>
<asp:Button ID="Button10" runat="server" Text="Button" OnClick="Button1_Click" />
<div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>--%>
