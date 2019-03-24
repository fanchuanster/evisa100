<?php

 $mysqli = new mysqli("localhost", "root", "root", "evisa");
 $mysqli->query("set NAMES 'utf8'");
 $mysqli->query("SET CHARACTER SET utf8");
 
 $input = file_get_contents("php://input");
 $product = json_decode($input); 
 $data = json_encode($product->data);

 if ($product->id) {
	// update it.
	$updatestr = "update product set ".
	"status=" . $product->status.",".
	"data='" . addslashes($data)."'".
	" WHERE id='" . $product->id."'";

	$mysqli->query($updatestr);
 } else {
	 // insert it.
	$insertStr = "insert into product(store_id, country_id, status, data) ".
	"values(".$product->store_id.",".
	$product->country_id.",".
	$product->status.",'".
	addslashes($data)."')";
	
	$mysqli->query($insertStr);
	
	// return inserted id to client.
	print('{"id":'.$mysqli->insert_id.'}');
 }

?>
