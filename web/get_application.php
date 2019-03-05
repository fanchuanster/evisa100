<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
  
  // $owner = $_GET['owner'];
 
  $querystr = "SELECT 'id', id, 'passport_id', passport_id,'to_country', to_country, 'purpose', purpose, 'entry_date', entry_date, 'departure_date', departure_date, 'data', data".
			" FROM application";
	
  $condition = '';
  if (isset($_get['status'])) {
	  $condition .= 'current_status=' . $_get['status'];
  }
  if (isset($_GET['count'])) {
	  if ($condition != '') {
		$condition .= ' AND';
	  }
	  $condition .= ' LIMIT ' . $_GET['count'];
  }
  if ($condition != '') {
	  $querystr .= ' WHERE ' . $condition;
  }
  var_dump($querystr);
    
  // $result = $mysqli->query($querystr);
  
  // $records = array();
  // while ($row = $result->fetch_assoc()) {
	  // $records[] = $row;
  // }

  // print((json_encode($records)));
?>
