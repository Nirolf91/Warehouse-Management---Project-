<?php
// Activare afișare erori
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Conectează-te la baza de date și includi fișierul config.php
require 'config.php';

// Verifică dacă parametrul table este setat în URL
if(isset($_GET['table'])) {
    $table = $_GET['table'];

    // În funcție de tabel, selectează datele din baza de date
    switch ($table) {
        case 'angajati':
            $sql = "SELECT * FROM Angajati";
            break;
        case 'clienti':
            $sql = "SELECT * FROM Clienti";
            break;
        case 'comenzi':
            $sql = "SELECT * FROM Comenzi";
            break;
        case 'furnizori':
            $sql = "SELECT * FROM Furnizori";
            break;
        case 'evaluari':
            $sql = "SELECT * FROM Evaluari";
            break;
        case 'transportatori':
            $sql = "SELECT * FROM Transportatori";
            break;
        default:
            // Dacă nu este specificat un tabel corect, oprește scriptul
            die("Tabelul specificat nu există sau este incorect.");
    }

    // Execută interogarea
    $stid = oci_parse($conn, $sql);
    oci_execute($stid);

    // Directorul pentru exporturi
    $exportsDir = 'exports/';

    // Verifică dacă directorul exports există, altfel îl creează
    if (!is_dir($exportsDir)) {
        mkdir($exportsDir, 0777, true); // 0777 reprezintă permisiunile
    }

    // Deschide un fișier pentru scriere
    $filename = $table . '_export.csv';
    $fp = fopen($exportsDir . $filename, 'w');

    // Verifică dacă fișierul a fost deschis cu succes
    if (!$fp) {
        die("Eroare la deschiderea fișierului pentru scriere.");
    }

    // Scrie antetul
    $header = array();
    for ($i = 1; $i <= oci_num_fields($stid); $i++) {
        $header[] = oci_field_name($stid, $i);
    }
    fputcsv($fp, $header);

    // Scrie datele
    while (($row = oci_fetch_assoc($stid)) != false) {
        fputcsv($fp, $row);
    }

    // Închide fișierul
    fclose($fp);

    // Redirectează utilizatorul către fișierul exportat
    header('Location: ' . $exportsDir . $filename);
    exit();
} else {
    // Dacă nu este specificat un tabel, oprește scriptul
    die("Tabelul nu a fost specificat.");
}
?>
