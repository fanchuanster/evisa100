<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
  
  // $owner = $_GET['owner'];
 
  $querystr = "SELECT 'id', application.id, 'passport_id', passport_id, 'status', status, 'entry_date', entry_date, 'departure_date', departure_date, 'data', application.data"
  .", 'passport_no', passport_no, 'name', name, 'name_cn', name_cn, 'last_updated', application.last_updated"
  ." FROM application INNER JOIN passport ON application.passport_id=passport.id";
  
  $condition = '';
  if (isset($_GET['id'])) {
	  $condition .= 'application.id=' . $_GET['id'];
  }
  if (isset($_GET['status']) && !!$_GET['status']) {
	  if (!empty($condition)) {
		  $condition .= ' AND';
	  }
	  $condition .= ' status&' . $_GET['status'] . '>0';
  }
  
  // for my openid, gets all.
  if (isset($_GET['openid']) && !!$_GET['openid']) {
	  if (!empty($condition)) {
		  $condition .= ' AND';
	  }
	  $condition .= " openid='" . $_GET['openid'] . "'";
  }
  if (!empty($condition)) {
    $querystr .= ' WHERE ' . $condition;
  }
  if (isset($_GET['size'])) {
	  $querystr .= ' LIMIT ' . $_GET['size'];
  }
  
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }
  
  print((json_encode($records)));
?>
