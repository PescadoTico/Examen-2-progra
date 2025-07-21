<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="ClinicaUH_Gutierrez.Forms.Citas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de Citas</title>

    <style>
        body {
            background-image: url('../Items/Hospital3.jpg');
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
            <h2>Citas</h2>

            <label>Número de Consultorio:</label><br />
            <asp:TextBox ID="txtNumConsultorio" runat="server" /><br />

            <label>Hora de Atención:</label><br />
            <asp:TextBox ID="txtHoraAtencion" runat="server" TextMode="Time" /><br />

            <label>Fecha de Atención:</label><br />
            <asp:TextBox ID="txtFechaAtencion" runat="server" TextMode="Date" /><br />

            <label>ID Médico:</label><br />
            <asp:TextBox ID="txtIDMedico" runat="server" /><br />

            <label>Cédula del Paciente:</label><br />
            <asp:TextBox ID="txtCedula" runat="server" /><br /><br />

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cita" OnClick="btnAgregar_Click" /><br /><br />

            <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NumCita" HeaderText="Número de Cita" ReadOnly="true" />
                    <asp:BoundField DataField="NumConsultorio" HeaderText="Consultorio" />
                    <asp:BoundField DataField="HoraAtencion" HeaderText="Hora" DataFormatString="{0:hh\\:mm}" />
                    <asp:BoundField DataField="FechaAtencion" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="IDMedico" HeaderText="ID Médico" />
                    <asp:BoundField DataField="CedulaPaciente" HeaderText="Cédula Paciente" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-eliminar" />

            <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
