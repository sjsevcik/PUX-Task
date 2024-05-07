<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PUXTask.Default" %>

<!DOCTYPE html>

<html lang="cs">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> – PUXTask technologie ASP.NET</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="mt-4">
                <h1>CVIČNÝ ÚKOL</h1>
                <p class="lead">Program detekuje změny v lokálním adresáři uvedeném na vstupu. Při prvním spuštění si program obsah daného adresáře analyzuje a při každém dalším spuštění bude hlásit změny od svého posledního spuštění.</p>
            </div>

            <div class="row my-5">
                <div class="col-md-auto">
                    <label for="TextBox1" class="col-form-label">Vstupní adresář:</label>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Naskenuj adresář" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-secondary" Text="Detekuj změny adresáře" OnClick="Button2_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <h2>nové soubory</h2>
                    <asp:BulletedList ID="BlNewFiles" runat="server"></asp:BulletedList>
                </div>
                <div class="col-md-4">
                    <h2>změněné soubory</h2>
                    <asp:BulletedList ID="BlChangedFiles" runat="server"></asp:BulletedList>
                </div>
                <div class="col-md-4">
                    <h2>smazané soubory</h2>
                    <asp:BulletedList ID="BlDeletedFiles" runat="server"></asp:BulletedList>
                </div>
            </div>

            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                <asp:Label ID="LbMsg" runat="server" Text="xxx"></asp:Label>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - SJ, PUXTask technologie ASP.NET</p>
            </footer>
        </div>
    </form>
</body>
</html>
