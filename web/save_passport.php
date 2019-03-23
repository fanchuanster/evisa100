<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $passport = json_decode($input); 
 $data = json_encode($passport->data);

 if ($passport->id) {
	// update it.
	$updatestr = "update passport set ".
	"passport_no='" . $passport->passport_no."',".
	"openid='" . $passport->openid."',".
	"name='" . $passport->name."',".
	"name_cn='" . $passport->name_cn."',".
	"data='" . addslashes($data)."'".
	" WHERE id='" . $passport->id."'";

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into passport(passport_no, openid, name, name_cn, data) ".
	"values('".$passport->passport_no."','".
	$passport->openid."','".
	$passport->name."','".
	$passport->name_cn."','".
	addslashes($data)."')";
	
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	print('{"id":'.$mysqli->insert_id.'}');
 }

?>
