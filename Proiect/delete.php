<!DOCTYPE html>
<html lang="ro">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>DELETE</title>
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
            background-color: #f44336;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #d32f2f;
        }
    </style>
</head>
<body>
    <h1>DELETE</h1>

    <?php
    require 'config.php';

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $table = $_POST['table'];
        $id = $_POST['id'];

        if ($table == 'Angajati') {
            $sql = "DELETE FROM Angajati WHERE ID_ANGAJAT = :id";
        } elseif ($table == 'Clienti') {
            $sql = "DELETE FROM Clienti WHERE ID_CLIENT = :id";
        } elseif ($table == 'Comenzi') {
            $sql = "DELETE FROM Comenzi WHERE ID_COMANDA = :id";
        } elseif ($table == 'Furnizori') {
            $sql = "DELETE FROM Furnizori WHERE ID_FURNIZOR = :id";
        } elseif ($table == 'Evaluari') {
            $sql = "DELETE FROM Evaluari WHERE ID_EVALUARE = :id";
        } elseif ($table == 'Transportatori') {
            $sql = "DELETE FROM Transportatori WHERE ID_TRANSPORTATOR = :id";
        } elseif ($table == 'Materiale') {
            $sql = "DELETE FROM Materiale WHERE ID_MATERIAL = :id";
        } else {
            die("Tabel necunoscut!");
        }

        $stid = oci_parse($conn, $sql);
        oci_bind_by_name($stid, ':id', $id);

        $r = oci_execute($stid);
        if ($r) {
            oci_commit($conn);
            echo "<p>Ștergere realizată cu succes!</p>";
        } else {
            $e = oci_error($stid);
            echo "<p>Eroare la ștergere: " . htmlentities($e['message'], ENT_QUOTES) . "</p>";
        }

        oci_free_statement($stid);
        oci_close($conn);
    }
    ?>

<!-- Formular pentru ștergere angajat/client/comandă/furnizor/evaluare/material -->
<form action="delete.php" method="post" style="width: 200px; margin-top: 10px;">
    <label for="table">Selectați categoria:</label>
    <select name="table" id="table" style="width: 100%;">
        <option value="Angajati">Angajat</option>
        <option value="Clienti">Client</option>
        <option value="Comenzi">Comandă</option>
        <option value="Furnizori">Furnizor</option>
        <option value="Evaluari">Evaluare</option>
        <option value="Transportatori">Transportatori</option>
        <option value="Materiale">Material</option>
    </select>
    <br>
    <label for="id-delete">ID Angajat/Client/Comandă/Furnizor/Evaluare/Material/Transportator:</label>
    <input type="text" id="id-delete" name="id" required style="width: 100%;">
    <br>
    <input type="submit" value="Ștergere" style="width: 100%;">
</form>

</body>
</html>
