<?php

class DatabaseConnection {
    private static $instance;
    private $connection;

    private function __construct() {
        // Datele de conexiune preluate din codul existent
        $db_host = "localhost"; // Adresa serverului de bază de date (localhost în cazul tău)
        $db_port = "1521"; // Portul pe care rulează serverul de bază de date
        $db_service_name = "orcl"; // Numele serviciului sau SID-ul bazei de date
        $db_username = "system"; // Numele de utilizator pentru conexiune
        $db_password = "Nirolf918"; // Parola pentru conexiune

        // Conectare la baza de date Oracle
        $conn = oci_connect($db_username, $db_password, "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=$db_host)(PORT=$db_port))(CONNECT_DATA=(SERVICE_NAME=$db_service_name)))");

        // Verificare conexiune
        if ($conn) {
            $this->connection = $conn;
        } else {
            $e = oci_error();
            throw new Exception("Eroare la conectarea la baza de date: " . $e['message']);
        }
    }

    public static function getInstance() {
        if (self::$instance === null) {
            self::$instance = new self();
        }
        return self::$instance;
    }

    public function getConnection() {
        return $this->connection;
    }
}

// Testarea conexiunii la baza de date
try {
    $dbConnection = DatabaseConnection::getInstance();
    echo "Conexiunea la baza de date a fost realizată cu succes.";
} catch (Exception $e) {
    echo $e->getMessage();
}

?>
