<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 
 $input = file_get_contents("php://input");
  
 $data = json_decode($input);
 $other_info = json_encode($data->other_info);

 if ($data->id) {
	// update it.
	$updatestr = "update application set ".
	"passport_id=".$data->passport_id.",".
	"to_country='".$data->to_country."',".
	"visa_type='".$data->visa_type."',".
	"entry_date=CAST('".$data->to_country."' AS DATE),".
	"exit_date=CAST('".$data->to_country."' AS DATE),".
	"other_info='".$other_info."'".
	" WHERE id='".$data->id."'";
        
	var_dump($updatestr);

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into application(passport_id, to_country, visa_type, entry_date, exit_date, other_info) ".
	"values(".$data->passport_id.",'".
	$data->to_country."','".
	$data->visa_type."','".
	$data->entry_date."','".
	$data->exit_date."','".
	$other_info."')";
         
    var_dump($insertStr);
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	$lastId = '';
	if ($mysqli->insert_id) {
		$lastId = $mysqli->insert_id;
	}
	print(json_encode(array('id' => $lastId))); 
 }

?>
