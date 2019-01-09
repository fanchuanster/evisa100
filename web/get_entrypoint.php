<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
 
  $querystr = "SELECT 'id', id, 'country', country, 'data', data from entrypoint ".
			"WHERE ";
  if (isset($_GET['id'])) {
	  $querystr .= "id=".$_GET['id'];
  } else if (isset($_GET['country'])) {
	  $querystr .= "country='".$_GET['country']."'";
  }
  
  //var_dump($querystr);
  
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }

  print((json_encode($records)));
?>
