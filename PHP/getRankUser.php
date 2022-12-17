<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "winterdev_backend";

//variables submited by user

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM users  WHERE exp = (SELECT max(exp) FROM users) ";

$result = $conn->query($sql);
if ($result->num_rows > 0) {
  while($row = $result->fetch_assoc()) {
    echo $row["username"];
  }
} else {

}


?>