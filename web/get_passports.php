<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  //$mysqli->query("set NAMES 'utf8'");
  //$mysqli->query("SET CHARACTER SET utf8");
 
  $querystr = "SELECT 'passport_no', passport_no, 'openid', openid, 'data', data from passport ".
			"WHERE ";
  if (isset($_GET['id'])) {
	  $querystr .= "id=".$_GET['id'];
  } else if (isset($_GET['passport_no'])) {
	  $querystr .= "passport_no='".$_GET['passport_no']."'";
  } else if (isset($_GET['openid'])) {
	  $querystr .= "openid='".$_GET['openid']."'";
  }
  
  var_dump($querystr);
  
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $mysqli->fetch_assoc($result)) {
	  $records[] = $row;
  }

  print(json_encode($records)); 

?>
