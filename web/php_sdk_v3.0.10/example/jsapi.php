<?php 
/**
*
* example目录下为简单的支付样例，仅能用于搭建快速体验微信支付使用
* 样例的作用仅限于指导如何使用sdk，在安全上面仅做了简单处理， 复制使用样例代码时请慎重
* 请勿直接直接使用样例对外提供服务
* 
**/
require_once "../lib/WxPay.Api.php";
require_once "WxPay.JsApiPay.php";
require_once "WxPay.Config.php";
require_once 'log.php';

//初始化日志
$logHandler= new CLogFileHandler("../logs/".date('Y-m-d').'.log');
$log = Log::Init($logHandler, 15);

//①、获取用户openid
try{

	$tools = new JsApiPay();
	$openId = $tools->GetOpenid();

	//②、统一下单
	$input = new WxPayUnifiedOrder();
	$input->SetBody("test");
	$input->SetAttach("test");
	$input->SetOut_trade_no("sdkphp".date("YmdHis"));
	$input->SetTotal_fee("1");
	$input->SetTime_start(date("YmdHis"));
	$input->SetGoods_tag("test");
	$input->SetNotify_url("https://php.evisa100.com/other/test/example/notify.php");
	$input->SetTrade_type("JSAPI");
	$input->SetOpenid($openId);
	$config = new WxPayConfig();
	$order = WxPayApi::unifiedOrder($config, $input);

	
	$results = new WxPayResults();
	$results->SetData('appId', $order['appid']);
	$results->SetData('timeStamp', date("YmdHis"));
	$results->SetData('nonceStr', $order['nonce_str']);
	$results->SetData('package', 'prepay_id='.$order['prepay_id']);
	$results->SetData('signType', $config->GetSignType());
	$paySign = $results->MakeSign($config, false);
	$results->SetData('paySign', $paySign);
	print(json_encode($results->GetValues()));
	

	//获取共享收货地址js函数参数
	$editAddress = $tools->GetEditAddressParameters();
} catch(Exception $e) {
	Log::ERROR(json_encode($e));
}
