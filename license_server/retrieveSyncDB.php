<?php
    ob_start();
    include 'include.php';
    ob_end_clean();

    $link = mysqli_connect($host, $mysqluser, $mysqlpassword, $mysqldatabasename);

    // Подготовка запроса
    $sql = "SELECT db_text FROM delta_db ORDER BY time_stamp DESC LIMIT 1";
    $stmt = $link->prepare($sql);

    // Запрос данных
    $stmt->execute();

    $result = $stmt->get_result();

    // Вывод данных
    if($row = $result->fetch_assoc()) {
        echo $row['db_text'];
    }
?>
