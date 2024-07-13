<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultate Căutare Evaluări</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<?php
require 'config.php';

function getFilteredEvaluations($searchIDClient, $searchScor, $searchFeedback, $searchDataEvaluarii, $searchIDEvaluare) {
    global $conn; 

    $sql = "SELECT ID_EVALUARE, ID_CLIENT, SCOR, FEEDBACK, DATA_EVALUARII FROM EVALUARI WHERE 1=1";

    if ($searchIDClient) {
        $sql .= " AND ID_CLIENT = :searchIDClient";
    }
    if ($searchScor) {
        $sql .= " AND SCOR = :searchScor";
    }
    if ($searchFeedback) {
        $sql .= " AND FEEDBACK LIKE '%' || :searchFeedback || '%'";
    }
    if ($searchDataEvaluarii) {
        $sql .= " AND DATA_EVALUARII = :searchDataEvaluarii";
    }
    if ($searchIDEvaluare) {
        $sql .= " AND ID_EVALUARE = :searchIDEvaluare";
    }

    $stid = oci_parse($conn, $sql);
    
    if ($searchIDClient) {
        oci_bind_by_name($stid, ":searchIDClient", $searchIDClient);
    }
    if ($searchScor) {
        oci_bind_by_name($stid, ":searchScor", $searchScor);
    }
    if ($searchFeedback) {
        oci_bind_by_name($stid, ":searchFeedback", $searchFeedback);
    }
    if ($searchDataEvaluarii) {
        oci_bind_by_name($stid, ":searchDataEvaluarii", $searchDataEvaluarii);
    }
    if ($searchIDEvaluare) {
        oci_bind_by_name($stid, ":searchIDEvaluare", $searchIDEvaluare);
    }
    
    oci_execute($stid);

    return $stid; 
}

if(isset($_GET['id_client']) || isset($_GET['scor']) || isset($_GET['feedback']) || isset($_GET['data_evaluarii']) || isset($_GET['id_evaluare'])) {
    $searchIDClient = isset($_GET['id_client']) ? $_GET['id_client'] : '';
    $searchScor = isset($_GET['scor']) ? $_GET['scor'] : '';
    $searchFeedback = isset($_GET['feedback']) ? $_GET['feedback'] : '';
    $searchDataEvaluarii = isset($_GET['data_evaluarii']) ? $_GET['data_evaluarii'] : '';
    $searchIDEvaluare = isset($_GET['id_evaluare']) ? $_GET['id_evaluare'] : '';

    $filteredEvaluations = getFilteredEvaluations($searchIDClient, $searchScor, $searchFeedback, $searchDataEvaluarii, $searchIDEvaluare);

    echo "<h3 class='search-results-heading'>Rezultate Căutare Evaluări</h3>";
    echo "<div class='search-results-wrapper'>";
    echo "<table class='search-results-table' border='1'>";
    echo "<tr><th>ID Evaluare</th><th>ID Client</th><th>Scor</th><th>Feedback</th><th>Data Evaluării</th></tr>";

    while (($row = oci_fetch_assoc($filteredEvaluations)) != false) {
        echo "<tr class='search-results-row'>";
        echo "<td class='search-results-cell'>" . $row['ID_EVALUARE'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['ID_CLIENT'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['SCOR'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['FEEDBACK'] . "</td>";
        echo "<td class='search-results-cell'>" . $row['DATA_EVALUARII'] . "</td>";
        echo "</tr>";
    }

    echo "</table>";
    echo "</div>";
    echo "<img src='imagini/evaluari.jpg' alt='Imaginea cu locația specificată' />";

}
?>

</body>
</html>
