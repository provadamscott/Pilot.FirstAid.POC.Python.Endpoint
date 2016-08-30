<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" CodeBehind="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    
    
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br /> <br />
        <asp:Label  runat="server" Text="Welcome!" Font-Size="X-Large" />
        <br /> <br />
        <asp:Label  runat="server" Text="Thank you for using Providence's First Aid Alexa Skill." />
        <br /> <br /> <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div runat="server" id="LoginDiv" >
                    <asp:Label  runat="server" Text="Username:" />
                    <asp:TextBox runat="server" ID="UserBox" TextMode="Email"/>
                    <br /> <br />
                    <asp:Label runat="server" Text="Password:" />
                    <asp:TextBox runat="server" ID="PassBox" TextMode="Password"/>
                </div>
                <div runat="server" id="RegisterDiv" visible="false" >
                    <asp:Label  runat="server" Text="Email:" />
                    <asp:TextBox runat="server" ID="EmailBox" TextMode="Email"/>
                    <br /> <br />
                    <asp:Label runat="server" Text="Password:" />
                    <asp:TextBox runat="server" ID="RegPassBox" TextMode="Password"/>
                    <br /> <br />
                    <asp:Label runat="server" Text="First name:" />
                    <asp:TextBox runat="server" ID="FirstBox" TextMode="Search"/>
                    <br /> <br />
                    <asp:Label runat="server" Text="Last name:" />
                    <asp:TextBox runat="server" ID="LastBox" />
                    <br /> <br />
                    <asp:Label runat="server" Text="Preferred name:" />
                    <asp:TextBox runat="server" ID="PrefNameBox" />
                    <br /> <br />
                    <asp:Label runat="server" Text="DOB:" />
                    <asp:TextBox runat="server" Text="MM/DD/YYYY" ID="DOBBox" Width="90px" />
                    <br /> <br />
                    <asp:Label runat="server" Text="SSID: ###-##-" />
                    <asp:TextBox runat="server" Text="####" ID="TextBox1" Width="35px"/>
                    <br /> <br />
                    <asp:Label runat="server" Text="Gender:" />
                    <asp:DropDownList ID="GenderDropDown" runat="server">
                        <asp:ListItem Text="Male" />
                        <asp:ListItem Text="Female" />
                    </asp:DropDownList>
                </div>
                <br /> <br />
                <asp:Button runat="server" Text="Login" ID="LoginButton" OnClick="LoginButton_Click" />
                <br /> <br />
                <asp:Button runat="server" Text="New User? Click here." ID="RegisterButton" OnClick="RegisterButton_Click" />
                <br /> <br />
                <asp:Label runat="server" ID="ResultLabel" />
                <br /> <br />
                <asp:Label runat="server" ID="URLLabel" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
