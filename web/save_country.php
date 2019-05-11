<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $country = json_decode($input);
 
 // var_dump($data)

	$insertStr = "insert into country(name, name_short, continent, name_cn) ".
	"values('".$country->name."','".$country->name_short."','".$country->continent."','".
	addslashes(json_encode($country->name_cn))."')";
	
	$mysqli->query($insertStr);

?>
