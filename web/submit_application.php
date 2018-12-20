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
	"entry_date=CAST('".$data->entry_date."' AS DATE),".
	"exit_date=CAST('".$data->exit_date."' AS DATE),".
	"other_info='".$other_info."'".
	" WHERE id='".$data->id."'";
        
	// var_dump($updatestr);

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into application(passport_id, to_country, visa_type, entry_date, exit_date, other_info) ".
	"values(".$data->passport_id.",'".
	$data->to_country."','".
	$data->visa_type."',".
	"CAST('".$data->entry_date."' AS DATE),".
	"CAST('".$data->exit_date."' AS DATE),'".
	$other_info."')";
         
    // var_dump($insertStr);
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	$lastId = '';
	if ($mysqli->insert_id) {
		$lastId = $mysqli->insert_id;
	}
	print('{"data":'.$lastId.'}'); 
 }

?>
