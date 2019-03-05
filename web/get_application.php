<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
  
  $owner = $_GET['owner'];
  $count = $_GET['count'];
  $status = $_GET['status'];
 
  $querystr = "SELECT 'id', id, 'passport_id', passport_id,'to_country', to_country, 'purpose', purpose, 'entry_date', entry_date, 'departure_date', departure_date, 'data', data".
			" FROM application".
			" WHERE current_status=0 LIMIT 1";
	
  $condition = '';
  if (status) {
	$condition .= ' current_status='.status;
  }
  if (count) {
    $condition .= ' LIMIT '.count;
  }
  if (empty($condition)) {
	$querystr .= " WHERE " . $condition;
  }
  var_dump($querystr);
    
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }

  print((json_encode($records)));
?>
