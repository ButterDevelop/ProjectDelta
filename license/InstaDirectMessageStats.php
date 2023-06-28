<?php
error_reporting(-1);
date_default_timezone_set('Europe/Minsk');
mb_internal_encoding("UTF-8");
#mysql_set_charset('utf8');

ob_start();
include 'MCrypt.php';
ob_end_clean();

if (isset($_GET['q'])) 
{
    $q = MDecrypt($_GET['q']);
    mb_parse_str($q, $result);
	file_put_contents('InstaDirectMessageStats.html', MEncrypt(date('Y.m.d,  H:i:s').';'.$_SERVER['REMOTE_ADDR'].';'.$result['id'].'<br>'.$result['done'].'<hr>'), FILE_APPEND);
} 
exit;
?>