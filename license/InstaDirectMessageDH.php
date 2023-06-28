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
    $q = MDecrypt($_GET['q']);
    mb_parse_str($q, $result);
	$result['time'] = urldecode($result['time']);
	
	if (!((strtotime($result['time']) > strtotime("now -15 seconds")) and (strtotime($result['time']) <= time()))) MyDHExit();
	$p = new Math_BigInteger($result['p']);
	$g = new Math_BigInteger($result['g']);
	$A = new Math_BigInteger($result['A']);
	$b = new Math_BigInteger(rand(1, intval($result['p'])));
	
	$B = fun($p, $g, $b);
	//$k = fun($p, $A, $b);
	session_start();
	$_SESSION['b'] = $b;
	$_SESSION['A'] = $A;
	$_SESSION['p'] = $p;
	$_SESSION['time'] = date("Y-m-d H:i:s");
	echo MEncrypt($B->toString());
}

function fun($p, $a, $b)
{
	$s = new Math_BigInteger('1');
	for ($i = 1; $i <= intval($b->toString()); $i++)
    {
       $s = $s->multiply($a);
	   list($quotient, $rem) = $s->divide($p);
	   $s = $rem;
    }	
	return $s;
}
function MyDHExit()
{
	$chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
	$size = strlen($chars);
	$str = "";
	$len = rand(3, 10);
	for($i = 0; $i < $len; $i++) 
	{  
		$str .= $chars[rand(0, $size-1)];  
	}  
	echo MEncrypt($str);
	session_start();
	session_unset();
	session_destroy();
	exit;
}
exit;
?>