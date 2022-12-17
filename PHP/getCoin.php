<?php
$servername = "localhost";
$username = "root";
$coin = "";
$dbname = "winterdev_backend";

//variables submited by user

$loginUser = $_POST["loginUser"];
$loginCoin = $_POST["loginCoin"];
$loginExp = $_POST["loginExp"];

// Create connection
$conn = new mysqli($servername, $username, $coin, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql2 = "UPDATE  users SET coin = coin + $loginCoin  WHERE username = '". $loginUser. "'";
if ($conn->query($sql2) === TRUE) {
} else {
  echo "Error: " . $sql2 . "<br>" . $conn->error;
}

$sql3 = "UPDATE  users SET exp = exp + $loginExp  WHERE username = '". $loginUser. "'";
if ($conn->query($sql3) === TRUE) {
} else {
  echo "Error: " . $sql3 . "<br>" . $conn->error;
}

$conn->close();
?>