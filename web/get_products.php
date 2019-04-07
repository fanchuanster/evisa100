<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
   
  $querystr = "SELECT 'id', product.id, 'store_id', store_id, 'country_id', country_id, 'status', status, 'data', data"
  ." 'name', name, 'name_cn', name_cn, 'name_short', name_short, continent, continent"
  ." FROM product INNER JOIN country on country.id=product.id";
  
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
  if (isset($_GET['size'])) {
	  $querystr .= ' LIMIT ' . $_GET['size'];
  }
  
  // var_dump($querystr);
    
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }

  print((json_encode($records)));
?>
