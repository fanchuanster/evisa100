<?php

	$appid = $_GET['appid'];
	$appsecret = $_GET['appsecret'];
	$code = $_GET['code'];
	$request = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=".$appid."&appsecret=".$appsecret."&code=".$code."&grant_type=authorization_code";
	var_dump($request);
	$weixin =  file_get_contents($request);
	var_dump($weixin);
	$jsondecode = json_decode($weixin);
	var_dump($jsondecode);
	$array = get_object_vars($jsondecode);
	var_dump($array);
	return $array['openid'];
	
?>
