<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "winterdev_backend";

//variables submited by user

$loginUser = $_POST["loginUser"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM users WHERE username = '". $loginUser. "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {  
  $sql2 = "UPDATE  users SET CPower = CPower + 1  WHERE username = '". $loginUser. "'";
  if ($conn->query($sql2) === TRUE) {
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }

} else {
  //insert user in database

}
$conn->close();
?>