<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
  
  // $owner = $_GET['owner'];
 
  $querystr = "SELECT 'id', id, 'passport_id', passport_id,'to_country', to_country, 'purpose', purpose, 'entry_date', entry_date, 'departure_date', departure_date, 'data', data".
			" FROM application";

  if (isset($_GET['id'])) {
	  $querystr .= ' WHERE id=' . $_GET['id'];
  }
  else if (isset($_GET['status'])) {
	  $querystr .= ' WHERE current_status=' . $_GET['status'];
  }
  if (isset($_GET['count'])) {
	  $querystr .= ' LIMIT ' . $_GET['count'];
  }
    
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }

  print((json_encode($records)));
?>
