<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
  
  // $owner = $_GET['owner'];
 
  $querystr = "SELECT 'id', id, 'passport_id', passport_id, 'status', status, 'to_country', to_country, 'purpose', purpose, 'entry_date', entry_date, 'departure_date', departure_date, 'data', data".
			" FROM application";
  
  $condition = '';
  if (isset($_GET['id'])) {
	  $condition .= 'id=' . $_GET['id'];
  }
  if (isset($_GET['status'])) {
	  $condition .= 'status=' . $_GET['status'];
  }
  
  // for my openid, gets all.
  if (isset($_GET['openid']) && $_GET['openid'] != 'opini5GNX-N6JKq6aqutfPHCxUDc') {
	  $condition .= 'openid=' . $_GET['openid'];
  }
  if (!empty($condition)) {
    $querystr .= ' WHERE ' . $condition;
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
