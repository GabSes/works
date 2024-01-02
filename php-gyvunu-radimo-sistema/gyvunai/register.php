<?php
session_start();
foreach (glob("src/*.php") as $filename)
{
    include $filename;
}
$controller = new Controller();
$view = new View();
?>
<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="Gyvūnų paieškos/radimo portalas">
  <meta name="author" content="Gabija Šeškauskaitė IFF-0/2">

  <title>Gyvūnų paieškos/radimo skelbimai</title>

  <!-- Bootstrap core CSS -->
  <link href="includes/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Inline CSS for register page -->
  <style>
    body {
      background-color: #f0f8ff; /* Very light pastel blue outside the square */
      display: flex;
      align-items: center;
      justify-content: center;
      height: 100vh;
      margin: 0;
    }

    .navbar {
      position: fixed;
      top: 0;
      width: 100%;
      z-index: 1000;
      background-color: #4682b4 !important; /* Set the same color as the square border */
    }

    .register-container {
      border: 4px solid #4682b4; /* Steel Blue border for the register container, adjusted thickness */
      padding: 30px; /* Add padding for better spacing */
      background-color: #ffffff; /* White background inside the border */
      box-shadow: 0px 0px 10px 0px #888888; /* Add a subtle box shadow for depth */
      margin-top: 50px; /* Adjust margin to move the register container down */
      text-align: center; /* Center the register form */
    }

    /* Add more styles as needed */
  </style>

</head>

<body>

  <!-- Navigation -->
  <?php
  $controller->printNavBar("register.php");
  ?>

  <!-- Page Content -->
  <div class="container">

      <?php
      if($controller->canIShowRegisterPage())
      {
          echo '<div class="register-container">';
          $controller->printRegisterForm();
          $controller->handleRegisterButton();
          echo '</div>';
      }

      ?>
  </div>

  <!-- Bootstrap core JavaScript -->
  <script src="includes/jquery/jquery.slim.min.js"></script>
  <script src="includes/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>

</html>
