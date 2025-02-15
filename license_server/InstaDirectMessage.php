<?php
error_reporting(-1);
date_default_timezone_set('Europe/Minsk');
mb_internal_encoding("UTF-8");
#mysql_set_charset('utf8');

ob_start();
include 'include.php';
include 'MCrypt.php';
include('BigInteger.php');
ob_end_clean();
session_start();

if (!isset($_SESSION['time'])) MyEXIT();
if (!((strtotime($_SESSION['time']) > strtotime("now -15 seconds")) and (strtotime($_SESSION['time']) <= time()))) MyEXIT();
	
if (isset($_GET['q'])) 
{
    $q = MDecrypt($_GET['q']);
	$res = "";
	
	$p = $_SESSION['p'];
	$A = $_SESSION['A'];
	$b = $_SESSION['b'];
	
	$arr = array_filter(explode(".", $q));
	$res = "";
    foreach ($arr as &$value)
    {
		$k = new Math_BigInteger($value);
		
        $k = $k->multiply(fun($p, $A, ($p->subtract((new Math_BigInteger('1'))->add($b)))));
		list($quotient, $rem) = $k->divide($p);
		$k = $rem;
        $res .= chr(intval($k->toString()));
    }
	
	$obj = json_decode($res, true);

	if (!((strtotime($obj['time']) > strtotime("now -20 seconds")) and (strtotime($obj['time']) <= time()))) MyEXIT();
	
	$link = mysqli_connect($host, $mysqluser, $mysqlpassword, $mysqldatabasename);
	$query = mysqli_query($link, "SELECT expired FROM licenses WHERE id='".$obj['id']."' LIMIT 1");
	$data = mysqli_fetch_assoc($query);
	
	if (mysqli_num_rows($query) > 0)
	{
		if (time() >= strtotime($data['expired'])) MyEXIT();
		$salt = MEncrypt(strrev(MEncrypt($obj['salt'])));
		$answer = '{"salt": "'.$salt.'", "result": "OK"}';
		
		$res = "";
		for ($i = 0; $i < strlen($answer); $i++)
        {
            $k = new Math_BigInteger(ord($answer[$i]));

            $k = $k->multiply(fun($p, $A, $b));
			list($quotient, $rem) = $k->divide($p);
			$k = $rem;
			
            $res .= ($k->toString()).".";
        }

		file_put_contents('InstaDirectMessageLog.html', MEncrypt(date('Y.m.d,  H:i:s').'<br><b>'.$_SERVER['REMOTE_ADDR'].'</b><br>'.$obj['id'].'<hr><br>'), FILE_APPEND);
		echo MEncrypt($res);
	} 
}
session_unset();
session_destroy();

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