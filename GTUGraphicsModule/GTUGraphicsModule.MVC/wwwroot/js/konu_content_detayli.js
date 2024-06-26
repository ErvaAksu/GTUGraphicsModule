var barChartArrayKonu = [];
var selectedYearKonu;


// Function to export bar chart data to Excel
function exportChartToExcelKonu() {
    // Create a new workbook
    var wb = XLSX.utils.book_new();

    // Process bar chart data
    var barData = [{ "Yıl": selectedYearKonu }];
    barChartArrayKonu.forEach(function (barChart, index) {

        var barDataset = barChart.data.datasets[0];
  
        barDataset.data.forEach(function (value, i) {
            var barPoint = {
                Label: 'Bar Chart ' + (index + 1),
                Kod: barChart.data.labels[i],
                Değer: value
            };
            barData.push(barPoint);
        });
    });
    var barWS = XLSX.utils.json_to_sheet(barData);
    XLSX.utils.book_append_sheet(wb, barWS, "Bar Chart Data");

    var tableData = [{ "Yıl": selectedYearKonu }];
    barChartArrayKonu.forEach(function (barChart, index) {

        var barDataset = barChart.data.datasets[0];

        barDataset.performansGostergeleri.forEach(function (value, i) {
            for (j = 0; j < value.length; j++) {

                var tablePoint = {
                    Kod: barChart.data.labels[i],
                    Ad: value[j].ad,
                    Gerçekleşen: value[j].gerceklesen,
                    Hedeflenen: value[j].hedeflenen,
                    Oran: value[j].tekil_oran
                };
                tableData.push(tablePoint);

            }
            
        });
    });

    var tableWS = XLSX.utils.json_to_sheet(tableData);
    XLSX.utils.book_append_sheet(wb, tableWS, "Table Data");

    // Save the workbook as an Excel file
    var wbout = XLSX.write(wb, { bookType: 'xlsx', type: 'binary' });
    function s2ab(s) {
        var buf = new ArrayBuffer(s.length);
        var view = new Uint8Array(buf);
        for (var i = 0; i < s.length; i++) view[i] = s.charCodeAt(i) & 0xFF;
        return buf;
    }
    saveAs(new Blob([s2ab(wbout)], { type: "application/octet-stream" }), 'chart_data.xlsx');
}



function calculateKonuBarChartData(barData) {

    selectedYearKonu = parseInt(document.getElementById('year-select-konu').value);

    let sumMap = {};

    for (let i = 0; i < barData.PerformansGostergeleri.length; i++) {

        let id = barData.PerformansGostergeleri[i].kod;

        //let gerceklesen = barData.PerformansGostergeleri[i].gerceklesenDeger;
        let hedeflenen = barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.hedeflenen_deger;
        let gerceklesen;
        //let tekil_oran = (gerceklesen *100) / hedeflenen;

        let kod = barData.PerformansGostergeleri[i].kod;
        let tanim = barData.PerformansGostergeleri[i].tanim;

        let ad = barData.PerformansGostergeleri[i].ad;


        if (!sumMap[id]) {
            sumMap[id] = {
                gerceklesen_sum: 0,
                hedeflenen_sum: 0,
                kod: kod,
                tanim: tanim,
                performansgostergeList: []
            };

        }



        for (let j = 0; j < barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger.length; j++) {
            let year = barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].periyod;

            if (year == selectedYearKonu) {
                gerceklesen = barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].gerceklesen_deger;
                sumMap[id].gerceklesen_sum += gerceklesen;
            }

        }


        sumMap[id].hedeflenen_sum += hedeflenen;

        let tekil_oran = (gerceklesen * 100) / hedeflenen;

        sumMap[id].performansgostergeList.push({
            gerceklesen: gerceklesen,
            hedeflenen: hedeflenen,
            ad: ad,
            tekil_oran: tekil_oran
        });


    }

    let result = Object.keys(sumMap).map(function (id) {
        return {
            id: parseInt(id),
            oran: (sumMap[id].gerceklesen_sum * 100) / sumMap[id].hedeflenen_sum,
            kod: sumMap[id].kod,
            tanim: sumMap[id].tanim,
            performansgostergeList: sumMap[id].performansgostergeList
        };
    });

    return result;
}


function initializeKonuBarChart(canvasId, barData) {

    let result = calculateKonuBarChartData(barData);


    let data = {
        labels: [],
        datasets: [{
            data: [],
            backgroundColor: '#00BBA4',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1,
            maxBarThickness: 30,
            color: 'black',
            tanim: [],
            performansGostergeleri: []
        }]

    };

    for (let i = 0; i < result.length; i++) {

        data.labels.push(result[i].kod);
        data.datasets[0].data.push(result[i].oran);
        data.datasets[0].tanim.push(result[i].tanim);
        data.datasets[0].performansGostergeleri.push(result[i].performansgostergeList);

    }


    let ctx = document.getElementById('konu-bar-chart-' + canvasId).getContext('2d');

    let chart = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
            indexAxis: 'y',
            onClick: function (event, elements) {
                if (elements && elements.length > 0) {

                    let index = elements[0].index;
                    let clickedData = chart.data.datasets[0].performansGostergeleri[index];
                    let head = chart.data.datasets[0].tanim[index];
                    let kod = chart.data.labels[index];
                    updateTableRowsKonu(canvasId, clickedData, head, kod);

                }
            },
            scales: {
                x: {
                    min: 0,
                    max: 100,
                    beginAtZero: true
                }
            },
            plugins: {
                legend: {
                    display: false
                },
                tooltip: {
                    enable: false
                }
            },
            layout: {
                padding: {
                    top: 10,
                    bottom: 50
                }
            }

        }
    });

    barChartArrayKonu.push(chart);

    chart.update();

    let index = 0;
    let clickedData = chart.data.datasets[0].performansGostergeleri[index];
    let head = chart.data.datasets[0].tanim[index];
    let kod = chart.data.labels[index];
    updateTableRowsKonu(canvasId, clickedData, head, kod);


}


function updateKonuBarChart(canvasId, barData) {

    let result = calculateKonuBarChartData(barData);

    chartToUpdate = barChartArrayKonu[canvasId];

    console.log(chartToUpdate);

    chartToUpdate.data.datasets[0].data = [];
    chartToUpdate.data.labels = [];
    chartToUpdate.data.datasets[0].tanim = [];
    chartToUpdate.data.datasets[0].performansGostergeleri = [];
    chartToUpdate.update();

    for (let i = 0; i < result.length; i++) {

        chartToUpdate.data.labels.push(result[i].kod);
        chartToUpdate.data.datasets[0].data.push(result[i].oran);
        chartToUpdate.data.datasets[0].tanim.push(result[i].tanim);
        chartToUpdate.data.datasets[0].performansGostergeleri.push(result[i].performansgostergeList);

    }



    chartToUpdate.update();

    let index = 0;
    let clickedData = chartToUpdate.data.datasets[0].performansGostergeleri[index];
    let head = chartToUpdate.data.datasets[0].tanim[index];
    let kod = chartToUpdate.data.labels[index];
    updateTableRowsKonu(canvasId, clickedData, head, kod);



}


function initializeTableKonu(canvasxId, barData) {

    let ad = document.getElementById('ad-' + canvasxId);
    let gerceklesen = document.getElementById('g-' + canvasxId);
    let hedeflenen = document.getElementById('h-' + canvasxId);
    let oran = document.getElementById('oran-' + canvasxId);

    let g_val = barData.PerformansGostergeleri[canvasyId].gerceklesenDeger;
    let h_val = barData.PerformansGostergeleri[canvasyId].hedeflenenDeger;
    let oran_val = ((g_val * 100) / h_val).toFixed(2);

    ad.innerHTML = barData.PerformansGostergeleri[canvasyId].ad;
    gerceklesen.innerHTML = g_val;
    hedeflenen.innerHTML = h_val;
    oran.innerHTML = oran_val + ' %';

}


function updateTableRowsKonu(index, data, tanim, kod) {

    let tableCaption = document.getElementById('konu-table-heading-' + index);
    tableCaption.textContent = kod + ' - ' + tanim;

    let tableBody = document.getElementById('konu-table-body-' + index);
    tableBody.innerHTML = '';



    for (let i = 0; i < data.length; i++) {
        let performansGosterge = data[i];

        let row = tableBody.insertRow();

        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        let cell3 = row.insertCell(2);
        let cell4 = row.insertCell(3);

        cell1.innerHTML = performansGosterge.ad;
        cell2.innerHTML = performansGosterge.hedeflenen;
        cell3.innerHTML = performansGosterge.gerceklesen;
        cell4.innerHTML = performansGosterge.tekil_oran.toFixed(2);
    }

    let colorParts = document.querySelectorAll('.color-inner-selection-konu');

    updateColorsAndScalesKonu(index, colorParts);
}


function updateColorsAndScalesKonu(index, colorParts) {

    let tableBody = document.getElementById('konu-table-body-' + index);


    for (let i = 0; i < tableBody.rows.length; i++) {
        let row = tableBody.rows[i];
        let gerceklesmeOrani = parseFloat(row.cells[3].textContent);


        let color = getColorForThresholdKonu(gerceklesmeOrani, colorParts);

        if (color) {

            row.style.backgroundColor = color;
            row.style.color = getTextColorBasedOnBackgroundColorKonu(color);

        } else {

            row.style.backgroundColor = '';
            row.style.color = '';
        }
    }
}

function getColorForThresholdKonu(value, colorParts) {
    for (let i = 0; i < colorParts.length; i++) {
        let threshold = parseInt(colorParts[i].querySelector('.threshold').value, 10);
        let color = colorParts[i].querySelector('.color-part-konu input').value;

        if (!isNaN(threshold) && value < threshold) {
            return color;
        }
    }
    // If no match is found, return null
    return null;
}

// Function to determine text color based on background color
function getTextColorBasedOnBackgroundColorKonu(bgColor) {
    // Simple logic: if the background is dark, set text color to light, and vice versa
    let rgb = hexToRgbKonu(bgColor);
    let brightness = (rgb.r * 299 + rgb.g * 587 + rgb.b * 114) / 1000;
    return brightness > 128 ? 'black' : 'white';
}

// Function to convert hex color to RGB
function hexToRgbKonu(hex) {
    // Expand shorthand form (e.g., "03F") to full form (e.g., "0033FF")
    let shorthandRegex = /^#?([a-f\d])([a-f\d])([a-f\d])$/i;
    hex = hex.replace(shorthandRegex, function (m, r, g, b) {
        return r + r + g + g + b + b;
    });

    let result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}