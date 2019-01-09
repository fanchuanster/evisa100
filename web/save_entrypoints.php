<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $entrypoint = json_decode($input);
var_dump($entrypoint);
 if ($entrypoint->id) {
	// update it.
	$updatestr = "update entrypoint set ".
	"country='".$entrypoint->country."'".
	"data='".addslashes($entrypoint->data)."'".
	" WHERE id='".$entrypoint->id."'";

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into entrypoint(country, data) ".
	"values('".$entrypoint->country."','".
	addslashes($entrypoint->data)."')";
	
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	print('{"id":'.$mysqli->insert_id.'}');
 }

?>
