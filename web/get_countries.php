<?php

  $mysqli = new mysqli("localhost", "root", "root", "evisa");
  $mysqli->query("set NAMES 'utf8'");
  $mysqli->query("SET CHARACTER SET utf8");
   
  $querystr = "SELECT 'id', id,"
  ." 'name', name, 'name_cn', name_cn, 'name_short', name_short, continent, continent"
  ." FROM country";
    
  // var_dump($querystr);
    
  $result = $mysqli->query($querystr);
  
  $records = array();
  while ($row = $result->fetch_assoc()) {
	  $records[] = $row;
  }
  

  print(((json_encode($records))));
?>
