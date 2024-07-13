function openTab(tabName) {
    var i;
    var x = document.getElementsByClassName("tab");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    var tabButtons = document.getElementsByClassName("tab-button");
    for (i = 0; i < tabButtons.length; i++) {
        tabButtons[i].classList.remove("active");
    }
    document.getElementById(tabName).style.display = "block";
    var activeTab = document.querySelector('.active');
    if (activeTab) {
        activeTab.classList.remove('active');
    }
    event.currentTarget.classList.add('active');
}

// Variabilă globală pentru a ține evidența direcției sortării
var direction = 1; // 1 pentru sortare ascendentă, -1 pentru sortare descendentă

function sortTable(columnIndex) {
    var table, rows, switching, i, x, y, shouldSwitch;
    var currentTab = document.querySelector('.tab[style*="display: block"]');
    table = currentTab.querySelector('table');
    switching = true;
    // Verificăm direcția sortării și actualizăm variabila direction
    direction *= -1;

    while (switching) {
        switching = false;
        rows = table.rows;

        // Parcurgem toate rândurile, cu excepția primului (capul de tabel)
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            // Obținem valorile celulelor pentru două rânduri consecutive
            x = rows[i].getElementsByTagName("TD")[columnIndex];
            y = rows[i + 1].getElementsByTagName("TD")[columnIndex];
            // Verificăm dacă trebuie să facem schimb de poziții
            if (direction === 1) {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (direction === -1) {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            // Schimbăm pozițiile rândurilor și marcăm că am făcut o schimbare
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}

document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Evită comportamentul implicit de trimitere a formularului

    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    // Verifică dacă utilizatorul și parola sunt corecte
    if (username === 'florin.dudu' && password === 'Nirolf') {
        // Ascunde formularul de logare și afișează conținutul interfeței
        document.getElementById('loginForm').style.display = 'none';
        document.getElementById('loggedInContent').style.display = 'block';
        document.getElementById('message').innerText = ''; // Șterge mesajul de eroare (dacă există)
    } else {
        document.getElementById('message').innerText = 'Utilizator sau parolă incorectă!';
    }
});

function showPassword() {
    var passwordInput = document.getElementById('password');
    if (passwordInput.type === 'password') {
        passwordInput.type = 'text';
    } else {
        passwordInput.type = 'password';
    }
}

