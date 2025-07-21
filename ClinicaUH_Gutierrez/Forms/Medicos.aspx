<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="ClinicaUH_Gutierrez.Forms.Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de Médicos</title>

    <style>
        body {
            background-image: url('../Items/Hospital.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            background-position: bottom center;
            min-height: 100vh;
            margin: 0;
        }

        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 200px;
            background-color: rgba(241, 241, 241, 0.8);
        }

        li a {
            display: block;
            color: #000;
            padding: 8px 16px;
            text-decoration: none;
        }

        li a:hover {
            background-color: #826868;
            color: white;
        }

        li {
            opacity: 0;
            transform: translateY(-50px);
            animation: caer 0.8s ease-out forwards;
        }

        li:nth-child(1) { animation-delay: 0s; }
        li:nth-child(2) { animation-delay: 0.1s; }
        li:nth-child(3) { animation-delay: 0.2s; }
        li:nth-child(4) { animation-delay: 0.3s; }

        @keyframes caer {
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        .error {
            color: red;
            font-weight: bold;
            margin-top: 10px;
        }

        .container {
            margin-left: 220px;
            padding: 20px;
            max-width: 600px;
        }

        .btn-eliminar {
            margin-top: 15px;
            display: block;
            width: 120px;
            padding: 8px;
            font-size: 14px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <ul>
        <li><a href="Menu.aspx"><- Menú Principal</a></li>
    </ul>

    <form id="form1" runat="server">
        <div class="container">
            <h2>Médicos</h2>

            <label>Nombre:</label><br />
            <asp:TextBox ID="txtNombre" runat="server" /><br />

            <label>Apellido:</label><br />
            <asp:TextBox ID="txtApellido" runat="server" /><br />

            <label>Especialidad:</label><br />
            <asp:TextBox ID="txtEspecialidad" runat="server" /><br /><br />

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Médico" OnClick="btnAgregar_Click" /><br /><br />

            <asp:GridView ID="gvMedicos" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="IDMedico" HeaderText="ID Médico" />
                </Columns>
            </asp:GridView>


            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-eliminar" OnClick="btnEliminar_Click" />
        </div>
    </form>
</body>
</html>
