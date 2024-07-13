<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultate Căutare Comenzi</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<?php
require 'config.php';

function getFilteredOrders($searchIDComanda, $searchDataComenzii) {
    global $conn; 

    $sql = "SELECT ID_COMANDA, DATA_COMENZII, ID_CLIENT, ID_FURNIZOR, ID_ANGAJAT, ID_MATERIAL, TOTAL_COMANDA, STATUT_COMANDA, TIP_COMANDA, CANTITATE, PRET_TOTAL, ID_TRANSPORTATOR FROM comenzi WHERE 1=1";

    if ($searchIDComanda) {
        $sql .= " AND ID_COMANDA = :searchIDComanda";
    }
    if ($searchDataComenzii) {
        $sql .= " AND DATA_COMENZII = :searchDataComenzii";
    }

    $stid = oci_parse($conn, $sql);
    
    if ($searchIDComanda) {
        oci_bind_by_name($stid, ":searchIDComanda", $searchIDComanda);
    }
    if ($searchDataComenzii) {
        oci_bind_by_name($stid, ":searchDataComenzii", $searchDataComenzii);
    }
    
    oci_execute($stid);

    return $stid; 
}

if(isset($_GET['id_comanda']) || isset($_GET['data_comenzii'])) {
    $searchIDComanda = isset($_GET['id_comanda']) ? $_GET['id_comanda'] : '';
    $searchDataComenzii = isset($_GET['data_comenzii']) ? $_GET['data_comenzii'] : '';

    // Afișăm rezultatele doar pentru comenzile căutate
    $filteredOrders = getFilteredOrders($searchIDComanda, $searchDataComenzii);

    echo "<h3 class='search-results-heading'>Rezultate Căutare Comenzi</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table' border='1'>";
    echo "<tr><th>ID Comandă</th><th>Data Comenzii</th><th>ID Client</th><th>ID Furnizor</th><th>ID Angajat</th><th>ID Material</th><th>Total Comandă</th><th>Statut Comandă</th><th>Tip Comandă</th><th>Cantitate</th><th>Pret Total</th><th>ID Transportator</th></tr>";

    while (($row = oci_fetch_assoc($filteredOrders)) != false) {
        echo "<tr class='search-results-row'>";
        echo "<td class='search-results-cell'>" . $row['ID_COMANDA'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['DATA_COMENZII'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_CLIENT'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_FURNIZOR'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_ANGAJAT'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_MATERIAL'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['TOTAL_COMANDA'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['STATUT_COMANDA'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['TIP_COMANDA'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['CANTITATE'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['PRET_TOTAL'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_TRANSPORTATOR'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";
    echo "<img src='imagini/comenzi.jpg' alt='Imaginea cu locația specificată' />";
}
?>

</body>
</html>
