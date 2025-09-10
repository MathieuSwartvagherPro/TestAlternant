const apiUrl = window.location.origin.toLowerCase();

fetch(apiUrl + "/monUrl", {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
})
    .then((response) => response.json())
    .then((data) => {
        $('#maTable').DataTable({
            data: data,
            columns: [
                { data: "attribut1", title: "User" },
                { data: "attribut2", title: "Name" },

            ],
            pagelength: 50,
            lengthMenu: [50, 100],
        })
    });