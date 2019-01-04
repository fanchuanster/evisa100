<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 
 $input = file_get_contents("php://input");
 $travelInfo = json_decode($input);

 if ($travelInfo->id) {
	// update it.
	$updatestr = "update application set ".
	"passport_id=".$travelInfo->passport_id.",".
	"to_country='".$travelInfo->to_country."',".
	"purpose='".$travelInfo->purpose."',".
	"entry_date=CAST('".$travelInfo->entry_date."' AS DATE),".
	"departure_date=CAST('".$travelInfo->departure_date."' AS DATE)".
	" WHERE id='".$travelInfo->id."'";
        
	var_dump($updatestr);

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into application(passport_id, to_country, purpose, entry_date, departure_date) ".
	"values(".$travelInfo->passport_id.",'".
	$travelInfo->to_country."','".
	$travelInfo->purpose."',".
	"CAST('".$travelInfo->entry_date."' AS DATE),".
	"CAST('".$travelInfo->departure_date."' AS DATE))";
         
    var_dump($insertStr);
	$mysqli->query($insertStr);

	print('{"id":'.$mysqli->insert_id;.'}'); 
 }

?>
