(function () {
    'use strict';

    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

document.getElementById('stackTraceForm').addEventListener('submit', function (event) {
    event.preventDefault();

    var form = event.target;

    if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
    }

    var formData = new FormData(form);
    var xhr = new XMLHttpRequest();
    xhr.open('POST', form.action, true);

    xhr.onload = function () {
        if (xhr.status === 200) {
            document.getElementById('parsedOutput').innerHTML = xhr.responseText;
        } else {
            alert('An error occurred while processing the stack trace.');
        }
    };

    xhr.send(formData);
});
