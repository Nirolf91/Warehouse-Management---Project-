<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultate Căutare Furnizori</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<?php
require 'config.php';

function getFilteredSuppliers($searchIDFurnizor, $searchNumeFurnizor, $searchAdresa, $searchContact) {
    global $conn; 

    $sql = "SELECT ID_FURNIZOR, NUME, ADRESA, CONTACT FROM furnizori WHERE 1=1";

    if ($searchIDFurnizor) {
        $sql .= " AND ID_FURNIZOR = :searchIDFurnizor";
    }
    if ($searchNumeFurnizor) {
        $sql .= " AND NUME LIKE '%' || :searchNumeFurnizor || '%'";
    }
    if ($searchAdresa) {
        $sql .= " AND ADRESA LIKE '%' || :searchAdresa || '%'";
    }
    if ($searchContact) {
        $sql .= " AND CONTACT LIKE '%' || :searchContact || '%'";
    }

    $stid = oci_parse($conn, $sql);
    
    if ($searchIDFurnizor) {
        oci_bind_by_name($stid, ":searchIDFurnizor", $searchIDFurnizor);
    }
    if ($searchNumeFurnizor) {
        oci_bind_by_name($stid, ":searchNumeFurnizor", $searchNumeFurnizor);
    }
    if ($searchAdresa) {
        oci_bind_by_name($stid, ":searchAdresa", $searchAdresa);
    }
    if ($searchContact) {
        oci_bind_by_name($stid, ":searchContact", $searchContact);
    }
    
    oci_execute($stid);

    return $stid; 
}

if(isset($_GET['nume_furnizor']) || isset($_GET['adresa']) || isset($_GET['contact']) || isset($_GET['id_furnizor'])) {
    $searchIDFurnizor = isset($_GET['id_furnizor']) ? $_GET['id_furnizor'] : '';
    $searchNumeFurnizor = isset($_GET['nume_furnizor']) ? $_GET['nume_furnizor'] : '';
    $searchAdresa = isset($_GET['adresa']) ? $_GET['adresa'] : '';
    $searchContact = isset($_GET['contact']) ? $_GET['contact'] : '';

    $filteredSuppliers = getFilteredSuppliers($searchIDFurnizor, $searchNumeFurnizor, $searchAdresa, $searchContact);

    echo "<h3 class='search-results-heading'>Rezultate Căutare Furnizori</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table' border='1'>";
    echo "<tr><th>ID Furnizor</th><th>Nume</th><th>Adresă</th><th>Contact</th></tr>";

    while (($row = oci_fetch_assoc($filteredSuppliers)) != false) {
        echo "<tr class='search-results-row'>";
        echo "<td class='search-results-cell'>" . $row['ID_FURNIZOR'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['NUME'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ADRESA'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['CONTACT'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";
    echo "<img src='imagini/furnizori.jpg' alt='Imaginea cu locația specificată' />";
}
?>

</body>
</html>
