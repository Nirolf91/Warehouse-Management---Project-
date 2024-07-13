<?php
// Datele de conexiune
$db_host = "localhost"; // Adresa serverului de bază de date
$db_port = "1521"; // Portul pe care rulează serverul de bază de date
$db_service_name = "orcl"; // Numele serviciului sau SID-ul bazei de date
$db_username = "system"; // Numele de utilizator pentru conexiune
$db_password = "Nirolf918"; // Parola pentru conexiune

// Conectare la baza de date
$conn = oci_connect($db_username, $db_password, "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=$db_host)(PORT=$db_port))(CONNECT_DATA=(SERVICE_NAME=$db_service_name)))");

// Verificare conexiune
if (!$conn) {
    $e = oci_error();
    echo "Eroare la conectarea la baza de date: " . htmlentities($e['message'], ENT_QUOTES);
    exit;
}
?>
