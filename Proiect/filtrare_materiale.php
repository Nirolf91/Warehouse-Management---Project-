<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultate Căutare Materiale</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<?php
require 'config.php';

function getFilteredMaterials($searchIDMaterial, $searchNume, $searchDescriere, $searchCantitate, $searchPretUnitar, $searchIDFurnizor) {
    global $conn; 

    $sql = "SELECT ID_MATERIAL, NUME, DESCRIERE, CANTITATE_IN_STOC, PRET_UNITAR, ID_FURNIZOR FROM materiale WHERE 1=1";

    if ($searchIDMaterial) {
        $sql .= " AND ID_MATERIAL = :searchIDMaterial";
    }
    if ($searchNume) {
        $sql .= " AND NUME LIKE '%' || :searchNume || '%'";
    }
    if ($searchDescriere) {
        $sql .= " AND DESCRIERE LIKE '%' || :searchDescriere || '%'";
    }
    if ($searchCantitate) {
        $sql .= " AND CANTITATE_IN_STOC = :searchCantitate";
    }
    if ($searchPretUnitar) {
        $sql .= " AND PRET_UNITAR = :searchPretUnitar";
    }
    if ($searchIDFurnizor) {
        $sql .= " AND ID_FURNIZOR = :searchIDFurnizor";
    }

    $stid = oci_parse($conn, $sql);
    
    if ($searchIDMaterial) {
        oci_bind_by_name($stid, ":searchIDMaterial", $searchIDMaterial);
    }
    if ($searchNume) {
        oci_bind_by_name($stid, ":searchNume", $searchNume);
    }
    if ($searchDescriere) {
        oci_bind_by_name($stid, ":searchDescriere", $searchDescriere);
    }
    if ($searchCantitate) {
        oci_bind_by_name($stid, ":searchCantitate", $searchCantitate);
    }
    if ($searchPretUnitar) {
        oci_bind_by_name($stid, ":searchPretUnitar", $searchPretUnitar);
    }
    if ($searchIDFurnizor) {
        oci_bind_by_name($stid, ":searchIDFurnizor", $searchIDFurnizor);
    }
    
    oci_execute($stid);

    return $stid; 
}

if(isset($_GET['id_material']) || isset($_GET['nume_material']) || isset($_GET['descriere']) || isset($_GET['cantitate']) || isset($_GET['pret_unitar']) || isset($_GET['id_furnizor'])) {
    // Secțiunea de căutare și afișare pentru materiale
    $searchIDMaterial = isset($_GET['id_material']) ? $_GET['id_material'] : '';
    $searchNume = isset($_GET['nume_material']) ? $_GET['nume_material'] : '';
    $searchDescriere = isset($_GET['descriere']) ? $_GET['descriere'] : '';
    $searchCantitate = isset($_GET['cantitate']) ? $_GET['cantitate'] : '';
    $searchPretUnitar = isset($_GET['pret_unitar']) ? $_GET['pret_unitar'] : '';
    $searchIDFurnizor = isset($_GET['id_furnizor']) ? $_GET['id_furnizor'] : '';

    $filteredMaterials = getFilteredMaterials($searchIDMaterial, $searchNume, $searchDescriere, $searchCantitate, $searchPretUnitar, $searchIDFurnizor);

    echo "<h3 class='search-results-heading'>Rezultate Căutare Materiale</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table' border='1'>";
    echo "<tr><th>ID Material</th><th>Nume</th><th>Descriere</th><th>Cantitate în Stoc</th><th>Preț Unitar</th><th>ID Furnizor</th></tr>";

    while (($row = oci_fetch_assoc($filteredMaterials)) != false) {
        echo "<tr class='search-results-row'>";
        echo "<td class='search-results-cell'>" . $row['ID_MATERIAL'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['NUME'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['DESCRIERE'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['CANTITATE_IN_STOC'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['PRET_UNITAR'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_FURNIZOR'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";
    echo "<img src='imagini/materiale.jpg' alt='Imaginea cu locația specificată' />";
}
?>

</body>
</html>
