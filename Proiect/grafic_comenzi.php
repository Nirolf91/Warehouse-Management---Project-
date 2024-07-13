<?php
require 'config.php';
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Grafic Comenzi</title>
    <!-- Include biblioteca Chart.js -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>

<body>
    <<div id="graficComenzi" class="tab" style="width: 400px; height: 300px;">
    <h2>Grafic Comenzi</h2>
    <canvas id="chartComenzi"></canvas>
</div>


    <script>
        function afiseazaGraficComenzi() {
            var tipuriComenzi = [];
            var numarComenzi = [];

            <?php
            // Interogare SQL pentru a număra numărul de comenzi pentru fiecare tip
            $sql_numar_comenzi = "SELECT TIP_COMANDA, COUNT(*) AS NUMAR_COMENZI FROM Comenzi GROUP BY TIP_COMANDA";
            $stid_numar_comenzi = oci_parse($conn, $sql_numar_comenzi);
            oci_execute($stid_numar_comenzi);

            // Afișarea datelor pentru grafic
            while (($row_numar_comenzi = oci_fetch_assoc($stid_numar_comenzi)) != false) {
                echo "tipuriComenzi.push('" . htmlspecialchars($row_numar_comenzi['TIP_COMANDA'], ENT_QUOTES) . "');";
                echo "numarComenzi.push(" . $row_numar_comenzi['NUMAR_COMENZI'] . ");";
            }
            ?>

            var ctx = document.getElementById('chartComenzi').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: tipuriComenzi,
                    datasets: [{
                        label: 'Număr de Comenzi',
                        data: numarComenzi,
                        backgroundColor: 'rgba(54, 162, 235, 0.6)'
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }

        // Afișează graficul când se încarcă pagina
        window.onload = function() {
            afiseazaGraficComenzi(); // Afișează graficul comenzilor imediat ce pagina se încarcă
        };
    </script>

</body>

</html>
