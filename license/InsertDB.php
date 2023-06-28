<?php
include 'MCrypt.php';
include 'include.php';

if (isset($_POST['secretphrase']))
{
	$pass = "facebook_new_db";
	if ($_POST['secretphrase'] == $pass && isset($_POST['id']) && isset($_POST['date']))
	{
		$link = mysqli_connect($host, $mysqluser, $mysqlpassword, $mysqldatabasename);
		$query1 = mysqli_query($link, "DELETE FROM `licenses` WHERE id='".$_POST['id']."'");
		$query2 = mysqli_query($link, "INSERT INTO `licenses` (`id`, `expired`) VALUES ('".$_POST['id']."', '".$_POST['date']."');");
		
		echo '<script>alert("Success")</script>';
		header("Refresh: 0");
	} else form();
} else form();

function form()
{
	echo '<form action="" method="post"><input name="secretphrase" type="password"/>';
	echo '   <p>
		  <input name="id" value="E5D8C78792D98C355475"/>
		  <input name="date" value="2020-07-31 12:00:00.000000"/>
		     </p>
		  <p><input type="submit" /></p>
		  </form>';
}
?>