<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultate Căutare Transportatori</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<?php
// Includeți fișierul de configurare a bazei de date și alte funcții necesare
require 'config.php';

// Definirea funcției pentru filtrarea transportatorilor
function getFilteredCarriers($searchIDTransportator, $searchNume, $searchContact, $searchPretPeKg) {
    global $conn; 

    // Construirea interogării SQL pentru selectarea transportatorilor
    $sql = "SELECT ID_TRANSPORTATOR, NUME, CONTACT, PRET_PE_KG FROM transportatori WHERE 1=1";

    // Adăugarea condițiilor de filtrare în funcție de parametrii specificați
    if ($searchIDTransportator) {
        $sql .= " AND ID_TRANSPORTATOR = :searchIDTransportator";
    }
    if ($searchNume) {
        $sql .= " AND NUME LIKE '%' || :searchNume || '%'";
    }
    if ($searchContact) {
        $sql .= " AND CONTACT LIKE '%' || :searchContact || '%'";
    }
    if ($searchPretPeKg) {
        $sql .= " AND PRET_PE_KG = :searchPretPeKg";
    }

    // Pregătirea și executarea interogării SQL
    $stid = oci_parse($conn, $sql);
    
    // Legarea parametrilor pentru evitarea injecției SQL
    if ($searchIDTransportator) {
        oci_bind_by_name($stid, ":searchIDTransportator", $searchIDTransportator);
    }
    if ($searchNume) {
        oci_bind_by_name($stid, ":searchNume", $searchNume);
    }
    if ($searchContact) {
        oci_bind_by_name($stid, ":searchContact", $searchContact);
    }
    if ($searchPretPeKg) {
        oci_bind_by_name($stid, ":searchPretPeKg", $searchPretPeKg);
    }
    
    oci_execute($stid);

    // Returnarea rezultatelor interogării
    return $stid; 
}

// Verificarea dacă au fost furnizate criterii de căutare prin metoda GET
if(isset($_GET['id_transportator']) || isset($_GET['nume_transportator']) || isset($_GET['contact_transportator']) || isset($_GET['pret_pe_kg'])) {
    // Extrageți criteriile de căutare din parametrii GET
    $searchIDTransportator = isset($_GET['id_transportator']) ? $_GET['id_transportator'] : '';
    $searchNume = isset($_GET['nume_transportator']) ? $_GET['nume_transportator'] : '';
    $searchContact = isset($_GET['contact_transportator']) ? $_GET['contact_transportator'] : '';
    $searchPretPeKg = isset($_GET['pret_pe_kg']) ? $_GET['pret_pe_kg'] : '';

    // Apelați funcția de filtrare pentru a obține rezultatele
    $filteredCarriers = getFilteredCarriers($searchIDTransportator, $searchNume, $searchContact, $searchPretPeKg);

    // Afișați rezultatele sub formă de tabel HTML
    echo "<h3 class='search-results-heading'>Rezultate Căutare Transportatori</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table'>";
    echo "<tr><th>ID Transportator</th><th>Nume</th><th>Contact</th><th>Preț pe KG</th></tr>";

    // Iterați prin rezultate și afișați fiecare rând într-o celulă de tabel
    while (($row = oci_fetch_assoc($filteredCarriers)) != false) {
        echo "<tr class='search-results-row'>";
        echo "<td class='search-results-cell'>" . $row['ID_TRANSPORTATOR'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['NUME'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['CONTACT'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['PRET_PE_KG'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";
    echo "<img src='imagini/transportatori.jpg' alt='Imaginea cu locația specificată' />";

}
?>

</body>
</html>
