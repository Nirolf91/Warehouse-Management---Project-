<?php
// Include configurația și începe o sesiune
require 'config.php';
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Grafic Angajați</title>
    <!-- Include biblioteca Chart.js -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>

<body>
    <div style="width: 400px; margin: 20px auto;">
        <!-- Canvas pentru graficul pie chart -->
        <canvas id="chartAngajati"></canvas>
    </div>

    <script>
        // Funcția pentru afișarea graficului
        function afiseazaGraficAngajati() {
            // Datele pentru grafic
            var functii = [];
            var numarAngajati = [];

            <?php
            // Interogare SQL pentru a număra numărul de angajați pentru fiecare funcție
            $sql = "SELECT FUNCTIE, COUNT(*) AS NUMAR_ANGAJATI FROM Angajati GROUP BY FUNCTIE";
            $stid = oci_parse($conn, $sql);
            oci_execute($stid);

            // Afișarea datelor pentru grafic
            while (($row = oci_fetch_assoc($stid)) != false) {
                echo "functii.push('" . htmlspecialchars($row['FUNCTIE'], ENT_QUOTES) . "');";
                echo "numarAngajati.push(" . $row['NUMAR_ANGAJATI'] . ");";
            }
            ?>

            // Desenarea graficului
            var ctx = document.getElementById('chartAngajati').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: functii,
                    datasets: [{
                        label: 'Pondere Funcții Angajați',
                        data: numarAngajati,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.6)',
                            'rgba(54, 162, 235, 0.6)',
                            'rgba(255, 206, 86, 0.6)',
                            'rgba(75, 192, 192, 0.6)',
                            'rgba(153, 102, 255, 0.6)',
                            'rgba(255, 159, 64, 0.6)'
                        ]
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: 'Pondere Funcții Angajați'
                    },
                    legend: {
                        display: true,
                        position: 'bottom'
                    }
                }
            });
        }

        // Afișează graficul când se încarcă pagina
        window.onload = function() {
            afiseazaGraficAngajati();
        };
    </script>
    
</body>

</html>
