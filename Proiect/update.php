<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UPDATE</title>
    <style>
        /* Stiluri pentru formular */
        form {
            margin-top: 20px;
        }
        label {
            display: block;
            margin-bottom: 5px;
        }
        input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <h1>UPDATE</h1>

    <?php
    require 'config.php';

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $table = $_POST['table'];

        if ($table == 'Angajati') {
            $id = $_POST['id_angajat'];
            $nume = $_POST['nume'];
            $functie = $_POST['functie'];
            $contact = $_POST['date_de_contact'];

            $sql = "UPDATE Angajati SET NUME = :nume, FUNCTIE = :functie, DATE_DE_CONTACT = :contact WHERE ID_ANGAJAT = :id";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id', $id);
            oci_bind_by_name($stid, ':nume', $nume);
            oci_bind_by_name($stid, ':functie', $functie);
            oci_bind_by_name($stid, ':contact', $contact);
        } elseif ($table == 'Clienti') {
            $id = $_POST['id'];
            $nume = $_POST['nume'];
            $adresa = $_POST['adresa'];
            $contact = $_POST['contact'];

            $sql = "UPDATE Clienti SET NUME = :nume, ADRESA = :adresa, CONTACT = :contact WHERE ID_CLIENT = :id";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id', $id);
            oci_bind_by_name($stid, ':nume', $nume);
            oci_bind_by_name($stid, ':adresa', $adresa);
            oci_bind_by_name($stid, ':contact', $contact);
        } elseif ($table == 'Comenzi') {
            $id_comanda = $_POST['id_comanda'];
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

            $sql = "UPDATE Comenzi SET DATA_COMENZII = :data_comenzii, ID_CLIENT = :id_client, ID_FURNIZOR = :id_furnizor, ID_ANGAJAT = :id_angajat, ID_MATERIAL = :id_material, TOTAL_COMANDA = :total_comanda, STATUT_COMANDA = :statut_comanda, TIP_COMANDA = :tip_comanda, CANTITATE = :cantitate, PRET_TOTAL = :pret_total, ID_TRANSPORTATOR = :id_transportator WHERE ID_COMANDA = :id_comanda";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id_comanda', $id_comanda);
            oci_bind_by_name($stid, ':data_comenzii', $data_comenzii);
            oci_bind_by_name($stid, ':id_client', $id_client);
            oci_bind_by_name($stid, ':id_furnizor', $id_furnizor);
            oci_bind_by_name($stid, ':id_angajat', $id_angajat);
            oci_bind_by_name($stid, ':id_material', $id_material);
            oci_bind_by_name($stid, ':total_comanda', $total_comanda);
            oci_bind_by_name($stid, ':statut_comanda', $statut_comanda);
            oci_bind_by_name($stid, ':tip_comanda', $tip_comanda);
            oci_bind_by_name($stid, ':cantitate', $cantitate);
            oci_bind_by_name($stid, ':pret_total', $pret_total);
            oci_bind_by_name($stid, ':id_transportator', $id_transportator);
        } elseif ($table == 'Furnizori') {
            $id = $_POST['id_furnizor'];
            $nume = $_POST['nume'];
            $adresa = $_POST['adresa'];
            $contact = $_POST['contact'];

            $sql = "UPDATE Furnizori SET NUME = :nume, ADRESA = :adresa, CONTACT = :contact WHERE ID_FURNIZOR = :id";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id', $id);
            oci_bind_by_name($stid, ':nume', $nume);
            oci_bind_by_name($stid, ':adresa', $adresa);
            oci_bind_by_name($stid, ':contact', $contact); 
                
        } elseif ($table == 'Evaluari') {
            $id_evaluare = $_POST['id_evaluare'];
            $id_client = $_POST['id_client'];
            $scor = $_POST['scor'];
            $feedback = $_POST['feedback'];
            $data_evaluarii = $_POST['data_evaluarii'];
        
            $sql = "UPDATE Evaluari SET ID_CLIENT = :id_client, SCOR = :scor, FEEDBACK = :feedback, DATA_EVALUARII = TO_DATE(:data_evaluarii, 'YYYY-MM-DD') WHERE ID_EVALUARE = :id_evaluare";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id_evaluare', $id_evaluare);
            oci_bind_by_name($stid, ':id_client', $id_client);
            oci_bind_by_name($stid, ':scor', $scor);
            oci_bind_by_name($stid, ':feedback', $feedback);
            oci_bind_by_name($stid, ':data_evaluarii', $data_evaluarii);
        }elseif ($table == 'Materiale') {
            $id = $_POST['id_material'];
            $nume = $_POST['nume'];
            $descriere = $_POST['descriere'];
            $cantitate_in_stoc = $_POST['cantitate_in_stoc'];
            $pret_unitar = $_POST['pret_unitar'];
            $id_furnizor = $_POST['id_furnizor'];

            $sql = "UPDATE Materiale SET NUME = :nume, DESCRIERE = :descriere, CANTITATE_IN_STOC = :cantitate_in_stoc, PRET_UNITAR = :pret_unitar, ID_FURNIZOR = :id_furnizor WHERE ID_MATERIAL = :id";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id', $id);
            oci_bind_by_name($stid, ':nume', $nume);
            oci_bind_by_name($stid, ':descriere', $descriere);
            oci_bind_by_name($stid, ':cantitate_in_stoc', $cantitate_in_stoc);
            oci_bind_by_name($stid, ':pret_unitar', $pret_unitar);
            oci_bind_by_name($stid, ':id_furnizor', $id_furnizor);
        } elseif ($table == 'Transportatori') {
            $id = $_POST['id_transportator'];
            $nume = $_POST['nume'];
            $contact = $_POST['contact'];
            $pret_pe_kg = $_POST['pret_pe_kg'];

            $sql = "UPDATE Transportatori SET NUME = :nume, PRET_PE_KG = :pret_pe_kg, CONTACT = :contact WHERE ID_TRANSPORTATOR = :id";
            $stid = oci_parse($conn, $sql);
            oci_bind_by_name($stid, ':id', $id);
            oci_bind_by_name($stid, ':nume', $nume);
            oci_bind_by_name($stid, ':contact', $contact);
            oci_bind_by_name($stid, ':pret_pe_kg', $pret_pe_kg);
        } else {
            die("Tabel necunoscut!");
        }

        $r = oci_execute($stid);
        if ($r) {
            oci_commit($conn);
            echo "<p>Actualizare realizată cu succes!</p>";
        } else {
            $e = oci_error($stid);
            echo "<p>Eroare la actualizare: " . htmlentities($e['message'], ENT_QUOTES) . "</p>";
        }

        oci_free_statement($stid);
        oci_close($conn);
    }
    ?>

<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
<label for="id-angajat-update">ID Angajat:</label>
<input type="text" id="id-angajat-update" name="id_angajat" required style="width: 100%;">
<br>
<label for="nume-update">Nume nou:</label>
<input type="text" id="nume-update" name="nume" required style="width: 100%;">
<br>
<label for="functie-update">Funcție nouă:</label>
<input type="text" id="functie-update" name="functie" required style="width: 100%;">
<br>
<label for="date-de-contact-update">Date de Contact noi:</label>
<input type="text" id="date-de-contact-update" name="date_de_contact" required style="width: 100%;">
<br>

<input type="hidden" name="table" value="Angajati">
<input type="submit" value="Actualizare Angajat" style="width: 100%;">
</form>

<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
<label for="id-update">ID Client:</label>
<input type="text" id="id-update" name="id" required style="width: 100%;">
<br>
<label for="nume-update">Nume nou:</label>
<input type="text" id="nume-update" name="nume" required style="width: 100%;">
<br>
<label for="adresa-update">Adresă nouă:</label>
<input type="text" id="adresa-update" name="adresa" required style="width: 100%;">
<br>
<label for="contact-update">Date de Contact noi:</label>
<input type="text" id="contact-update" name="contact" required style="width: 100%;">
<br>
<input type="hidden" name="table" value="Clienti">
<input type="submit" value="Actualizare Client" style="width: 100%;">
</form>

<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
<label for="id-comanda-update">ID Comandă:</label>
<input type="text" id="id-comanda-update" name="id_comanda" required style="width: 100%;">
<br>
<label for="data-comenzii-update">Data comenzii nouă:</label>
<input type="text" id="data-comenzii-update" name="data_comenzii" required style="width: 100%;">
<br>
<label for="id-client-update">ID Client:</label>
<input type="text" id="id-client-update" name="id_client" required style="width: 100%;">
<br>
<label for="id-furnizor-update">ID Furnizor:</label>
<input type="text" id="id-furnizor-update" name="id_furnizor" required style="width: 100%;">
<br>
<label for="id-angajat-update">ID Angajat:</label>
<input type="text" id="id-angajat-update" name="id_angajat" required style="width: 100%;">
<br>
<label for="id-material-update">ID Material:</label>
<input type="text" id="id-material-update" name="id_material" required style="width: 100%;">
<br>
<label for="total-comanda-update">Total comandă:</label>
<input type="text" id="total-comanda-update" name="total_comanda" required style="width: 100%;">
<br>
<label for="statut-comanda-update">Statut comandă:</label>
<input type="text" id="statut-comanda-update" name="statut_comanda" required style="width: 100%;">
<br>
<label for="tip-comanda-update">Tip comandă:</label>
<input type="text" id="tip-comanda-update" name="tip_comanda" required style="width: 100%;">
<br>
<label for="cantitate-update">Cantitate:</label>
<input type="text" id="cantitate-update" name="cantitate" required style="width: 100%;">
<br>
<label for="pret-total-update">Preț total:</label>
<input type="text" id="pret-total-update" name="pret_total" required style="width: 100%;">
<br>
<label for="id-transportator-update">ID Transportator:</label>
<input type="text" id="id-transportator-update" name="id_transportator" required style="width: 100%;">
<br>
<input type="hidden" name="table" value="Comenzi">
<input type="submit" value="Actualizare Comandă" style="width: 100%;">
</form>

<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
    <!-- Campuri specifice actualizării furnizorului -->
    <label for="id-furnizor-update">ID Furnizor:</label>
    <input type="text" id="id-furnizor-update" name="id_furnizor" required style="width: 100%;">
    <br>
    <label for="nume-update">Nume nou:</label>
    <input type="text" id="nume-update" name="nume" required style="width: 100%;">
    <br>
    <label for="adresa-update">Adresă nouă:</label>
    <input type="text" id="adresa-update" name="adresa" required style="width: 100%;">
    <br>
    <label for="contact-update">Contact nou:</label>
    <input type="text" id="contact-update" name="contact" required style="width: 100%;">
    <br>

    <!-- Câmp ascuns pentru a specifica tabela -->
    <input type="hidden" name="table" value="Furnizori">
    <!-- Buton de submit pentru actualizare -->
    <input type="submit" value="Actualizare Furnizor" style="width: 100%;">
</form>

<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
    <label for="id-evaluare-update">ID Evaluare:</label>
    <input type="text" id="id-evaluare-update" name="id_evaluare" required style="width: 100%;">
    <br>
    <label for="id-client-evaluare-update">ID Client:</label>
    <input type="text" id="id-client-evaluare-update" name="id_client" required style="width: 100%;">
    <br>
    <label for="scor-update">Scor nou:</label>
    <input type="text" id="scor-update" name="scor" required style="width: 100%;">
    <br>
    <label for="feedback-update">Feedback nou:</label>
    <input type="text" id="feedback-update" name="feedback" required style="width: 100%;">
    <br>
    <label for="data-evaluarii-update">Data evaluării nouă:</label>
    <input type="text" id="data-evaluarii-update" name="data_evaluarii" required style="width: 100%;">
    <br>
    <input type="hidden" name="table" value="Evaluari">
    <input type="submit" value="Actualizare Evaluare" style="width: 100%;">
</form>


<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
    <label for="id-material-update">ID Material:</label>
    <input type="text" id="id-material-update" name="id_material" required style="width: 100%;">
    <br>
    <label for="nume-update">Nume:</label>
    <input type="text" id="nume-update" name="nume" required style="width: 100%;">
    <br>
    <label for="descriere-update">Descriere:</label>
    <input type="text" id="descriere-update" name="descriere" required style="width: 100%;">
    <br>
    <label for="cantitate-update">Cantitate:</label>
    <input type="text" id="cantitate-update" name="cantitate_in_stoc" required style="width: 100%;">
    <br>
    <label for="pret-update">Pret:</label>
    <input type="text" id="pret-update" name="pret_unitar" required style="width: 100%;">
    <br>
    <label for="id-furnizor-update">ID Furnizor:</label>
    <input type="text" id="id-furnizor-update" name="id_furnizor" required style="width: 100%;">
    <br>

    <input type="hidden" name="table" value="Materiale">
    <input type="submit" value="Actualizare Material" style="width: 100%;">
</form>


<form action="update.php" method="post" style="width: 200px; margin-top: 10px;">
    <label for="id-transportator-update">ID Transportator:</label>
    <input type="text" id="id-transportator-update" name="id_transportator" required style="width: 100%;">
    <br>
    <label for="nume-update">Nume nou:</label>
    <input type="text" id="nume-update" name="nume" required style="width: 100%;">
    <br>
    <label for="pret_pe_kg-update">Preț pe kg:</label>
    <input type="text" id="pret_pe_kg-update" name="pret_pe_kg" required style="width: 100%;">
    <br>
    <label for="contact-update">Contact nou:</label>
    <input type="text" id="contact-update" name="contact" required style="width: 100%;">
    <br>

    <input type="hidden" name="table" value="Transportatori">
    <input type="submit" value="Actualizare Transportator" style="width: 100%;">
</form>

</body>
</html>
