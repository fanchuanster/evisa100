<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 
 $json = json_decode($input);
  
 if ($json->id) {
	// update it.
	$updatestr = "update application set ".
	"status=".$json->status." ".
	" WHERE id=".$json->id;

	$mysqli->query($updatestr);
    
    print('{"affected_rows":'.$mysqli->affected_rows.'}');
 }
?>
