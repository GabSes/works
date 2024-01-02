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
  <link rel="stylesheet" href="style/stylesheet.css">

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
	
  .ads-square {
      text-align: center;
      border: 4px solid #4682b4;
      padding: 30px;
      max-width: 2000px; /* Set a maximum width for better responsiveness */
      width: 100%; /* Ensure it takes full width within the container */
	  max-height: 1000px; /* Set a maximum width for better responsiveness */
      height: 100%; /* Set a fixed height */
      overflow: auto; /* Make the container scrollable if content exceeds the height */
      background-color: #ffffff;
      box-shadow: 0px 0px 10px 0px #888888;
      margin-top: 50px; /* Adjust margin to move the ads container down */
    }

</style>


</head>

<body>

  <!-- Navigation -->
  <?php
  $controller->printNavBar("users.php");
  ?>

  <!-- Page Content -->
<div class="container ads-square">
        <?php
            if($controller->canIShowUsersPage())
            {
                $controller->printUsersPage();
                $controller->handleUsersPageButton();
            }
        ?>
    </div>

  <!-- Bootstrap core JavaScript -->
  <script src="includes/jquery/jquery.slim.min.js"></script>
  <script src="includes/bootstrap/js/bootstrap.bundle.min.js"></script>

</body>

</html>
