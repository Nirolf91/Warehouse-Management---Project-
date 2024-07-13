<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultate Cautare Angajati</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<?php
require 'config.php';

function getFilteredEmployees($searchNume, $searchFunctie, $searchDataContact) {
    global $conn; 

    $sql = "SELECT ID_ANGAJAT, NUME, FUNCTIE, DATE_DE_CONTACT FROM angajati WHERE 1=1";

    if ($searchNume) {
        $sql .= " AND NUME LIKE '%' || :searchNume || '%'";
    }
    if ($searchFunctie) {
        $sql .= " AND FUNCTIE LIKE '%' || :searchFunctie || '%'";
    }
    if ($searchDataContact) {
        $sql .= " AND DATE_DE_CONTACT LIKE '%' || :searchDataContact || '%'";
    }

    $stid = oci_parse($conn, $sql);
    
    if ($searchNume) {
        oci_bind_by_name($stid, ":searchNume", $searchNume);
    }
    if ($searchFunctie) {
        oci_bind_by_name($stid, ":searchFunctie", $searchFunctie);
    }
    if ($searchDataContact) {
        oci_bind_by_name($stid, ":searchDataContact", $searchDataContact);
    }
    
    oci_execute($stid);

    return $stid; 
}

if(isset($_GET['nume']) || isset($_GET['functie']) || isset($_GET['data_contact'])) {
    $searchNume = isset($_GET['nume']) ? $_GET['nume'] : '';
    $searchFunctie = isset($_GET['functie']) ? $_GET['functie'] : '';
    $searchDataContact = isset($_GET['data_contact']) ? $_GET['data_contact'] : '';

    $filteredEmployees = getFilteredEmployees($searchNume, $searchFunctie, $searchDataContact);

    echo "<h3>Rezultate Căutare Angajați</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table' border='1'>";
    echo "<tr><th>ID Angajat</th><th>Nume</th><th>Funcție</th><th>Data de Contact</th></tr>";

    while (($row = oci_fetch_assoc($filteredEmployees)) != false) {
        echo "<tr>";
        echo "<td>" . $row['ID_ANGAJAT'] . "</td>";
        echo "<td>" . $row['NUME'] . "</td>";
        echo "<td>" . $row['FUNCTIE'] . "</td>";
        echo "<td>" . $row['DATE_DE_CONTACT'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";

    // Adăugarea imaginii sub tabel
    echo "<img src='C:\\xampp\\htdocs\\Proiect\\imaginicu' alt='Imaginea cu locația specificată' />";
}

?>

</body>
</html>

<?php
require 'config.php';
// Include fișierul de conexiune la baza de date sau orice alt cod necesar pentru conexiunea la baza de date

if(isset($_GET['nume_client']) || isset($_GET['adresa']) || isset($_GET['contact']) || isset($_GET['id_client'])) {
    // Secțiunea de căutare și afișare pentru clienți
    $searchNume = isset($_GET['nume_client']) ? $_GET['nume_client'] : '';
    $searchAdresa = isset($_GET['adresa']) ? $_GET['adresa'] : '';
    $searchContact = isset($_GET['contact']) ? $_GET['contact'] : '';
    $searchID = isset($_GET['id_client']) ? $_GET['id_client'] : '';

    $sql = "SELECT ID_CLIENT, NUME, ADRESA, CONTACT FROM clienti WHERE 1=1";

    if ($searchNume) {
        $sql .= " AND NUME LIKE '%' || :searchNume || '%'";
    }
    if ($searchAdresa) {
        $sql .= " AND ADRESA LIKE '%' || :searchAdresa || '%'";
    }
    if ($searchContact) {
        $sql .= " AND CONTACT LIKE '%' || :searchContact || '%'";
    }
    if ($searchID) {
        $sql .= " AND ID_CLIENT = :searchID";
    }

    $stid = oci_parse($conn, $sql);

    if ($searchNume) {
        oci_bind_by_name($stid, ":searchNume", $searchNume);
    }
    if ($searchAdresa) {
        oci_bind_by_name($stid, ":searchAdresa", $searchAdresa);
    }
    if ($searchContact) {
        oci_bind_by_name($stid, ":searchContact", $searchContact);
    }
    if ($searchID) {
        oci_bind_by_name($stid, ":searchID", $searchID);
    }

    oci_execute($stid);

    echo "<h3 class='search-results-heading'>Rezultate Căutare Clienți</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table' border='1'>";
    echo "<tr><th>ID Client</th><th>Nume</th><th>Adresă</th><th>Contact</th></tr>";

    while (($row = oci_fetch_assoc($stid)) != false) {
        echo "<tr class='search-results-row'>";
        echo "<td class='search-results-cell'>" . $row['ID_CLIENT'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['NUME'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ADRESA'] . "</td>";
       
        echo "<td class='search-results-cell'>" . $row['CONTACT'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";

    // Adăugarea imaginii sub tabel
    echo "<img src='imagini/clienti.jfif' alt='Imaginea cu locația specificată' />";
}
?>