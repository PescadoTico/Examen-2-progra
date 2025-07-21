<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="ClinicaUH_Gutierrez.Forms.Pacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de Pacientes</title>

    <style>
        body {
            background-image: url('../Items/Hospital4.jpg');
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

        @keyframes caer {
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        .content {
            margin-left: 220px;
            padding: 20px;
        }
    </style>
</head>
<body>
    <ul>
        <li><a href="Menu.aspx"><- Menu Principal</a></li>
    </ul>

    <form id="form1" runat="server">
        <div class="content">
            <h2>Pacientes</h2>

            <label>Cédula:</label><br />
            <asp:TextBox ID="txtCedula" runat="server" /><br />

            <label>Nombre:</label><br />
            <asp:TextBox ID="txtNombre" runat="server" /><br />

            <label>Apellido:</label><br />
            <asp:TextBox ID="txtApellido" runat="server" /><br />

            <label>Fecha de Nacimiento:</label><br />
            <asp:TextBox ID="txtFechaDeNacimiento" runat="server" TextMode="Date" /><br />

            <label>Teléfono:</label><br />
            <asp:TextBox ID="txtTelefono" runat="server" /><br />

            <label>Correo:</label><br />
            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" /><br />

            <label>Edad:</label><br />
            <asp:TextBox ID="txtEdad" runat="server" TextMode="Number" /><br /><br />

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Paciente" OnClick="btnAgregar_Click" /><br /><br />

            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="FechaDeNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar (No Funciona)" OnClick="btnEliminar_Click" />
        </div>
    </form>
</body>
</html>
