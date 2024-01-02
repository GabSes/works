<?php
session_start();
foreach (glob("src/*.php") as $filename)
{
    include $filename;
}
$controller = new Controller();
?>
<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="Gyvūnų paieškos/radimo portalas">
  <meta name="author" content="Gabija Šeškauskaitė IFF-0/2">

  <title>Gyvūnų paieška</title>

  <!-- Bootstrap core CSS -->
  <link href="includes/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link rel="stylesheet" href="style/stylesheet.css">

<style>
    body {
        background-color: #f0f8ff;
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
        background-color: #4682b4 !important;
    }

    .content-square {
        text-align: center;
        border: 4px solid #4682b4;
        padding: 30px;
        max-width: 1500px; /* Increased maximum width for better responsiveness */
        width: 100%; 
        background-color: #ffffff;
        box-shadow: 0px 0px 10px 0px #888888;
    }

    .login-image {
        max-width: 100%; /* Ensure the image doesn't exceed the container width */
        margin-bottom: 20px;
    }

    h1 {
        font-size: 2.5em; /* Adjust the font size of the heading */
    }

    p {
        font-size: 1.5em; /* Adjust the font size of the paragraph */
    }
</style>





</head>

<body>

  <!-- Navigation -->
  <?php
    $controller->printNavBar("index.php");
  ?>

<!-- Page Content -->
<div class="content-square">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <img src="gyvunai.jpg" alt="Gyvunai" class="login-image">
                <h1 class="mt-5">Gyvūnų paieškos/radimo sistema</h1>
                <p class="lead">Čia galite ieškoti dingusių gyvūnų</p>
            </div>
        </div>
    </div>
</div>


  <!-- Bootstrap core JavaScript -->
  <script src="includes/jquery/jquery.slim.min.js"></script>
  <script src="includes/bootstrap/js/bootstrap.bundle.min.js"></script>

</body>

</html>
