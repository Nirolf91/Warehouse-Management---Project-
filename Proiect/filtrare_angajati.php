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
    echo "</table>";
    echo "</div>";

    // Adăugarea imaginii sub tabel
    echo "<img src='imagini/angajati.jpg' alt='Imaginea cu locația specificată' />";
}

?>

</body>
</html>
