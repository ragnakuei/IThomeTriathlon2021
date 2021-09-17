window.CustomFetch = {};
CustomFetch.PostJson = function (url, data) {
    return fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': Antiforgery.RequestVerificationToken
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .catch(error => console.log(error));
}
