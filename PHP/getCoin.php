<?php
$servername = "localhost";
$username = "root";
$coin = "";
$exp = "";
$dbname = "winterdev_backend";

//variables submited by user

$loginUser = $_POST["loginUser"];
$loginCoin = $_POST["loginCoin"];
$loginExp = $_POST["loginExp"];

// Create connection
$conn = new mysqli($servername, $username, $coin, $exp, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM users WHERE username = '". $loginUser. "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {  

    $sql2 = "UPDATE  users SET coin, exp = coin +'". $loginCoin. "', exp +'". $loginExp. "' ";
    if ($conn->query($sql2) === TRUE) {
    } else {
      echo "Error: " . $sql2 . "<br>" . $conn->error;
    }
    


} else {
  //insert user in database

}
$conn->close();
?>