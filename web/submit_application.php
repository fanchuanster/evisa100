<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $application = json_decode($input);
 $data = json_encode($application->data);
 
 // $data = str_replace("\u", "\\u", $data);
 
 if ($application->id) {
	// update it.
	$updatestr = "update application set ".
	"passport_id=".$application->passport_id.",".
	"status=".$application->status.",".
	"entry_date=CAST('".$application->entry_date."' AS DATE),".
	"departure_date=CAST('".$application->departure_date."' AS DATE),".
	"data='".addslashes($data)."'".
	" WHERE id=".$application->id;

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into application(passport_id, entry_date, departure_date, data) ".
	"values(".$application->passport_id.",".
	"CAST('".$application->entry_date."' AS DATE),".
	"CAST('".$application->departure_date."' AS DATE),'".
	addslashes($data)."')";
	
	// var_dump($insertStr);
	
	$mysqli->query($insertStr);

	print('{"id":'.$mysqli->insert_id.'}');
 }
?>
