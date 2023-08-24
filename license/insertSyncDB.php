<?php
    ob_start();
    include 'include.php';
    ob_end_clean();

    $link = mysqli_connect($host, $mysqluser, $mysqlpassword, $mysqldatabasename);

    // Получение данных из POST запроса
    $db_text = $_POST['db'];

    // Подготовка запроса
    $sql = "INSERT INTO delta_db (db_text, time_stamp, owner) VALUES (?, NOW(), ?)";
    $stmt = $link->prepare($sql);

    // Указание имени владельца
    $owner = $_POST['owner'];

    $stmt->bind_param('ss', $db_text, $owner);

    // Запись данных в таблицу
    $stmt->execute();
	
	echo 'success';
?>
