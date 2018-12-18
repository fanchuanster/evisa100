<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 var_dump($input);
 
 $data = json_decode($input);
 
 $savepassportstr = "insert into passport(passport_no, name, name_cn, sex,birth_date,birth_place,birth_place_raw,country,type,authority, issue_date, issue_place,issue_place_raw,expiry_date) ".
"values('".$data->passport_no."','".
$data->name."','".
$data->name_cn."','".
$data->sex."',".
"CAST('".$data->birth_date."' AS DATE)".",'".
$data->birth_place."','".
$data->birth_place_raw."','".
$data->country."','".
$data->type."','".
$data->authority."',".
"CAST('".$data->issue_date."' AS DATE)".",'".
$data->issue_place."','".
$data->issue_place_raw."',".
"CAST('".$data->expiry_date."' AS DATE))";
  print($savepassportstr);

  // $mysqli->query($savePassportStr);

?>
