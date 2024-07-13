<!DOCTYPE html>
<html lang="ro">
<head>
<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestionare unui depozit de materiale</title>
    <link rel="stylesheet" href="style.css">

   
</head>
<body>



    <h1>GESTIONARE DEPOZIT  MATERIALE</h1>
    
    <!-- Tab-uri pentru comutarea între secțiuni -->
    <button class="tab-button active" onclick="openTab('angajati')">Angajati</button>
    <button class="tab-button" onclick="openTab('clienti')">Clienti</button>
    <button class="tab-button" onclick="openTab('comenzi')">Comenzi</button>
    <button class="tab-button" onclick="openTab('furnizori')">Furnizori</button>
    <button class="tab-button" onclick="openTab('evaluari')">Evaluari</button>
    <button class="tab-button" onclick="openTab('materiale')">Materiale</button>
    <button class="tab-button" onclick="openTab('transportatori')">Transportatori</button>


    <!-- Container pentru butoanele deasupra tabelului -->
    <div class="button-container">
        <div id="angajati-buttons">
            <button onclick="window.location.href='update.php'">Update Angajat</button>
            <button onclick="window.location.href='delete.php'">Delete Angajat</button>
        </div>
        <div id="clienti-buttons" style="display: none;">
            <button onclick="window.location.href='update.php'">Update Client</button>
            <button onclick="window.location.href='delete.php'">Delete Client</button>
        </div>
        <div id="comenzi-buttons" class="button-container" style="display: none;">
        <button onclick="window.location.href='update.php'">Update Comanda</button>
        <button onclick="window.location.href='delete.php'">Delete Comanda</button>
        </div>
        <div id="furnizori-buttons" style="display: none;">
            <button onclick="window.location.href='update.php'">Update Furnizor</button>
            <button onclick="window.location.href='delete.php'">Delete Furnizor</button>
        </div>
        <div id="evaluari-buttons" style="display: none;">
            <button onclick="window.location.href='update.php'">Update Evaluare</button>
            <button onclick="window.location.href='delete.php'">Delete Evaluare</button>
        </div>
        <div id="transportatori-buttons" style="display: none;">
        <button onclick="window.location.href='update.php'">Update Transportator</button>
         <button onclick="window.location.href='delete.php'">Delete Transportator</button>
         </div>
         <div id="materiale-buttons" style="display: none;">
    <!-- Buton pentru actualizare -->
    <button onclick="window.location.href='update.php'">Update Material</button>
         <button onclick="window.location.href='delete.php'">Delete Material</button>
</div>
</div>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Căutare Angajați, Clienți, Comenzi, Furnizor, Evaluări,Materiale,Transportatori</title>
    <link rel="stylesheet" href="style.css"> <!-- Adaugă link-ul către fișierul CSS -->

</head>

<body>
    <h2>Căutare</h2>
    <!-- Câmp de selectare pentru a alege între căutarea angajaților, clienților, comenzilor, furnizorilor și evaluărilor -->
    <label for="select-tabel">Selectează tabel:</label>
    <select id="select-tabel" onchange="afiseazaCampuri()">
        <option value="angajati">Angajați</option>
        <option value="clienti">Clienți</option>
        <option value="comenzi">Comenzi</option>
        <option value="furnizori">Furnizori</option>
        <option value="evaluari">Evaluări</option>
        <option value="materiale">Materiale</option>
        <option value="transportatori">Transportatori</option>
    </select>

    <!-- Formular pentru căutarea angajaților -->
    <form id="form-angajati" action="filtrare_angajati.php" method="GET" style="display: none;">
        <label for="nume">Nume:</label>
        <input type="text" name="nume" id="nume"><br><br>
        
        <label for="functie">Funcție:</label>
        <input type="text" name="functie" id="functie"><br><br>
        
        <label for="data_contact">Data de Contact:</label>
        <input type="text" name="data_contact" id="data_contact"><br><br>
        
        <input type="submit" value="Caută">
    </form>

<!-- Formular pentru căutarea clienților -->
<form id="form-clienti" action="filtrare_clienti.php" method="GET" style="display: none;">
    <label for="nume_client">Nume:</label>
    <input type="text" name="nume_client" id="nume_client"><br><br>
    
    <label for="adresa">Adresă:</label>
    <input type="text" name="adresa" id="adresa"><br><br>
    
    <label for="contact">Contact:</label>
    <input type="text" name="contact" id="contact"><br><br>

    <label for="id_client_clienti">ID Client:</label>
    <input type="text" name="id_client" id="id_client_clienti"><br><br>

    <input type="submit" value="Caută">
</form>


 <!-- Formular pentru căutarea comenzilor -->
<form id="form-comenzi" action="filtrare_comenzi.php" method="GET" style="display: none;">
    <label for="id_comanda">ID Comandă:</label>
    <input type="text" name="id_comanda" id="id_comanda"><br><br>

    <label for="data_comenzii">Data Comenzii:</label>
    <input type="text" name="data_comenzii" id="data_comenzii"><br><br>

    <!-- Adăugăm câmpurile suplimentare -->
    <label for="id_client">ID Client:</label>
    <input type="text" name="id_client" id="id_client"><br><br>

    <label for="id_furnizor">ID Furnizor:</label>
    <input type="text" name="id_furnizor" id="id_furnizor"><br><br>

    <label for="id_angajat">ID Angajat:</label>
    <input type="text" name="id_angajat" id="id_angajat"><br><br>

    <label for="id_material">ID Material:</label>
    <input type="text" name="id_material" id="id_material"><br><br>

    <label for="total_comanda">Total Comandă:</label>
    <input type="text" name="total_comanda" id="total_comanda"><br><br>

    <label for="statut_comanda">Statut Comandă:</label>
    <input type="text" name="statut_comanda" id="statut_comanda"><br><br>

    <label for="tip_comanda">Tip Comandă:</label>
    <input type="text" name="tip_comanda" id="tip_comanda"><br><br>

    <label for="cantitate">Cantitate:</label>
    <input type="text" name="cantitate" id="cantitate"><br><br>

    <label for="pret_total">Preț Total:</label>
    <input type="text" name="pret_total" id="pret_total"><br><br>

    <label for="id_transportator">ID Transportator:</label>
    <input type="text" name="id_transportator" id="id_transportator"><br><br>

    <input type="submit" value="Caută">
</form>


   <!-- Formular pentru căutarea furnizorilor -->
<form id="form-furnizori" action="filtrare_furnizori.php" method="GET">
    <label for="id_furnizor">ID Furnizor:</label>
    <input type="text" name="id_furnizor" id="id_furnizor"><br><br>
    
    <label for="nume_furnizor">Nume:</label>
    <input type="text" name="nume_furnizor" id="nume_furnizor"><br><br>
    
    <label for="adresa">Adresă:</label>
    <input type="text" name="adresa" id="adresa"><br><br>
    
    <label for="contact">Contact:</label>
    <input type="text" name="contact" id="contact"><br><br>

    <input type="submit" value="Caută">
</form>

    <!-- Formular pentru căutarea evaluărilor -->
    <form id="form-evaluari" action="filtrare_evaluari.php" method="GET" style="display: none;">
    <label for="id_evaluare">ID Evaluare:</label>
    <input type="text" name="id_evaluare" id="id_evaluare"><br><br>

    <label for="id_client_evaluari">ID Client:</label>
    <input type="text" name="id_client" id="id_client_evaluari"><br><br>

    <label for="scor">Scor:</label>
    <input type="text" name="scor" id="scor"><br><br>

    <label for="feedback">Feedback:</label>
    <input type="text" name="feedback" id="feedback"><br><br>

    <label for="data_evaluarii">Data Evaluării:</label>
    <input type="text" name="data_evaluarii" id="data_evaluarii"><br><br>

    <input type="submit" value="Caută">
</form>


<!-- Formular pentru căutarea materialelor -->
<form id="form-materiale" action="filtrare_materiale.php" method="GET" style="display: none;">
    <label for="id_material">ID Material:</label>
    <input type="text" name="id_material" id="id_material"><br><br>
    
    <label for="nume">Nume:</label>
    <input type="text" name="nume" id="nume"><br><br>
    
    <label for="descriere">Descriere:</label>
    <input type="text" name="descriere" id="descriere"><br><br>
    
    <label for="cantitate_in_stoc">Cantitate în stoc:</label>
    <input type="text" name="cantitate_in_stoc" id="cantitate_in_stoc"><br><br>
    
    <label for="pret_unitar">Preț unitar:</label>
    <input type="text" name="pret_unitar" id="pret_unitar"><br><br>
    
    <label for="id_furnizor">ID Furnizor:</label>
    <input type="text" name="id_furnizor" id="id_furnizor"><br><br>
    
    <input type="submit" value="Caută">
</form>
    
   <!-- Formular pentru căutarea transportatorilor -->
<div id="form-transportatori" style="display: none;">
    <form action="filtrare_transportatori.php" method="GET">
        <label for="id_transportator">ID Transportator:</label>
        <input type="text" name="id_transportator" id="id_transportator"><br><br>
        
        <label for="nume_transportator">Nume:</label>
        <input type="text" name="nume_transportator" id="nume_transportator"><br><br>
        
        <label for="contact_transportator">Contact:</label>
        <input type="text" name="contact_transportator" id="contact_transportator"><br><br>

        <label for="pret_pe_kg">Preț pe KG:</label>
        <input type="text" name="pret_pe_kg" id="pret_pe_kg"><br><br>

        <input type="submit" value="Caută">
    </form>
</div>



    <!-- Script JavaScript -->
    <script>
    // Funcție pentru afișarea formularului specific tabelului selectat
    function afiseazaCampuri() {
        var selectBox = document.getElementById("select-tabel");
        var selectedValue = selectBox.options[selectBox.selectedIndex].value;

        // Ascunde toate form-urile
        document.getElementById("form-angajati").style.display = "none";
        document.getElementById("form-clienti").style.display = "none";
        document.getElementById("form-comenzi").style.display = "none";
        document.getElementById("form-furnizori").style.display = "none";
        document.getElementById("form-evaluari").style.display = "none";
        document.getElementById("form-materiale").style.display = "none"; // Ascunde formularul pentru materiale
        document.getElementById("form-transportatori").style.display = "none";
      

        // Afișează formularul corespunzător tabelului selectat
        if (selectedValue === "angajati") {
            document.getElementById("form-angajati").style.display = "block";
        } else if (selectedValue === "clienti") {
            document.getElementById("form-clienti").style.display = "block";
        } else if (selectedValue === "comenzi") {
            document.getElementById("form-comenzi").style.display = "block";
        } else if (selectedValue === "furnizori") {
            document.getElementById("form-furnizori").style.display = "block";
        } else if (selectedValue === "evaluari") {
            document.getElementById("form-evaluari").style.display = "block";
        }else if (selectedValue === "materiale") { // Afiseaza formularul pentru materiale
            document.getElementById("form-materiale").style.display = "block";
        } else if (selectedValue === "transportatori") {
            document.getElementById("form-transportatori").style.display = "block";
        } 
    }

    // Apelează funcția pentru a afișa formularul corespunzător la încărcarea paginii
    document.addEventListener('DOMContentLoaded', afiseazaCampuri);
</script>

</body>
<div class="search-container">
    <!-- Formular pentru căutarea angajaților -->
    <form id="form-angajati" action="filtrare_angajati.php" method="GET" style="display: none;">
        <!-- Câmpuri pentru căutarea angajaților -->
    </form>

    <!-- Container pentru imagine -->
    <div class="image-container">
        <!-- Imaginea -->
        <img src="imagini/warehouse.jpg" alt="Imaginea cu locația specificată">
    </div>
</div>


</html>


    </div>

    <!-- Formular pentru inserare angajat -->
    <div id="formular-angajat">
        <h2>Inserare Angajat</h2>
        <form action="insert.php" method="post">
            <label for="nume">Nume:</label>
            <input type="text" id="nume" name="nume">
            <br>
            <label for="functie">Funcție:</label>
            <input type="text" id="functie" name="functie">
            <br>
            <label for="contact">Date de Contact:</label>
            <input type="text" id="contact" name="contact">
            <br>
            <input type="submit" value="Inserare">
        </form>
    </div>

    <!-- Formular pentru inserare client -->
    <div id="formular-clienti" class="tab">
        <h2>Inserare Client</h2>
        <form action="insert.php" method="post">
            <label for="nume_client">Nume:</label>
            <input type="text" id="nume_client" name="nume_client">
            <br>
            <label for="adresa_client">Adresă:</label>
            <input type="text" id="adresa_client" name="adresa_client">
            <br>
            <label for="contact_client">Contact:</label>
            <input type="text" id="contact_client" name="contact_client">
            <br>
            <input type="submit" value="Inserare">
        </form>
    </div>

<!-- Formular pentru inserare comanda -->
    <div id="formular-comenzi" class="tab">
        <h2>Inserare Comandă</h2>
        <form action="insert.php" method="post">
            <label for="data_comenzii">Data Comenzii:</label>
            <input type="date" id="data_comenzii" name="data_comenzii">
            <br>
            <label for="id_client">ID Client:</label>
            <input type="number" id="id_client" name="id_client">
            <br>
            <label for="id_furnizor">ID Furnizor:</label>
            <input type="number" id="id_furnizor" name="id_furnizor">
            <br>
            <label for="id_angajat">ID Angajat:</label>
            <input type="number" id="id_angajat" name="id_angajat">
            <br>
            <label for="id_material">ID Material:</label>
            <input type="number" id="id_material" name="id_material">
            <br>
            <label for="total_comanda">Total Comandă:</label>
            <input type="number" step="0.01" id="total_comanda" name="total_comanda">
            <br>
            <label for="statut_comanda">Statut Comandă:</label>
            <input type="text" id="statut_comanda" name="statut_comanda">
            <br>
            <label for="tip_comanda">Tip Comandă:</label>
            <input type="text" id="tip_comanda" name="tip_comanda">
            <br>
            <label for="cantitate">Cantitate:</label>
            <input type="number" id="cantitate" name="cantitate">
            <br>
            <label for="pret_total">Preț Total:</label>
            <input type="number" step="0.01" id="pret_total" name="pret_total">
            <br>
            <label for="id_transportator">ID Transportator:</label>
            <input type="number" id="id_transportator" name="id_transportator">
            <br>
            <input type="submit" value="Inserare">
        </form>
    </div>
<!-- Formular pentru inserare furnizori -->
    <div id="formular-furnizori" class="tab">
        <h2>Inserare Furnizor</h2>
        <form action="insert.php" method="post">
            <label for="nume_furnizor">Nume:</label>
            <input type="text" id="nume_furnizor" name="nume_furnizor"><br>
            <label for="adresa_furnizor">Adresă:</label>
            <input type="text" id="adresa_furnizor" name="adresa_furnizor"><br>
            <label for="contact_furnizor">Contact:</label>
            <input type="text" id="contact_furnizor" name="contact_furnizor"><br>
            <input type="submit" value="Inserare">
        </form>
    </div>


 <!-- Formular pentru inserare evaluare -->
<div id="formular-evaluari" class="tab">
    <h2>Inserare Evaluare</h2>
    <form action="insert.php" method="post">
        <label for="id_client">ID Client:</label>
        <input type="number" id="id_client" name="id_client"><br>
        <label for="scor">Scor:</label>
        <input type="number" step="0.01" id="scor" name="scor"><br>
        <label for="feedback">Feedback:</label>
        <input type="text" id="feedback" name="feedback"><br>
        <label for="data_evaluarii">Data Evaluarii:</label>
        <input type="date" id="data_evaluarii" name="data_evaluarii"><br>
        <input type="submit" value="Inserare">
    </form>
</div>


<!-- Formular pentru inserarea materialelor -->
<div id="formular-materiale">
    <h2>Inserare Material</h2>
    <form action="insert.php" method="post">
         <br>
        <label for="nume">Nume:</label>
        <input type="text" id="nume" name="nume">
        <br>
        <label for="descriere">Descriere:</label>
        <input type="text" id="descriere" name="descriere">
        <br>
        <label for="cantitate_in_stoc">Cantitate în stoc:</label>
        <input type="text" id="cantitate_in_stoc" name="cantitate_in_stoc">
        <br>
        <label for="pret_unitar">Preț unitar:</label>
        <input type="text" id="pret_unitar" name="pret_unitar">
        <br>
        <label for="id_furnizor">ID Furnizor:</label>
        <input type="text" id="id_furnizor" name="id_furnizor">
        <br>
        <input type="submit" value="Inserare">
    </form>
</div>



<!-- Formular pentru inserare transportator -->
<div id="formular-transportatori" class="tab">
    <h2>Inserare Transportator</h2>
    <form action="insert.php" method="post">
        <label for="nume">Nume:</label>
        <input type="text" id="nume" name="nume"><br>
        <label for="contact">Contact:</label>
        <input type="text" id="contact" name="contact"><br>
        <label for="pret_pe_kg">Preț pe KG:</label>
        <input type="number" step="0.01" id="pret_pe_kg" name="pret_pe_kg"><br>
        <input type="submit" value="Inserare">
    </form>
</div>



<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Export</title>
    <link rel="stylesheet" href="style.css"> <!-- Aici se face legătura cu fișierul CSS -->

</head>
<body>
    <h2>Export Data</h2>
    <form action="export.php" method="get">
        <label for="table">Selectează tabela pentru export:</label>
        <select name="table" id="table">
            <option value="angajati">Angajati</option>
            <option value="clienti">Clienti</option>
            <option value="comenzi">Comenzi</option>
            <option value="furnizori">Furnizori</option>
            <option value="evaluari">Evaluari</option>
            <option value="evaluari">Materiale</option>
            <option value="transportatori">Transportatori</option>
        </select>
        <!-- Butonul "Export" -->
        <button id="export-button" type="submit">Export</button>
        <button id="export-button" type="submit">Import</button>
    </form>
</body>
</html>




  <!-- Secțiunea pentru angajați -->
<div id="angajati" class="tab" style="display: block;">
    <!-- Lista angajaților -->
    <h2>Lista Angajaților</h2>
    <table id="angajatiTable">
        <thead>
            <tr>
                <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Angajat</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(1)">Nume</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(2)">Funcție</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(3)">Date de Contact</a></th>
            </tr>
        </thead>
        <tbody>
            <?php
            require 'config.php';

            // Interogare SQL pentru a selecta angajații
            $sql = "SELECT * FROM Angajati";
            $stid = oci_parse($conn, $sql);
            oci_execute($stid);

            // Afișarea datelor din fiecare rând
            while (($row = oci_fetch_assoc($stid)) != false) {
                echo "<tr>
                        <td>" . htmlspecialchars($row['ID_ANGAJAT'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row['NUME'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row['FUNCTIE'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row['DATE_DE_CONTACT'], ENT_QUOTES) . "</td>
                    </tr>";
            }
            ?>
        </tbody>
        <!-- Butonul pentru deschiderea graficului pentru angajați -->
<button onclick="openChartPage()">Afiseaza Grafic</button>

<script>
    // Funcție pentru deschiderea fișierului cu graficul pentru angajați într-o fereastră nouă
    function openChartPage() {
        window.open('grafic.php', '_blank', 'width=600,height=400');
    }
</script>
    </table>

</div>
        


    <!-- Secțiunea pentru clienți -->
    <div id="clienti" class="tab">
        <!-- Lista clienților -->
        <h2>Lista Clienților</h2>
        <table id="clientiTable">
            <thead>
                <tr>
                    <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Client</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(1)">Nume</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(2)">Adresa</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(3)">Contact</a></th>
                </tr>
            </thead>
            <tbody>
                <?php
                require 'config.php';

                // Interogare SQL pentru a selecta clienții
                $sql_clienti = "SELECT * FROM Clienti";
                $stid_clienti = oci_parse($conn, $sql_clienti);
                oci_execute($stid_clienti);

                // Afișarea datelor din fiecare rând
                while (($row_clienti = oci_fetch_assoc($stid_clienti)) != false) {
                    echo "<tr>
                            <td>" . htmlspecialchars($row_clienti['ID_CLIENT'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_clienti['NUME'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_clienti['ADRESA'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_clienti['CONTACT'], ENT_QUOTES) . "</td>
                        </tr>";
                }
                ?>
            </tbody>
        </table>
    </div>
 
    <head>
    <link rel="stylesheet" href="style.css">
</head>


    <!-- Secțiunea pentru comenzi -->
 <div id="comenzi" class="tab">
        <!-- Buton pentru afișarea graficului -->

        <!-- Lista comenzilor -->
        <h2>Lista Comenzilor</h2>
        <table id="comenziTable">
            <thead>
                <tr>
                    <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Comandă</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(1)">Data Comenzii</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(2)">ID Client</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(3)">ID Furnizor</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(4)">ID Angajat</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(5)">ID Material</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(6)">Total Comandă</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(7)">Statut Comandă</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(8)">Tip Comandă</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(9)">Cantitate</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(10)">Preț Total</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(11)">ID Transportator</a></th>
                </tr>
            </thead>
            <tbody>
                <?php
                require 'config.php';

                // Interogare SQL pentru a selecta comenzile
                $sql_comenzi = "SELECT * FROM Comenzi";
                $stid_comenzi = oci_parse($conn, $sql_comenzi);
                oci_execute($stid_comenzi);

                // Afișarea datelor din fiecare rând
                while (($row_comenzi = oci_fetch_assoc($stid_comenzi)) != false) {
                    echo "<tr>
                            <td>" . htmlspecialchars($row_comenzi['ID_COMANDA'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['DATA_COMENZII'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['ID_CLIENT'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['ID_FURNIZOR'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['ID_ANGAJAT'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['ID_MATERIAL'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['TOTAL_COMANDA'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['STATUT_COMANDA'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['TIP_COMANDA'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['CANTITATE'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['PRET_TOTAL'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row_comenzi['ID_TRANSPORTATOR'], ENT_QUOTES) . "</td>
                        </tr>";
                }
                ?>
            </tbody>
            <button onclick="openChart()">Afiseaza Grafic</button>

<script>
    // Funcție pentru deschiderea fișierului cu graficul pentru angajați într-o fereastră nouă
    function openChart() {
        window.open('grafic_comenzi.php', '_blank', 'width=600,height=400');
    }
</script>

        </table>
    
</div>


    <!-- Secțiunea pentru furnizori -->
    <div id="furnizori" class="tab">
        <h2>Lista Furnizorilor</h2>
        <table id="furnizoriTable">
            <thead>
                <tr>
                    <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Furnizor</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(1)">Nume</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(2)">Adresă</a></th>
                    <th><a href="javascript:void(0)" onclick="sortTable(3)">Contact</a></th>
                </tr>
            </thead>
            <tbody>
                <?php
                $sql = "SELECT * FROM Furnizori";
                $stid = oci_parse($conn, $sql);
                oci_execute($stid);
                while (($row = oci_fetch_assoc($stid)) != false) {
                    echo "<tr>
                            <td>" . htmlspecialchars($row['ID_FURNIZOR'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row['NUME'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row['ADRESA'], ENT_QUOTES) . "</td>
                            <td>" . htmlspecialchars($row['CONTACT'], ENT_QUOTES) . "</td>
                        </tr>";
                }
                ?>
            </tbody>
        </table>
    </div>

 <!-- Secțiunea pentru evaluari -->
<div id="evaluari" class="tab">


    <!-- Lista evaluarilor -->
    <h2>Lista Evaluarilor</h2>
    <table id="evaluariTable">
        <thead>
            <tr>
                <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Evaluare</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(1)">ID Client</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(2)">Scor</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(3)">Feedback</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(4)">Data Evaluare</a></th>
            </tr>
        </thead>
        <tbody>
            <?php
            require 'config.php';

            // Interogare SQL pentru a selecta evaluarile
            $sql_evaluari = "SELECT * FROM Evaluari";
            $stid_evaluare = oci_parse($conn, $sql_evaluari);
            oci_execute($stid_evaluare);

            // Afișarea datelor din fiecare rând
            while (($row_evaluare = oci_fetch_assoc($stid_evaluare)) != false) {
                echo "<tr>
                        <td>" . htmlspecialchars($row_evaluare['ID_EVALUARE'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_evaluare['ID_CLIENT'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_evaluare['SCOR'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_evaluare['FEEDBACK'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_evaluare['DATA_EVALUARII'], ENT_QUOTES) . "</td>
                    </tr>";
            }
            ?>
        </tbody>

        <button onclick="openChartEvaluari()">Afiseaza Grafic</button>

<script>
    // Funcție pentru deschiderea fișierului cu graficul pentru angajați într-o fereastră nouă
    function openChartEvaluari() {
        window.open('grafic_evaluari.php', '_blank', 'width=600,height=400');
    }
</script>

        </table>
    
</div>
  


<!-- Secțiunea pentru materiale -->
<div id="materiale" class="tab">
    <!-- Lista materialelor -->
    <h2>Lista Materialelor</h2>
    <table id="materialeTable">
        <thead>
            <tr>
                <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Material</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(1)">Nume</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(2)">Descriere</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(3)">Cantitate în Stoc</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(4)">Pret Unitar</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(5)">ID Furnizor</a></th>
            </tr>
        </thead>
        <tbody>
            <?php
            require 'config.php';

            // Interogare SQL pentru a selecta materialele
            $sql_materiale = "SELECT * FROM Materiale";
            $stid_materiale = oci_parse($conn, $sql_materiale);
            oci_execute($stid_materiale);

            // Afișarea datelor din fiecare rând
            while (($row_materiale = oci_fetch_assoc($stid_materiale)) != false) {
                echo "<tr>
                        <td>" . htmlspecialchars($row_materiale['ID_MATERIAL'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_materiale['NUME'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_materiale['DESCRIERE'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_materiale['CANTITATE_IN_STOC'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_materiale['PRET_UNITAR'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_materiale['ID_FURNIZOR'], ENT_QUOTES) . "</td>
                    </tr>";
            }
            ?>
        </tbody>
    </table>
</div>




<!-- Secțiunea pentru transportatori -->
<div id="transportatori" class="tab">
    <h2>Lista Transportatorilor</h2>
    <table id="transportatoriTable">
        <thead>
            <tr>
                <th><a href="javascript:void(0)" onclick="sortTable(0)">ID Transportator</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(1)">Nume</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(2)">Contact</a></th>
                <th><a href="javascript:void(0)" onclick="sortTable(3)">Preț pe KG</a></th>
            </tr>
        </thead>
        <tbody>
            <?php
            require 'config.php';

            // Interogare SQL pentru a selecta transportatorii
            $sql_transportatori = "SELECT * FROM Transportatori";
            $stid_transportatori = oci_parse($conn, $sql_transportatori);
            oci_execute($stid_transportatori);

            // Afișarea datelor din fiecare rând
            while (($row_transportatori = oci_fetch_assoc($stid_transportatori)) != false) {
                echo "<tr>
                        <td>" . htmlspecialchars($row_transportatori['ID_TRANSPORTATOR'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_transportatori['NUME'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_transportatori['CONTACT'], ENT_QUOTES) . "</td>
                        <td>" . htmlspecialchars($row_transportatori['PRET_PE_KG'], ENT_QUOTES) . "</td>
                    </tr>";
            }
            ?>
        </tbody>
    </table>
</div>
    

    <!-- JavaScript pentru comutarea tab-urilor și sortarea tabelului -->
    <script>
      function openTab(tabName) {
    var i;
    var tabs = document.getElementsByClassName("tab");
    for (i = 0; i < tabs.length; i++) {
        tabs[i].style.display = "none";
    }
    
    var tabButtons = document.getElementsByClassName("tab-button");
    for (i = 0; i < tabButtons.length; i++) {
        tabButtons[i].classList.remove("active");
    }
    
    document.getElementById(tabName).style.display = "block";
    event.currentTarget.classList.add('active');

      // Ascunde toate butoanele specifice tabului 'transportatori'
      document.getElementById('transportatori-buttons').style.display = 'none';
    // Afiseaza formularul si butoanele corespunzatoare tabului
    if (tabName === 'clienti') {
    // Afiseaza formularul si butoanele corespunzatoare tabului 'clienti'
    document.getElementById('formular-clienti').style.display = 'block';
    document.getElementById('formular-angajat').style.display = 'none';
    document.getElementById('formular-comenzi').style.display = 'none';
    document.getElementById('formular-furnizori').style.display = 'none';
    document.getElementById('formular-evaluari').style.display = 'none';
    document.getElementById('formular-materiale').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'none';
    document.getElementById('clienti-buttons').style.display = 'block';
    document.getElementById('comenzi-buttons').style.display = 'none';
    document.getElementById('furnizori-buttons').style.display = 'none';
    document.getElementById('evaluari-buttons').style.display = 'none';
} else if (tabName === 'comenzi') {
    // Afiseaza formularul si butoanele corespunzatoare tabului 'comenzi'
    document.getElementById('formular-comenzi').style.display = 'block';
    document.getElementById('formular-angajat').style.display = 'none';
    document.getElementById('formular-clienti').style.display = 'none';
    document.getElementById('formular-furnizori').style.display = 'none';
    document.getElementById('formular-evaluari').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'none';
    document.getElementById('clienti-buttons').style.display = 'none';
    document.getElementById('comenzi-buttons').style.display = 'block';
    document.getElementById('furnizori-buttons').style.display = 'none';
    document.getElementById('evaluari-buttons').style.display = 'none';
} else if (tabName === 'furnizori') {
    // Afiseaza formularul si butoanele corespunzatoare tabului 'furnizori'
    document.getElementById('formular-furnizori').style.display = 'block';
    document.getElementById('formular-angajat').style.display = 'none';
    document.getElementById('formular-clienti').style.display = 'none';
    document.getElementById('formular-comenzi').style.display = 'none';
    document.getElementById('formular-evaluari').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'none';
    document.getElementById('clienti-buttons').style.display = 'none';
    document.getElementById('comenzi-buttons').style.display = 'none';
    document.getElementById('furnizori-buttons').style.display = 'block';
    document.getElementById('evaluari-buttons').style.display = 'none';
} else if (tabName === 'evaluari') {
    // Afiseaza formularul si butoanele corespunzatoare tabului 'evaluari'
    document.getElementById('formular-evaluari').style.display = 'block';
    document.getElementById('formular-angajat').style.display = 'none';
    document.getElementById('formular-clienti').style.display = 'none';
    document.getElementById('formular-comenzi').style.display = 'none';
    document.getElementById('formular-furnizori').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'none';
    document.getElementById('clienti-buttons').style.display = 'none';
    document.getElementById('comenzi-buttons').style.display = 'none';
    document.getElementById('furnizori-buttons').style.display = 'none';
    document.getElementById('evaluari-buttons').style.display = 'block';
} else if (tabName === 'materiale') {
    // Afiseaza formularul si butoanele corespunzatoare tabului 'materiale'
    document.getElementById('formular-materiale').style.display = 'block';
    document.getElementById('formular-angajat').style.display = 'none';
    document.getElementById('formular-clienti').style.display = 'none';
    document.getElementById('formular-comenzi').style.display = 'none';
    document.getElementById('formular-furnizori').style.display = 'none';
    document.getElementById('formular-evaluari').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'none';
    document.getElementById('clienti-buttons').style.display = 'none';
    document.getElementById('comenzi-buttons').style.display = 'none';
    document.getElementById('furnizori-buttons').style.display = 'none';
    document.getElementById('evaluari-buttons').style.display = 'none';
    document.getElementById('materiale-buttons').style.display = 'block';
}


else if (tabName === 'transportatori') {
    // Afiseaza formularul si butoanele corespunzatoare tabului 'transportatori'
    document.getElementById('formular-transportatori').style.display = 'block';
    document.getElementById('formular-angajat').style.display = 'none';
    document.getElementById('formular-clienti').style.display = 'none';
    document.getElementById('formular-comenzi').style.display = 'none';
    document.getElementById('formular-furnizori').style.display = 'none';
    document.getElementById('formular-evaluari').style.display = 'none';
    document.getElementById('formular-materiale').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'none';
    document.getElementById('clienti-buttons').style.display = 'none';
    document.getElementById('comenzi-buttons').style.display = 'none';
    document.getElementById('furnizori-buttons').style.display = 'none';
    document.getElementById('evaluari-buttons').style.display = 'none';
    document.getElementById('materiale-buttons').style.display = 'none';
    document.getElementById('transportatori-buttons').style.display = 'block';
}  else {
    // Afiseaza formularul pentru angajat si ascunde restul
    document.getElementById('formular-angajat').style.display = 'block';
    document.getElementById('formular-clienti').style.display = 'none';
    document.getElementById('formular-comenzi').style.display = 'none';
    document.getElementById('formular-furnizori').style.display = 'none';
    document.getElementById('formular-evaluari').style.display = 'none';
    document.getElementById('angajati-buttons').style.display = 'block';
    document.getElementById('clienti-buttons').style.display = 'none';
    document.getElementById('comenzi-buttons').style.display = 'none';
    document.getElementById('furnizori-buttons').style.display = 'none';
    document.getElementById('evaluari-buttons').style.display = 'none';
}
}



// Sortare Initialize directions object to store the sort direction for each column index
var directions = {};

function showTab(tabId) {
    var tabs = document.querySelectorAll('.tab');
    tabs.forEach(tab => {
        tab.style.display = 'none';
    });

    var activeTab = document.getElementById(tabId);
    if (activeTab) {
        activeTab.style.display = 'block';
    }
}

function sortTable(columnIndex) {
    var table, rows, switching, i, x, y, shouldSwitch, xContent, yContent, isNumber;
    table = document.querySelector('.tab:not([style*="display: none"]) table');
    switching = true;
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[columnIndex];
            y = rows[i + 1].getElementsByTagName("TD")[columnIndex];
            xContent = x.innerHTML.toLowerCase();
            yContent = y.innerHTML.toLowerCase();

            // Determine if the column is numeric or text
            isNumber = !isNaN(xContent) && !isNaN(yContent);

            if (isNumber) {
                // Compare as numbers
                if (parseFloat(xContent) > parseFloat(yContent)) {
                    shouldSwitch = true;
                    break;
                }
            } else {
                // Compare as text
                if (xContent > yContent) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}

function exportData(tabName) {
    window.location.href = 'export.php?table=' + tabName;
}



</script>

</body>
</html>