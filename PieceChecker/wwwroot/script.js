let selectedColour = null;

document.addEventListener('DOMContentLoaded', async () => {
    const colourContainer = document.getElementById('colourContainer');
    const response = await fetch('/PieceChecker/colours');
    const colours = await response.json();

    colours.forEach(colour => {
        const div = document.createElement('div');
        div.className = 'colour-box';
        div.style.backgroundColor = `#${colour.rgbValue}`;
        div.textContent = colour.name;
        div.onclick = () => selectColour(div, colour.enumValue);
        colourContainer.appendChild(div);
    });
});

function selectColour(div, colour) {
    const currentlySelected = document.querySelector('.selected');
    if (currentlySelected) {
        currentlySelected.classList.remove('selected');
    }
    div.classList.add('selected');
    selectedColour = colour;
}

async function checkPiece() {
    const pieceId = document.getElementById('pieceId').value;
    const ignoreColour = false; // Adjust as needed or add UI element to change this

    const response = await fetch(`/PieceChecker/checkpiece?id=${pieceId}&colour=${selectedColour}&ignoreColour=${ignoreColour}`);
    const result = await response.text();
    document.getElementById('result').innerText = 'Result: ' + result;
}
