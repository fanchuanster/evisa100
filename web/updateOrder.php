<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 
 print($input);
 print('updateOrder triggered');
 
 $json = json_decode($input);
 
 // $data = str_replace("\u", "\\u", $data);
 
 if ($json->id) {
	// update it.
	$updatestr = "update application set ".
	"status=".$json->status." ".
	" WHERE id=".$json->id;
        
	var_dump($updatestr);

	$mysqli->query($updatestr);
 }
?>
