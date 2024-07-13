<?php
require 'config.php';

// Verificare dacă formularul a fost trimis pentru inserare de angajați
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['nume']) && isset($_POST['functie']) && isset($_POST['contact'])) {
    // Prelucrare datele primite din formular
    $nume = $_POST['nume'];
    $functie = $_POST['functie'];
    $contact = $_POST['contact'];

    // Interogare de inserare pentru angajați
    $sql_angajati = "INSERT INTO Angajati (NUME, FUNCTIE, DATE_DE_CONTACT) VALUES (:nume, :functie, :contact)";
    $stid_angajati = oci_parse($conn, $sql_angajati);

    // Legare parametrii
    oci_bind_by_name($stid_angajati, ":nume", $nume);
    oci_bind_by_name($stid_angajati, ":functie", $functie);
    oci_bind_by_name($stid_angajati, ":contact", $contact);

    // Executare interogare
    $result_angajati = oci_execute($stid_angajati);

    if ($result_angajati) {
        echo "Înregistrare pentru angajat inserată cu succes.";
    } else {
        $e_angajati = oci_error($stid_angajati);
        echo "Eroare la inserarea înregistrării pentru angajat: " . htmlentities($e_angajati['message'], ENT_QUOTES);
    }

    // Eliberare resurse pentru inserare angajați
    oci_free_statement($stid_angajati);
}

// Verificare dacă formularul a fost trimis pentru inserare de clienți
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['nume_client']) && isset($_POST['adresa_client']) && isset($_POST['contact_client'])) {
    // Prelucrare datele primite din formular
    $nume_client = $_POST['nume_client'];
    $adresa_client = $_POST['adresa_client'];
    $contact_client = $_POST['contact_client'];

    // Interogare de inserare pentru clienți
    $sql_clienti = "INSERT INTO Clienti (NUME, ADRESA, CONTACT) VALUES (:nume_client, :adresa_client, :contact_client)";
    $stid_clienti = oci_parse($conn, $sql_clienti);

    // Legare parametrii
    oci_bind_by_name($stid_clienti, ":nume_client", $nume_client);
    oci_bind_by_name($stid_clienti, ":adresa_client", $adresa_client);
    oci_bind_by_name($stid_clienti, ":contact_client", $contact_client);

    // Executare interogare
    $result_clienti = oci_execute($stid_clienti);

    if ($result_clienti) {
        echo "Înregistrare pentru client inserată cu succes.";
    } else {
        $e_clienti = oci_error($stid_clienti);
        echo "Eroare la inserarea înregistrării pentru client: " . htmlentities($e_clienti['message'], ENT_QUOTES);
    }

    // Eliberare resurse pentru inserare clienți
    oci_free_statement($stid_clienti);
}

// Verificare dacă formularul a fost trimis pentru inserare de comenzi
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['data_comenzii']) && isset($_POST['id_client']) && isset($_POST['id_furnizor']) && isset($_POST['id_angajat']) && isset($_POST['id_material']) && isset($_POST['total_comanda']) && isset($_POST['statut_comanda']) && isset($_POST['tip_comanda']) && isset($_POST['cantitate']) && isset($_POST['pret_total']) && isset($_POST['id_transportator'])) {
    // Prelucrare datele primite din formular
    $data_comenzii = $_POST['data_comenzii'];
    $id_client = $_POST['id_client'];
    $id_furnizor = $_POST['id_furnizor'];
    $id_angajat = $_POST['id_angajat'];
    $id_material = $_POST['id_material'];
    $total_comanda = $_POST['total_comanda'];
    $statut_comanda = $_POST['statut_comanda'];
    $tip_comanda = $_POST['tip_comanda'];
    $cantitate = $_POST['cantitate'];
    $pret_total = $_POST['pret_total'];
    $id_transportator = $_POST['id_transportator'];

    // Verificare existență ID-uri în tabelele părinte
    function check_id_exists($conn, $table, $column, $id) {
        $sql = "SELECT COUNT(*) AS CNT FROM $table WHERE $column = :id";
        $stid = oci_parse($conn, $sql);
        oci_bind_by_name($stid, ":id", $id);
        oci_execute($stid);
        $row = oci_fetch_assoc($stid);
        oci_free_statement($stid);
        return $row['CNT'] > 0;
    }

    if (!check_id_exists($conn, 'Clienti', 'ID_CLIENT', $id_client)) {
        echo "ID client nu există.";
        exit;
    }
    if (!check_id_exists($conn, 'Furnizori', 'ID_FURNIZOR', $id_furnizor)) {
        echo "ID furnizor nu există.";
        exit;
    }
    if (!check_id_exists($conn, 'Angajati', 'ID_ANGAJAT', $id_angajat)) {
        echo "ID angajat nu există.";
        exit;
    }
    if (!check_id_exists($conn, 'Materiale', 'ID_MATERIAL', $id_material)) {
        echo "ID material nu există.";
        exit;
    }
    if (!check_id_exists($conn, 'Transportatori', 'ID_TRANSPORTATOR', $id_transportator)) {
        echo "ID transportator nu există.";
        exit;
    }

    // Obținerea unui nou ID pentru comanda utilizând secvența
    $sql_sequence = "SELECT comenzi_seq.NEXTVAL AS new_id FROM dual";
    $stid_sequence = oci_parse($conn, $sql_sequence);
    oci_execute($stid_sequence);
    $row_sequence = oci_fetch_assoc($stid_sequence);
    $new_id_comanda = $row_sequence['NEW_ID'];
    oci_free_statement($stid_sequence);

    // Interogare de inserare pentru comenzi
    $sql_comenzi = "INSERT INTO Comenzi (ID_COMANDA, DATA_COMENZII, ID_CLIENT, ID_FURNIZOR, ID_ANGAJAT, ID_MATERIAL, TOTAL_COMANDA, STATUT_COMANDA, TIP_COMANDA, CANTITATE, PRET_TOTAL, ID_TRANSPORTATOR) VALUES (:id_comanda, TO_DATE(:data_comenzii, 'YYYY-MM-DD'), :id_client, :id_furnizor, :id_angajat, :id_material, :total_comanda, :statut_comanda, :tip_comanda, :cantitate, :pret_total, :id_transportator)";
    $stid_comenzi = oci_parse($conn, $sql_comenzi);

    // Legare parametrii
    oci_bind_by_name($stid_comenzi, ":id_comanda", $new_id_comanda);
    oci_bind_by_name($stid_comenzi, ":data_comenzii", $data_comenzii);
    oci_bind_by_name($stid_comenzi, ":id_client", $id_client);
    oci_bind_by_name($stid_comenzi, ":id_furnizor", $id_furnizor);
    oci_bind_by_name($stid_comenzi, ":id_angajat", $id_angajat);
    oci_bind_by_name($stid_comenzi, ":id_material", $id_material);
    oci_bind_by_name($stid_comenzi, ":total_comanda", $total_comanda);
    oci_bind_by_name($stid_comenzi, ":statut_comanda", $statut_comanda);
    oci_bind_by_name($stid_comenzi, ":tip_comanda", $tip_comanda);
    oci_bind_by_name($stid_comenzi, ":cantitate", $cantitate);
    oci_bind_by_name($stid_comenzi, ":pret_total", $pret_total);
    oci_bind_by_name($stid_comenzi, ":id_transportator", $id_transportator);

    // Executare interogare
    $result_comenzi = oci_execute($stid_comenzi);

    if ($result_comenzi) {
        echo "Înregistrare pentru comandă inserată cu succes.";
    } else {
        $e_comenzi = oci_error($stid_comenzi);
        echo "Eroare la inserarea înregistrării pentru comandă: " . htmlentities($e_comenzi['message'], ENT_QUOTES);
    }

    // Eliberare resurse pentru inserare comenzi
    oci_free_statement($stid_comenzi);
}

// Verificare dacă formularul a fost trimis pentru inserare de furnizori
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['nume_furnizor']) && isset($_POST['adresa_furnizor']) && isset($_POST['contact_furnizor'])) {
    // Prelucrare datele primite din formular
    $nume_furnizor = $_POST['nume_furnizor'];
    $adresa_furnizor = $_POST['adresa_furnizor'];
    $contact_furnizor = $_POST['contact_furnizor'];

    // Interogare de inserare pentru furnizori
    $sql_furnizori = "INSERT INTO Furnizori (NUME, ADRESA, CONTACT) VALUES (:nume_furnizor, :adresa_furnizor, :contact_furnizor)";
    $stid_furnizori = oci_parse($conn, $sql_furnizori);

    // Legare parametrii
    oci_bind_by_name($stid_furnizori, ":nume_furnizor", $nume_furnizor);
    oci_bind_by_name($stid_furnizori, ":adresa_furnizor", $adresa_furnizor);
    oci_bind_by_name($stid_furnizori, ":contact_furnizor", $contact_furnizor);

    // Executare interogare
    $result_furnizori = oci_execute($stid_furnizori);

    if ($result_furnizori) {
        echo "Înregistrare pentru furnizor inserată cu succes.";
    } else {
        $e_furnizori = oci_error($stid_furnizori);
        echo "Eroare la inserarea înregistrării pentru furnizor: " . htmlentities($e_furnizori['message'], ENT_QUOTES);
    }

    // Eliberare resurse pentru inserare furnizori
    oci_free_statement($stid_furnizori);
}

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Verificăm dacă formularul pentru evaluări a fost trimis
    if (isset($_POST['id_client']) && isset($_POST['scor']) && isset($_POST['feedback']) && isset($_POST['data_evaluarii'])) {
    $id_client = htmlspecialchars($_POST['id_client'], ENT_QUOTES);
    $scor = htmlspecialchars($_POST['scor'], ENT_QUOTES);
    $feedback = htmlspecialchars($_POST['feedback'], ENT_QUOTES);
    $data_evaluarii = htmlspecialchars($_POST['data_evaluarii'], ENT_QUOTES);
        // Obținem un nou ID pentru evaluare utilizând secvența
        $sql_sequence = "SELECT evaluare_seq.NEXTVAL AS new_id FROM dual";
        $stid_sequence = oci_parse($conn, $sql_sequence);
        oci_execute($stid_sequence);
        $row_sequence = oci_fetch_assoc($stid_sequence);
        $new_id_evaluare = $row_sequence['NEW_ID'];
        oci_free_statement($stid_sequence);
    
        // Creăm interogarea SQL pentru inserare
        $sql = "INSERT INTO Evaluari (ID_EVALUARE, ID_CLIENT, SCOR, FEEDBACK, DATA_EVALUARII) VALUES (:id_evaluare, :id_client, :scor, :feedback, TO_DATE(:data_evaluarii, 'YYYY-MM-DD'))";
        $stid = oci_parse($conn, $sql);
    
        // Legăm variabilele de parametrii SQL
        oci_bind_by_name($stid, ':id_evaluare', $new_id_evaluare);
        oci_bind_by_name($stid, ':id_client', $id_client);
        oci_bind_by_name($stid, ':scor', $scor);
        oci_bind_by_name($stid, ':feedback', $feedback);
        oci_bind_by_name($stid, ':data_evaluarii', $data_evaluarii);
    
        // Executăm interogarea
        $result = oci_execute($stid);
    
        if ($result) {
            echo "Evaluare inserată cu succes!";
        } else {
            $error = oci_error($stid);
            echo "Eroare la inserare: " . $error['message'];
        }
    
        // Eliberăm resursele
        oci_free_statement($stid);
    } else {
        echo "";
    }
    
}

// Verificare dacă formularul a fost trimis pentru inserare de materiale
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['nume']) && isset($_POST['descriere']) && isset($_POST['cantitate_in_stoc']) && isset($_POST['pret_unitar']) && isset($_POST['id_furnizor'])) {
    // Prelucrare date primite din formular
    $nume = $_POST['nume'];
    $descriere = $_POST['descriere'];
    $cantitate_in_stoc = $_POST['cantitate_in_stoc'];
    $pret_unitar = $_POST['pret_unitar'];
    $id_furnizor = $_POST['id_furnizor'];

    // Verificare dacă toate câmpurile sunt completate
    if ($nume != "" && $descriere != "" && $cantitate_in_stoc != "" && $pret_unitar != "" && $id_furnizor != "") {
        // Continuarea procesului de inserare
        try {
            // Obținerea următorului ID pentru material din secvență
            $sql_sequence = "SELECT materiale_seq.NEXTVAL AS new_id FROM dual";
            $stid_sequence = oci_parse($conn, $sql_sequence);
            if (!oci_execute($stid_sequence)) {
                $e_sequence = oci_error($stid_sequence);
                throw new Exception("Eroare la obținerea ID-ului pentru material: " . htmlentities($e_sequence['message'], ENT_QUOTES));
            }
            $row_sequence = oci_fetch_assoc($stid_sequence);
            if (!$row_sequence) {
                throw new Exception("Nu s-a putut obține noul ID pentru material.");
            }
            $new_id_material = $row_sequence['NEW_ID'];
            oci_free_statement($stid_sequence);

            // Interogare de inserare pentru materiale
            $sql_material = "INSERT INTO Materiale (ID_MATERIAL, NUME, DESCRIERE, CANTITATE_IN_STOC, PRET_UNITAR, ID_FURNIZOR) VALUES (:id_material, :nume, :descriere, :cantitate_in_stoc, :pret_unitar, :id_furnizor)";
            $stid_material = oci_parse($conn, $sql_material);
            
            // Legare parametrii
            oci_bind_by_name($stid_material, ":id_material", $new_id_material);
            oci_bind_by_name($stid_material, ":nume", $nume);
            oci_bind_by_name($stid_material, ":descriere", $descriere);
            oci_bind_by_name($stid_material, ":cantitate_in_stoc", $cantitate_in_stoc);
            oci_bind_by_name($stid_material, ":pret_unitar", $pret_unitar);
            oci_bind_by_name($stid_material, ":id_furnizor", $id_furnizor);
            
            // Executare interogare
            if (!oci_execute($stid_material)) {
                $e_material = oci_error($stid_material);
                throw new Exception("Eroare la inserarea înregistrării pentru material: " . htmlentities($e_material['message'], ENT_QUOTES));
            }

            echo "Înregistrare pentru material inserată cu succes."; // Mesajul de succes

            // Eliberare resurse pentru inserare materiale
            oci_free_statement($stid_material);
        } catch (Exception $e) {
            echo $e->getMessage();
        }
    } else {
        echo "Toate câmpurile sunt obligatorii.";
    }
}




// Verificare dacă formularul a fost trimis pentru inserare de transportatori
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['nume'])&& isset($_POST['contact']) && isset($_POST['pret_pe_kg']) ) {
    // Prelucrare datele primite din formular
    $nume = $_POST['nume'];
    $contact = $_POST['contact'];
    $pret_pe_kg = $_POST['pret_pe_kg'];

    // Verificare dacă toate câmpurile sunt completate
    if ($nume != "" && $contact != "" && $pret_pe_kg != "" ) {
        // Continuarea procesului de inserare
        // Obținerea următorului ID pentru transportator din secvență
        $sql_sequence = "SELECT transportatori_seq.NEXTVAL AS new_id FROM dual";
        $stid_sequence = oci_parse($conn, $sql_sequence);
        oci_execute($stid_sequence);
        $row_sequence = oci_fetch_assoc($stid_sequence);
        $new_id_transportator = $row_sequence['NEW_ID'];
        oci_free_statement($stid_sequence);

        // Interogare de inserare pentru transportatori
        $sql_transportatori = "INSERT INTO Transportatori (ID_TRANSPORTATOR, NUME, CONTACT, PRET_PE_KG) VALUES (:id_transportator, :nume, :contact, :pret_pe_kg)";
        $stid_transportatori = oci_parse($conn, $sql_transportatori);
        
        // Legare parametrii
        oci_bind_by_name($stid_transportatori, ":id_transportator", $new_id_transportator);
        oci_bind_by_name($stid_transportatori, ":nume", $nume);
        oci_bind_by_name($stid_transportatori, ":contact", $contact);
        oci_bind_by_name($stid_transportatori, ":pret_pe_kg", $pret_pe_kg);
        
        // Executare interogare
        $result_transportatori = oci_execute($stid_transportatori);
        
        if ($result_transportatori) {
            echo "Înregistrare pentru transportator inserată cu succes.";
        } else {
            $e_transportatori = oci_error($stid_transportatori);
            echo "Eroare la inserarea înregistrării pentru transportator: " . htmlentities($e_transportatori['message'], ENT_QUOTES);
        }

        // Eliberare resurse pentru inserare transportatori
        oci_free_statement($stid_transportatori);
    } 
} else {
    echo "";
}


// Închidere conexiune
oci_close($conn);
?>
