<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 //$mysqli->query("set NAMES 'utf8'");
 //$mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $data = json_decode($input);
 $details = json_encode($data->details);

 if ($data->id) {
	// update it.
	$updatestr = "update passport set ".
	"passport_no='".$data->passport_no."',".
	"openid='".$data->openid."',".
	"data='".$details."'".
	" WHERE id='".$data->id."'";
        //var_dump($updatestr);

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into passport(passport_no, openid, data) ".
	"values('".$data->passport_no."','".
	$data->openid."','".
	$details."')";
         
        //var_dump($insertStr);
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	print('{"id":'.$mysqli->insert_id.'}'); 
 }

?>
