<?php

	$servername = "localhost";
	$username= "root";
	$passwd= "";
	$dbname = "universityprojectthesis";

	$studentName = isset($_POST["name"] ) ? $_POST["name"]: '';
	$studentSurname = isset($_POST["surname"] ) ? $_POST["surname"]: '';
	$studentSubject = isset($_POST["subject"] ) ? $_POST["subject"]: '';
	$studentGrade = isset($_POST["grade"] ) ? $_POST["grade"]: '';

	$conn = new mysqli($servername, $username, $passwd, $dbname);

	echo $studentName;
	echo $studentSurname;
	echo $studentSubject;
	echo $studentGrade;

	if($conn->connect_error){
		die("Connection failed: ".$conn->connect_error);
	}

	$sql = "INSERT INTO studentsgrades (Name, Surname, Subject, Grade) VALUES ('".$studentName."', '".$studentSurname."', '".$studentSubject."', '".$studentGrade."')";
	$result = $conn->query($sql);

	$conn->close();

?>