<?php
error_reporting(0);
date_default_timezone_set('Europe/Minsk');
mb_internal_encoding("UTF-8");
#mysql_set_charset('utf8');

ob_start();
include 'include.php';
include 'MCrypt.php';
ob_end_clean();
	
if (isset($_GET['q'])) 
{
    $id = MDecrypt(MDecrypt($_GET['q']));
	
	$link = mysqli_connect($host, $mysqluser, $mysqlpassword, $mysqldatabasename);
	$query = mysqli_query($link, "SELECT expired FROM licenses WHERE id='".$id."' LIMIT 1");
	$data = mysqli_fetch_assoc($query);
	
	if (mysqli_num_rows($query) > 0)
	{
		if (time() >= strtotime($data['expired'])) MyEXIT();
		$answer = $data['expired'];

		echo MEncrypt(MEncrypt($answer));
	} 
}

function MyEXIT()
{
	$chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_";
	$size = strlen($chars);
	$str = "";
	for($i = 0; $i < 923; $i++) 
	{  
		$str .= $chars[rand(0, $size-1)];  
	}  
	session_unset();
	session_destroy();
	echo MEncrypt($str);
	exit;
}

exit;
?>