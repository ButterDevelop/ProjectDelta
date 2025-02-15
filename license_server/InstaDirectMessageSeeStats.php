<?php
include 'MCrypt.php';

if (isset($_POST['secretphrase']))
{
	$pass = "facebook_new_stats";
	if ($_POST['secretphrase'] == $pass)
	{
		echo MDecrypt(file_get_contents('./InstaDirectMessageStats.html'));
	} else form();
} else form();

function form()
{
	echo '<form action="" method="post"><input name="secretphrase" type="password"/><p><input type="submit" /></p></form>';
}
?>