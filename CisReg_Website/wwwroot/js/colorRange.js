// Função para definir o valor do range no localStorage
function setRangeValue(value) {
    localStorage.setItem('colorRangeValue', value);
}

// Função para obter o valor do range do localStorage
function getRangeValue() {
    return localStorage.getItem('colorRangeValue') || 100;
}

// Função para obter o valor em Hex do background
function getBackgroundColor(rangeValue) {
    const minColorValue = 247;
    const maxColorValue = 0;
    const colorValue = Math.round(
        maxColorValue + (rangeValue / 100) * (minColorValue - maxColorValue)
    );
    return `#${decimalToHex(colorValue)}${decimalToHex(colorValue)}${decimalToHex(colorValue)}`;
}


// Renderizar objeto (Range) na página.

const rangeBackground = document.getElementById('rangeBackground');
const mainContainer = document.getElementById('mainContainer');

function renderizeElements() {
    const actualPageWidth = window.innerWidth;
    const moonIcon = document.getElementById('moonIcon');
    const colorRange = document.getElementById('colorRange');
    const sunIcon = document.getElementById('sunIcon');
    const initialRangeValue = getRangeValue();

    mainContainer.style.backgroundColor = getBackgroundColor(initialRangeValue);

    if (actualPageWidth <= 1300) {
        if (moonIcon && colorRange && sunIcon) {
            moonIcon.remove();
            colorRange.remove();
            sunIcon.remove();

        }
    } else {
        if (!moonIcon && !colorRange && !sunIcon) {

            const newMoonIcon = document.createElement(`i`)
            newMoonIcon.id = 'moonIcon';
            newMoonIcon.classList.add('fa-solid', 'fa-moon', 'fa-xl', 'mr-2');
            newMoonIcon.style.color = '';

            const newColorRange = document.createElement(`input`);
            newColorRange.id = 'colorRange';
            newColorRange.type = 'range';
            newColorRange.min = '0';
            newColorRange.max = '100';
            newColorRange.value = getRangeValue();
            newColorRange.classList.add('w-full', 'range', 'range-xs');

            const newSunIcon = document.createElement(`i`)
            newSunIcon.id = 'sunIcon';
            newSunIcon.classList.add('fa-solid', 'fa-sun', 'fa-xl', 'ml-2');
            newSunIcon.style.color = '';

            rangeBackground.appendChild(newMoonIcon);
            rangeBackground.appendChild(newColorRange);
            rangeBackground.appendChild(newSunIcon);

            addColorRangeListener(newColorRange);
        } else {
            colorRange.value = initialRangeValue;
        }
    }

    changeBackgroundColor();
}


// Função para converter um valor decimal para Hex.
function decimalToHex(value) {
    const hex = value.toString(16);
    return hex.length === 1 ? '0' + hex : hex;
}


// Código para mudar o background (mainContainer) de acordo com o valor atual do range (colorRange)
function changeBackgroundColor() {
    const colorRange = document.getElementById('colorRange');
    const sunIcon = document.getElementById('sunIcon');
    const moonIcon = document.getElementById('moonIcon');

    if (colorRange) {
        const currentColorRangeValue = colorRange.value;

        mainContainer.style.backgroundColor = getBackgroundColor(currentColorRangeValue);

        if (currentColorRangeValue <= 45) {
            sunIcon.style.color = '#FFFFFF';
            moonIcon.style.color = '#FFFFFF';
        }
        else {
            sunIcon.style.color = '#000000';
            moonIcon.style.color = '#000000';
        }

    }
}
function addColorRangeListener(colorRange) {
    colorRange.addEventListener('input', function () {
        setRangeValue(colorRange.value);
        changeBackgroundColor();
    });

    window.addEventListener('resize', changeBackgroundColor);
}

const colorRange = document.getElementById('colorRange');
if (colorRange) {
    addColorRangeListener(colorRange);
}


window.addEventListener('resize', renderizeElements);

window.onload = function () {
    renderizeElements();
    requestAnimationFrame(changeBackgroundColor);
};