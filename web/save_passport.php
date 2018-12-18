<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 $savePassportStr = "
insert into passport(passport_no, name, name_cn, sex,birth_date,birth_place,birth_place_raw,country,type,authority, issue_date, issue_place,issue_place_raw,expiry_date) 
values(".$_POST['passport_no'].",".
$_POST['name'].",".
$_POST['name_cn'].",".
$_POST['sex'].",".
"CAST(".$_POST['birth_date']." AS DATE)".",".
$_POST['birth_place'].",".
$_POST['birth_place_raw'].",".
$_POST['country'].",".
$_POST['type'].",".
$_POST['authority'].",".
"CAST(".$_POST['issue_date']." AS DATE)".",".
$_POST['issue_place'].",".
$_POST['issue_place_raw'].",".
"CAST(".$_POST['expiry_date']." AS DATE)");

  $mysqli->query($savePassportStr);

?>
