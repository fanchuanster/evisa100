<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
  
  // $owner = $_GET['owner'];
 
  $querystr = "SELECT 'id', id, 'store_id', store_id, 'country_id', country_id, 'status', status, 'data', data"
  ." FROM product";
  
  $condition = '';
  if (isset($_GET['id'])) {
	  $condition .= 'id=' . $_GET['id'];
  }
  if (isset($_GET['status'])) {
	  if (!empty($condition)) {
		  $condition .= ' AND';
	  }
	  $condition .= ' status&' . $_GET['status'] . '>0';
  }
  
  // for my openid, gets all.
  if (isset($_GET['store_id'])) {
	  if (!empty($condition)) {
		  $condition .= ' AND';
	  }
	  $condition .= " store_id='" . $_GET['store_id'] . "'";
  }
  if (!empty($condition)) {
    $querystr .= ' WHERE ' . $condition;
  }
  if (isset($_GET['count'])) {
	  $querystr .= ' LIMIT ' . $_GET['count'];
  }
  
  // var_dump($querystr);
    
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }

  print((json_encode($records)));
?>
