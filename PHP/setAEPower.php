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

$sql2 = "UPDATE  users SET AEPower = AEPower + 1  WHERE username = '". $loginUser. "'";
if ($conn->query($sql2) === TRUE) {
} else {
  echo "Error: " . $sql2 . "<br>" . $conn->error;
}

$conn->close();
?>