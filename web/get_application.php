<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
 
  $querystr = "SELECT 'id', id, 'passport_id', passport_id,'to_country', to_country, 'entry_date', entry_date, 'departure_date', departure_date, 'other_info', other_info".
			" FROM application".
			" WHERE current_status=0 LIMIT 1";
    
  var_dump($querystr);
  // $result = $mysqli->query($querystr);
  
  // $row = $result->fetch_assoc();

  // print(json_encode($row)); 
?>
