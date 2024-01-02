<?php
class View {
    private $model;
    function __construct()
    {
        $this->model = new Model();
    }

    public function printNavbar($location)
    {
        echo '
          <nav class="navbar navbar-expand-lg navbar-dark bg-dark static-top">
            <div class="container">
              <a class="navbar-brand" href="index.php">Gyvūnų paieškos/radimo skelbimai</a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">';
                $this->printNavbarItem("Namai", "index.php", $location);
                $this->printNavbarItem("Skelbimai", "ads.php", $location);
                if($_SESSION['role'] == "0")
                {
                    $this->printNavbarItem("Registruotis", "register.php", $location);
                    $this->printNavbarItem("Prisijungti", "login.php", $location);
                }
                else
                {
                    if($_SESSION['role'] == 3)
                    {
                        $this->printNavbarItem("Narių sąrašas", "users.php", $location);
                    }
                    $this->printNavbarItem("Mano skelbimai", "myads.php", $location);
                    $this->printNavbarItem("Atsijungti", "logout.php", $location);
                }
                echo '</ul>
              </div>
            </div>
          </nav>
        ';
    }

    function printNavbarItem($name, $location, $globalLocation)
    {
        if($globalLocation == $location)
        {
            echo '
                  <li class="nav-item active">
                    <a class="nav-link" href="'.$location.'">'.$name.'</a>
                  </li>';
        }
        else
        {
            echo '
                  <li class="nav-item">
                    <a class="nav-link" href="'.$location.'">'.$name.'</a>
                  </li>';
        }
    }

    function printRegisterForm()
    {
    	//value="'.$username.'"
    	if(isset($_POST['username']))
    		$username = htmlentities($_POST["username"]);
    	else
    		$username = "";

    	if(isset($_POST['email']))
    		$email = htmlentities($_POST["email"]);
    	else
    		$email = "";

    	if(isset($_POST['first_name']))
    		$first_name = htmlentities($_POST["first_name"]);
    	else
    		$first_name = "";

    	if(isset($_POST['last_name']))
    		$last_name = htmlentities($_POST["last_name"]);
    	else
    		$last_name = "";
        echo '
              <div class="main-content--small-margin">
        <form method="POST">
          <div class="form-group">
              <label for="inputEmail">Naudotojo vardas</label>
              <input name="username" type="text" class="form-control" id="inputEmail" placeholder="Naudotojo vardas" value="'.$username.'">
          </div>
          <div class="form-group">
              <label for="inputEmail">Elektroninis paštas</label>
              <input name="email" type="text" class="form-control" id="inputEmail" placeholder="El. Paštas" value="'.$email.'">
          </div>
          <div class="form-group">
              <label for="inputEmail">Vardas</label>
              <input name="first_name" type="text" class="form-control" id="inputEmail" placeholder="Vardas" value="'.$first_name.'">
          </div>
          <div class="form-group">
              <label for="inputEmail">Pavardė</label>
              <input name="last_name" type="text" class="form-control" id="inputEmail" placeholder="Pavardė" value="'.$last_name.'">
          </div>
          <div class="form-group">
              <label for="inputPassword">Slaptažodis</label>
              <input name="password" type="password" class="form-control" id="inputPassword" placeholder="Slaptažodis">
          </div>
          <div class="form-group">
              <label for="inputPassword">Pakartokite slaptažodį</label>
              <input name="password_repeat" type="password" class="form-control" id="inputPassword" placeholder="Pakartokite slaptažodį">
          </div>
          <button type="submit" name="register_btn" class="btn btn-primary">Registruotis</button>
      </form>
    </div>
        ';
    }

    function printLoginForm()
    {
    	//value="'.$username.'"
    	if(isset($_POST['username']))
    		$username = htmlentities($_POST["username"]);
    	else
    		$username = "";
        echo '      <div class="main-content--small-margin">
        <form method="POST">
          <div class="form-group">
              <label for="inputEmail">Naudotojo vardas</label>
              <input type="text" class="form-control" id="inputEmail" name="username" placeholder="Naudotojo vardas" value="'.$username.'">
          </div>
          <div class="form-group">
              <label for="inputPassword">Slaptažodis</label>
              <input type="password" class="form-control" id="inputPassword" name="password" placeholder="Slaptažodis">
          </div>
          <button type="submit" name="login_btn" class="btn btn-primary">Prisijungti</button>
      </form>
    </div>';
    }

    function printSuccess($text)
    {
        echo '<div class="alert alert-success" role="alert">'.$text.'</div>';
    }

    function printDanger($text)
    {
        echo '<div class="alert alert-danger" role="alert">'.$text.'</div>';
    }

    function printUsersPage($array)
    {
        echo '        <div class="main-content--small-margin">
            <h1>Naudotojų sąrašas:</h1>
            <ul class="list-group">';

        if ($array->num_rows > 0)
        {
            // output data of each row
            while($row = $array->fetch_assoc())
            {
                echo '<form method="POST">';
                if($row['verified'] == "0")
                {
                    echo '<li class="list-group-item d-flex justify-content-between align-items-center">'.$row['username'].'<button name="changeRole" value="'.$row['username'].'" class="btn btn-danger btn-sm">Nepatvirtintas</button></li>';
                }
                else
                {
                    echo '<li class="list-group-item d-flex justify-content-between align-items-center">'.$row['username'].'<button name="changeRole" value="'.$row['username'].'" class="btn btn-primary btn-sm">Patvirtintas</button></li>';
                }
                echo '</form>';
            }
        }
        else
        {
            $this->printSuccess("Sistemoje nėra paprasto tipo naudotojų!");
        }
        echo '</ul>
        </div>';
    }

    function printUsersPageDeleteForm()
    {
        echo '
        <form method="POST" class="main-content--small-margin">
          <div class="form-group">
              <label for="inputEmail">Įveskite naudotojo vardą statusą norite pakeisti.</label>
              <input type="text" class="form-control" id="inputEmail" name="username" placeholder="Naudotojo vardas">
          </div>
          <button type="submit" name="verify_btn" class="btn btn-primary">Pakeisti</button>
      </form>';
    }

 function printMyAdsContent($searchJobArr, $giveJobArr)
{
    // Check if the user has role 3
    if ($_SESSION['role'] == 3) {
        echo '<div class="main-content--small-margin">
                  <h5>Naudotojui su jūsų teisėmis šiame puslapyje neleidžiama.</h5>
              </div>';
        return; // Exit the function if the user has role 3
    }
 if ($_SESSION['role'] == 2) {
        echo '<div class="main-content--small-margin">
                  <h5>Naudotojui su jūsų teisėmis šiame puslapyje neleidžiama.</h5>
              </div>';
        return; // Exit the function if the user has role 3
    }
	echo '<style>
            .list-group-item:hover {
                background-color: #f0f8ff; /* Light blue color */
                transition: background-color 0.3s ease; /* Add smooth transition */
            }
          </style>';
    echo '<div class="main-content--small-margin">
              <div class="list-group">
                  <h1>"Ieškau gyvūno" - skelbimai</h1>';

    if ($searchJobArr->num_rows > 0)
    {
        while ($row = $searchJobArr->fetch_assoc())
        {
            echo '<a href="viewad.php?id=' . $row['id'] . '" class="list-group-item list-group-item-action flex-column align-items-start">
                  <div class="d-flex w-100 justify-content-between">
                      <h5 class="mb-1">' . $row['title'] . '</h5>
                      <small>Galioja iki ' . $row['valid_till'] . '</small>
                  </div>
                  <p class="mb-1">' . $row['text'] . '</p>
              </a>';
        }
    }
    else
    {
        echo "<h5>Neturite tokio tipo skelbimų.</h5>";
    }

    echo '<div class="list-group">
              <h1>"Rasti gyvūnai" - skelbimai</h1>';

    if ($giveJobArr->num_rows > 0)
    {
        while ($row = $giveJobArr->fetch_assoc())
        {
            echo '<a href="viewad.php?id=' . $row['id'] . '" class="list-group-item list-group-item-action flex-column align-items-start">
                  <div class="d-flex w-100 justify-content-between">
                      <h5 class="mb-1">' . $row['title'] . '</h5>
                      <small>Galioja iki ' . $row['valid_till'] . '</small>
                  </div>
                  <p class="mb-1">' . $row['text'] . '</p>
              </a>';
        }
    }
    else
    {
        echo "<h5>Neturite tokio tipo skelbimų.</h5>";
    }

    echo '</div>
          </div>
        </div>';
}


    function printSubmitNewAdButton($isActiveButton)
    {
        if($isActiveButton)
        {
            echo '<a href="createad.php"> <button type="submit" class="btn btn-primary main-content--small-margin">Sukurti naują skelbimą</button> </a>';
        }
        else
        {
            echo ' <button type="submit" class="btn btn-primary main-content--small-margin disabled">Sukurti naują skelbimą</button> <h5 style="color:red">Kaip administratorius patvirtins jūsų paskyrą, galėsite kelti skelbimus.</h5>';
        }
    }

   function printCreateNewAdForm()
{
    if (isset($_POST['title'])) {
        $title = htmlentities($_POST["title"]);
    } else {
        $title = "";
    }

    if (isset($_POST['text'])) {
        $text = htmlentities($_POST["text"]);
    } else {
        $text = "";
    }

    if (isset($_POST['age'])) {
        $age = intval($_POST["age"]);  // Convert to integer
    } else {
        $age = "";
    }

    if (isset($_POST['type'])) {
        $type = htmlentities($_POST["type"]);
    } else {
        $type = "";
    }

if (isset($_POST['valid_till'])) {
        $valid_till = htmlentities($_POST["valid_till"]);
    } else {
        $valid_till = "";
    }

    if (isset($_POST['species'])) {
        $species = htmlentities($_POST["species"]);
    } else {
        $species = "";
    }

    if (isset($_POST['gender'])) {
        $gender = htmlentities($_POST["gender"]);
    } else {
        $gender = "";
    }

    if (isset($_POST['place'])) {
        $place = htmlentities($_POST["place"]);
    } else {
        $place = "";
    }
	if (isset($_POST['phone'])) {
        $phone = htmlentities($_POST["phone"]);
    } else {
        $phone = "";
    }

    echo '<form method="POST" enctype="multipart/form-data" class="main-content--small-margin">
          <div class="form-group">
            <label for="exampleFormControlInput1">Pavadinimas</label>
            <input type="text" name="title" class="form-control" id="exampleFormControlInput1" placeholder="Gyvūno vardas" value="' . $title . '">
          </div>
          <div class="form-group">
            <label for="exampleFormControlSelect1">Skelbimo tipas</label>
            <select name="type" class="form-control" id="exampleFormControlSelect1">
              <option value="Found">Rasti gyvūnai</option>
              <option value="Lost">Dingę gyvūnai</option>
            </select>
          </div>
          <div class="form-group">
            <label for="exampleFormControlInput1">Trumpas pristatymas</label>
            <input name="text" type="text" class="form-control" id="exampleFormControlInput1" placeholder="Gyvūno aprašymas" value="' . $text . '">
          </div>
<div class="form-group">
            <label for="exampleFormControlInput1">Gyvūno amžius</label>
            <input name="age" type="number" class="form-control" id="exampleFormControlInput1" placeholder="Amžius" value="' . $age . '" min="0">
          </div>
          <div class="form-group">
            <label for="exampleFormControlInput1">Gyvūno rūšis</label>
            <select name="species" class="form-control" id="exampleFormControlSelect1">
			<option value="Katinas">Katinas</option>
            <option value="Šuo">Šuo</option>
            </select>
          </div>
<div class="form-group">
            <label for="exampleFormControlInput1">Iki kada galios skelbimas</label>
            <input name="valid_till" type="date" class="form-control" id="exampleFormControlInput1" placeholder="YYYY-MM-DD" value="' . $valid_till . '" min="' . date('Y-m-d') . '">
          </div>
          <div class="form-group">
            <label for="exampleFormControlSelect1">Lytis</label>
            <select name="gender" class="form-control" id="exampleFormControlSelect1">
              <option value="Patelė">Patelė</option>
              <option value="Patinas">Patinas</option>
            </select>
          </div>
          <div class="form-group">
            <label for="exampleFormControlInput1">Gyvūno radimo vieta</label>
            <input name="place" type="text" class="form-control" id="exampleFormControlInput1" placeholder="Vieta" value="' . $place . '">
          </div>
		   <div class="form-group">
            <label for="exampleFormControlInput1">Tel.nr</label>
            <input name="phone" type="text" class="form-control" id="exampleFormControlInput1" placeholder="Tel.nr" value="' . $phone . '">
          </div>
 <label for="image">Image:</label>
    <input type="file" name="image" id="image" accept="image/*">
    <br>
          <button type="submit" name="createad_btn" class="btn btn-primary">Sukurti naują skelbimą</button>
        </form>';
}


    function printGlobalAdsContent($searchJobArr, $giveJobArr)
    {
		 echo '<style>
            .list-group-item:hover {
                background-color: #f0f8ff; /* Light blue color */
                transition: background-color 0.3s ease; /* Add smooth transition */
            }
          </style>';
        echo '      <div class="main-content--small-margin">
      <div class="list-group">
          <h1>"Ieškau gyvūno" - skelbimai</h1>';

  // Display species filter form
		echo '<form method="GET" action="' . $_SERVER['PHP_SELF'] . '" class="d-flex mb-2">';

        echo '<label for="species" class="mb-1">Filtruoti pagal gyvūno rūšį:</label>';
		
        echo '<select name="species" id="species" class="custom-select custom-select-lg">';
        
        // Add options for different species - you can customize this based on your actual species data
        $speciesOptions = ['Katinas', 'Šuo',];
        foreach ($speciesOptions as $option) {
            echo '<option value="' . $option . '">' . $option . '</option>';
        }

        echo '</select>';
        echo '<button type="submit" class="btn btn-primary">Filtruoti</button>';
        echo '</form>';

        if ($searchJobArr->num_rows > 0)
        {
            while($row = $searchJobArr->fetch_assoc())
            {
                echo '          <a href="viewad.php?id='.$row['id'].'" class="list-group-item list-group-item-action flex-column align-items-start">
            <div class="d-flex w-100 justify-content-between">';

                $viewCount = $this->model->getCountOfAdVisits($row['id']);
                if($_SESSION['role'] >= 2)
                {
                    echo '<h5 class="mb-1">'.$row['title'].' (id: '.$row['id'].') (Peržiūros: '.$viewCount.')</h5>';
                }
                else
                {
                    echo '<h5 class="mb-1">'.$row['title'].'</h5>';
                }

            echo '<small>Galioja iki '.$row['valid_till'].'</small>
            </div>
            <p class="mb-1">'.$row['text'].'</p>
          </a>';
            }
        }
        else
        {
            echo "<h5>Nėra tokio tipo skelbimų.</h5>";
        }

        echo '<div class="list-group">
            <h1>"Rasti gyvūnai" - skelbimai</h1>';

        if ($giveJobArr->num_rows > 0)
        {
            while($row = $giveJobArr->fetch_assoc())
            {
                $viewCount = $this->model->getCountOfAdVisits($row['id']);
                echo '          <a href="viewad.php?id='.$row['id'].'" class="list-group-item list-group-item-action flex-column align-items-start">
            <div class="d-flex w-100 justify-content-between">';

                if($_SESSION['role'] >= 2)
                {
                    echo '<h5 class="mb-1">'.$row['title'].' (id: '.$row['id'].') (Peržiūros: '.$viewCount.')</h5>';
                }
                else
                {
                    echo '<h5 class="mb-1">'.$row['title'].'</h5>';
                }

                echo '<small>Galioja iki '.$row['valid_till'].'</small>
            </div>
            <p class="mb-1">'.$row['text'].'</p>
          </a>';
            }
        }
        else
        {
            echo "<h5>Nėra tokio tipo skelbimų.</h5>";
        }

        echo  '</div>
        </div>
      </div>';
    }

  function printGlobalAdsRemoveForm() {
        // Check if the user has the necessary role to see and use the delete ads form
        if ($_SESSION['role'] == 2) {
            echo '
                <form method="POST" class="main-content--small-margin d-flex">
                    <div class="form-group">
                        <label for="inputEmail">Įveskite skelbimo ID kurį norite ištrinti.</label>
                        <input type="text" class="form-control" id="inputEmail" name="ad_id" placeholder="Skelbimo ID">
                    </div>
                    <button type="submit" name="delete_btn" class="btn btn-danger">Ištrinti</button>
                </form>
            ';
        } else {
            // User doesn't have the required role, so you can display a message or take another action
            echo '<p>You do not have permission to delete ads.</p>';
        }
  }

function printOneAd($adArr)
{
    while ($row = $adArr->fetch_assoc()) {
        // title, text, age, validtill, type, species, gender, place

        $title = $row['title'];
        $text = $row['text'];
        $age = $row['age'];
        $valid_till = $row['valid_till'];
        $species = $row['species'];
        $gender = $row['gender'];
        $place = $row['place'];
		$phone = $row['phone'];
        $imageData = base64_encode($row['imageData']);
        $imageSrc = "data:image/png;base64,{$imageData}";

echo '<style>
    .ad-container {
        text-align: center;
        margin-top: 20px;
    }

    img {
        max-width: 100%;
        height: auto;
        max-height: 700px; /* Set the maximum height for the image */
    }

    dl.row {
        display: flex;
        flex-wrap: wrap;
        justify-content: flex-start;
    }

    dl.row dt, dl.row dd {
        flex: 0 0 50%; /* Each label and information takes half of the row */
        margin-bottom: 5px; /* Adjusted space below each label and information */
        padding: 5px; /* Add padding for better spacing */
    }

    dl.row dt {
        font-weight: bold; /* Make labels bold */
        text-align: right; /* Align labels to the right */
    }

    dl.row dd {
        text-align: left; /* Align information to the left */
    }
</style>



';





        echo '<div class="main-content--small-margin ad-container">
                <img src="' . $imageSrc . '" alt="Ad Image">
                <dl class="row">

                    
                    <dt>Vardas:</dt>
                    <dd>' . $title . '</dd>
                    
                    <dt>Aprašymas:</dt>
                    <dd>' . $text . '</dd>
                    
                    <dt>Amžius:</dt>
                    <dd>' . $age . '</dd>
                    
                    <dt>Rūšis:</dt>
                    <dd>' . $species . '</dd>

                    <dt>Skelbimas aktyvus iki:</dt>
                    <dd>' . $valid_till . '</dd>
                    
                    <dt>Lytis:</dt>
                    <dd>' . $gender . '</dd>
                    
                    <dt>Vieta:</dt>
                    <dd>' . $place . '</dd>
					<dt>Tel. nr:</dt>
                    <dd>' . $phone . '</dd>
                </dl>
            </div>';
    }
}



    function printAdCommentForm()
    {
        echo '<form method="POST">
              <div class="form-group">
                <label for="exampleFormControlInput1">Jūsų vartotojo vardas</label>
                <input type="text" class="form-control" id="exampleFormControlInput1" value="'.$_SESSION['username'].'" disabled>
              </div>


              <div class="form-group">
                <label for="exampleFormControlTextarea1">Komentaras</label>
                <textarea name="comment" class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
              </div>
              <button name="comment_btn" class="btn btn-primary">Komentuoti</button>
            </form>';
    }

    function printAdComment($commentArr)
    {
        if ($commentArr->num_rows > 0)
        {
            echo '<h3>Komentarai</h3>';
            while($row = $commentArr->fetch_assoc())
            {
                echo '<div class="list-group" style="margin-bottom: 20px">
                      <a href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                        <div class="d-flex w-100 justify-content-between">
                          <h5 class="mb-1">'.$row['first_name'].' '.$row['last_name'].'</h5>
                          <small class="text-muted">'.$row['date'].'</small>
                        </div>
                        <p class="mb-1">'.$row['text'].'</p>
                        <small class="text-muted">'.$row['email'].'</small>
                      </a>
                    </div>';
            }
        }
    }
	// Add this method to your View class
public function printAdsDeletionForm($adsForDeletion)
{
    echo '<form method="post" action="" class="d-flex align-items-center">
            <div class="flex-grow-1 mr-2">
                <label for="adsToDelete">Pasirinkite kurį skelbimą ištrinti:</label>
                <select name="adsToDelete[]" multiple class="custom-select custom-select-lg">';
    
                foreach ($adsForDeletion as $ad) {
                    echo '<option value="' . $ad['id'] . '">' . $ad['title'] . '</option>';
                }

    echo       '</select>
            </div>
            <div>
                <input type="submit" name="deleteSelectedAds" value="Ištrinti skelbimą" class="btn btn-primary">
            </div>
          </form>';
}


}