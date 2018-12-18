<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $data = json_decode($input);
 
 // ensure it does not exist.
 $mysqli->query("delete from applicant where passport_no='".$data->passport_no"'");
 
 $saveApplicantInfo = "insert into applicant(openid, passport_no, phone, email, address, occupation, otherinfo) ".
"values('".$data->openid."','".
$data->passport_no."','".
$data->phone."','".
$data->email."','".
$data->address."','".
$data->occupation."','".
$data->otherinfo."',')";

  $mysqli->query($saveApplicantInfo);

?>
