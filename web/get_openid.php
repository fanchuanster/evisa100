<?php

	$appid = $_GET['appid'];
	$secret = $_GET['secret'];
	$js_code = $_GET['js_code'];
	$request = "https://api.weixin.qq.com/sns/jscode2session?appid=".$appid."&secret=".$secret."&js_code=".$js_code."&grant_type=authorization_code";
	var_dump($request);
	$weixin =  file_get_contents($request);
	
	$jsondecode = json_decode($weixin);
	
	$array = get_object_vars($jsondecode);
	return $array['openid'];
	
?>
