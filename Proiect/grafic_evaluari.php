<?php
require 'config.php';
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Grafic Evaluări</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>

<body>
    <canvas id="chartEvaluari" width="800" height="400"></canvas>

    <script>
        function afiseazaGraficEvaluari() {
            var idEvaluare = [];
            var scor = [];
            var feedback = [];

            <?php
            $sql_evaluari = "SELECT * FROM Evaluari";
            $stid_evaluare = oci_parse($conn, $sql_evaluari);
            oci_execute($stid_evaluare);

            while (($row_evaluare = oci_fetch_assoc($stid_evaluare)) != false) {
                echo "idEvaluare.push('" . $row_evaluare['ID_EVALUARE'] . "');";
                echo "scor.push('" . $row_evaluare['SCOR'] . "');";
                echo "feedback.push('" . $row_evaluare['FEEDBACK'] . "');";
            }
            ?>

            var ctx = document.getElementById('chartEvaluari').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: idEvaluare,
                    datasets: [{
                        label: 'Scor Evaluare',
                        data: scor,
                        backgroundColor: 'rgba(54, 162, 235, 0.6)'
                    }]
                },
                options: {
                    scales: {
                        xAxes: [{
                            scaleLabel: {
                                display: true,
                                labelString: 'ID Evaluare'
                            }
                        }],
                        yAxes: [{
                            scaleLabel: {
                                display: true,
                                labelString: 'Scor'
                            },
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    title: {
                        display: true,
                        text: 'Evoluția Scorului pentru Evaluări'
                    }
                }
            });
        }

        window.onload = function() {
            afiseazaGraficEvaluari();
        };
    </script>

</body>

</html>
