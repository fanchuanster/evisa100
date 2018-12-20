<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  //$mysqli->query("set NAMES 'utf8'");
  //$mysqli->query("SET CHARACTER SET utf8");
 
  $querystr = "SELECT 'passport_id', passport_id,'to_country' to_country, 'visa_type', visa_type, 'entry_date', entry_date, 'exit_date', exit_date,'other_info',other_info,
  'passport_no', passport_no, 'openid', openid, 'data', data from application, passport ".
			"WHERE passport.id=passport_id and current_status=0 LIMIT 1";
  
  // var_dump($querystr);
  
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }

  print('{"data":'.json_encode($records).'}'); 

?>
