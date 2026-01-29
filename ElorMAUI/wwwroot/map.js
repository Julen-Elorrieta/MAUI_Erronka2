window.createMap = (lat, lng, nombre) => {

    const map = L.map('map').setView([lat, lng], 16);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap'
    }).addTo(map);

    const marker = L.marker([lat, lng]).addTo(map);

    marker.bindPopup(`<strong>${nombre}</strong><br>Pulsa para más info`);

    marker.on('click', () => {
        DotNet.invokeMethodAsync('ElorMAUI', 'OnMarkerClicked');
    });
};
