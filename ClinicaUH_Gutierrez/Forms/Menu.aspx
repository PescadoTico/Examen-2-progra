<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ClinicaUH_Gutierrez.Forms.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    
    <title>Menu</title>
<style>
  body {
    background-image: url('https://wallpapercat.com/w/full/d/5/6/276281-2560x1600-desktop-hd-dr-house-background-photo.jpg');
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
</style>



</head>
    



<body>
    <form id="form1" runat="server">

        <ul>
  <li><a href="Medicos.aspx">Agregar Medicos</a></li>
  <li><a href="Pacientes.aspx">Pacientes</a></li>
  <li><a href="Citas.aspx">Citas</a></li>
  <li><a href="Detalles.aspx">Detalles</a></li>
</ul>


        <div>
        </div>
    </form>


</body>
</html>
