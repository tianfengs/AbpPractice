<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileInterstitial.aspx.cs" Inherits="DetectMobileUser.MobileInterstitial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <p>这里是一段文案！这里是一段文案！</p>
            <p>这里是一段文案！这里是一段文案！</p>
        <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="去下载" />
        <asp:Button ID="btnThanks" runat="server" OnClick="btnThanks_Click" Text="不，谢谢！" />

    </div>
    </form>
</body>
</html>
