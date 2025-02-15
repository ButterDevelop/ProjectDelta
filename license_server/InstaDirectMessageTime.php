<?php
error_reporting(-1);
date_default_timezone_set('Europe/Minsk');
mb_internal_encoding("UTF-8");
#mysql_set_charset('utf8');

ob_start();
include 'MCrypt.php';
include('BigInteger.php');
ob_end_clean();

if (isset($_GET['q'])) 
{
	session_start();
    $q = MDecrypt($_GET['q']);
	if (strrev($q) == $_SESSION['q']) echo MEncrypt(date("d.m.Y H:i:s", time()));
	session_unset();
	session_destroy();
} else 
{
	session_start();
	$_SESSION['q'] = strrev(RandStr());
	echo strrev(MEncrypt($_SESSION['q']));
}

function RandStr()
{
	$chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
	$size = strlen($chars);
	$str = "";
	$len = rand(3, 10);
	for($i = 0; $i < $len; $i++) 
	{  
		$str .= $chars[rand(0, $size-1)];  
	}  
	return $str;
}
exit;
?>