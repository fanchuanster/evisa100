<?php

	$appid = 'wx18e03ddea0cde133';
	$secret = '7284f8c5142288f86c77ea016a9bf2b3';
	$js_code = $_GET['js_code'];
	$request = "https://api.weixin.qq.com/sns/jscode2session?appid=".$appid."&secret=".$secret."&js_code=".$js_code."&grant_type=authorization_code";
	
	$weixin =  file_get_contents($request);
	
	$jsondecode = json_decode($weixin);
	
	$array = get_object_vars($jsondecode);
	
	print($array['openid']);

?>