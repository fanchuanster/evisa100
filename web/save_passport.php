<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 //$mysqli->query("set NAMES 'utf8'");
 //$mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $passport = json_decode($input);
 $data = json_encode($passport->data);

 if ($passport->id) {
	// update it.
	$updatestr = "update passport set ".
	"passport_no='".$passport->passport_no."',".
	"openid='".$passport->openid."',".
	"data='".$data."'".
	" WHERE id='".$passport->id."'";

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into passport(passport_no, openid, data) ".
	"values('".$passport->passport_no."','".
	$passport->openid."','".
	$data."')";
         
    var_dump($insertStr);
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	print('{"id":'.$mysqli->insert_id.'}'); 
 }

?>
