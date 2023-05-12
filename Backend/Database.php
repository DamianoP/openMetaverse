<?php

	$servername = "localhost";
	$username= "root";
	$passwd= "";
	$dbname = "universityprojectthesis";

	$userLogin = isset($_POST["userLogin"] ) ? $_POST["userLogin"]: '';
	$passwdLogin = isset($_POST["passwdLogin"] ) ? $_POST["passwdLogin"]: '';

	$conn = new mysqli($servername, $username, $passwd, $dbname);

	if($conn->connect_error){
		die("Connection failed: ".$conn->connect_error);
	}

	$sql = "SELECT Password, IsEducator FROM users WHERE Username = '" .$userLogin. "'";
	$result = $conn->query($sql);

	if($result->num_rows > 0){
		while($row = $result->fetch_assoc()){

			if($row["Password"] == $passwdLogin){

				if($row["IsEducator"] == true){
					echo "1";
				}
				else if($row["IsEducator"] == false){
					echo "0";
				}

			}
			else{
				echo "Wrong Password";
			}
		}
	}
	else{
		echo "Username does not exist";
	}

	$conn->close();

?>