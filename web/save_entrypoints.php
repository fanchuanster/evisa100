<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $entrypoint = json_decode($input);

 if ($entrypoint->id) {
	// update it.
	$updatestr = "update entrypoint set ".
	"country='".$entrypoint->country."'".
	"data='".addslashes(json_encode($entrypoint->data))."'".
	" WHERE id='".$entrypoint->id."'";

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into entrypoint(country, data) ".
	"values('".$entrypoint->country."','".
	addslashes(json_encode($entrypoint->data))."')";
	
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	print('{"id":'.$mysqli->insert_id.'}');
 }

?>
