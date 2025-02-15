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
		
		$mytime = mktime(date("H"), 0, 0, date("m"), date("d"), date("Y"));
		$mydate = date("Y-m-d H:i:s", $mytime);
		
		$query = mysqli_query($link, "SELECT count FROM chart WHERE timecode='".$mydate."' LIMIT 1");
		$data = mysqli_fetch_assoc($query);
		if (mysqli_num_rows($query) > 0)
		{
			$count = $data['count'];
			$query = mysqli_query($link, "UPDATE chart SET `count`='".strval(intval($count)+intval($obj['good']))."' WHERE `timecode`='".$mydate."'");
			$data = mysqli_fetch_assoc($query);
		} else 
		{
			$query = mysqli_query($link, "INSERT INTO `chart` (`timecode`, `count`) VALUES ('".$mydate."', '".$obj['good']."');");
			$data = mysqli_fetch_assoc($query);
		}
		
		$query = mysqli_query($link, "DELETE FROM `chart` WHERE timecode < SUBDATE(NOW(),1);");
		$data = mysqli_fetch_assoc($query);
		
		$res = "";
		for ($i = 23; $i >= 0; $i--) 
		{
			$query = mysqli_query($link, "SELECT count FROM chart WHERE timecode='".date("Y-m-d H:i:s", strtotime('-'.strval($i).' hours', $mytime))."' LIMIT 1");
			$data = mysqli_fetch_assoc($query);
			if (mysqli_num_rows($query) > 0)
			{
				$res .= ($i+1).' ч,'.$data['count'].','.GetColor($data['count'])."\n";
			} else $res .= ($i+1).' ч,0,'.GetColor('0')."\n";
		}
		file_put_contents("ifr.csv", $res);
		
		$res = "";
		for ($i = 0; $i < strlen($answer); $i++)
        {
            $k = new Math_BigInteger(ord($answer[$i]));

            $k = $k->multiply(fun($p, $A, $b));
			list($quotient, $rem) = $k->divide($p);
			$k = $rem;
			
            $res .= ($k->toString()).".";
        }

		file_put_contents('RegistrarStats.html', MEncrypt(date('Y.m.d,  H:i:s').'<br><b>'.$_SERVER['REMOTE_ADDR'].'</b><br>'.$obj['id'].'<hr><br>'.$obj['good'].'<hr><br>'), FILE_APPEND);
		echo MEncrypt($res);
	} 
}
session_unset();
session_destroy();

function GetColor($x)
{
	$g = intval($x);
	if ($g <= 4000) return '#051da1'; else 
	if ($g <= 8000) return '#111b97'; else 
	if ($g <= 12000) return '#141a94'; else 
	if ($g <= 16000) return '#1c198e'; else 
	if ($g <= 20000) return '#20198a'; else 
	if ($g <= 24000) return '#21188a'; else 
	if ($g <= 28000) return '#251886'; else 
	if ($g <= 32000) return '#281783'; else 
	if ($g <= 36000) return '#2b1681'; else 
	if ($g <= 40000) return '#2d1680'; else 
	if ($g <= 44000) return '#2f167e'; else 
	if ($g <= 48000) return '#3b1474'; else 
	if ($g <= 52000) return '#3e1372'; else 
	if ($g <= 56000) return '#401370'; else 
	if ($g <= 60000) return '#4c1166'; else 
	if ($g <= 64000) return '#501063'; else 
	if ($g <= 68000) return '#531061'; else 
	if ($g <= 72000) return '#570f5d'; else 
	if ($g <= 76000) return '#5b0e59'; else 
	if ($g <= 80000) return '#5e0e57'; else 
	if ($g <= 84000) return '#620d54'; else 
	if ($g <= 88000) return '#6d0b4b'; else 
	if ($g <= 92000) return '#710b48'; else 
	if ($g <= 96000) return '#7f083c'; else 
	if ($g <= 100000) return '#830738'; else return '#9a0326';
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