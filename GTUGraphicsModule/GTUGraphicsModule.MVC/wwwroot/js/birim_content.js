// birim_content.js
// stratejik plan performansı birim kısmında kullanılan js fonksiyonları

// Global array variables for charts

var scatterChartArrayBirim = []
var barChartArrayBirim = []
var selectedYearBirim;

// Function to export data to Excel
function exportToExcelBirim() {
    // Create a new workbook
    var wb = XLSX.utils.book_new();

    // Process scatter chart data
    var scatterData = [];
    scatterChartArrayBirim.forEach(function (scatterChart, index) {
        var scatterDataset = scatterChart.data.datasets[0];
        var scatterPoint = {
            Yıl: scatterDataset.data[0].x,
            Değer: scatterDataset.data[0].y
        };
        scatterData.push(scatterPoint);
    });
    var scatterWS = XLSX.utils.json_to_sheet(scatterData);
    XLSX.utils.book_append_sheet(wb, scatterWS, "Scatter Chart Data");

    // Process bar chart data
    var barData = [{ "Yıl": selectedYearBirim }];
    barChartArrayBirim.forEach(function (barChart, index) {
        var barDataset = barChart.data.datasets[0];
        barDataset.data.forEach(function (value, i) {
            var barPoint = {
                Kod: barChart.data.labels[i],
                Tanım: barDataset.tanim[i],
                Değer: value
            };
            barData.push(barPoint);
        });
    });
    var barWS = XLSX.utils.json_to_sheet(barData);
    XLSX.utils.book_append_sheet(wb, barWS, "Bar Chart Data");

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




// Function to calculate scatter chart data
function calculateBirimScatterChartData(scatterData1) {

    let gerceklesenMap = new Map();
    let hedeflenen = 0.0;

    for (let i = 0; i < scatterData1.PerformansGostergeleri.length; i++) {

        for (let j = 0; j < scatterData1.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger.length; j++) {
            let year = scatterData1.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].periyod;

            if (!gerceklesenMap.has(year)) {
                gerceklesenMap.set(year, { gerceklesen: 0 });
            }


            gerceklesenMap.get(year).gerceklesen += scatterData1.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].gerceklesen_deger;


        }
        //   if (currentYear == data.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].periyod)


        hedeflenen += scatterData1.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.hedeflenen_deger;

    }

    let yearDataMap = new Map();

    gerceklesenMap.forEach((yearData, year) => {

        if (!yearDataMap.has(year)) {
            yearDataMap.set(year, { yVal: 0 });
        }

        yearDataMap.get(year).yVal = (yearData.gerceklesen * 100) / hedeflenen;


    });

    return yearDataMap;
}


// Function to calculate bar data

function calculateBirimBarChartData(barData) {

    selectedYearBirim = parseInt(document.getElementById('year-select-birim').value);

    let sumMap = {};

    for (let i = 0; i < barData.PerformansGostergeleri.length; i++) {

        let id = barData.PerformansGostergeleri[i].kod;
        let hedeflenen = barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.hedeflenen_deger;

        let kod = barData.PerformansGostergeleri[i].kod;
        let tanim = barData.PerformansGostergeleri[i].tanim;

        if (!sumMap[id]) {
            sumMap[id] = {
                gerceklesen_sum: 0,
                hedeflenen_sum: 0,
                kod: kod,
                tanim: tanim // Initialize the sign with a default value
            };
        }

        for (let j = 0; j < barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger.length; j++) {
            let year = barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].periyod;

            if (year == selectedYearBirim) {
                sumMap[id].gerceklesen_sum += barData.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].gerceklesen_deger;
            }

        }

        sumMap[id].hedeflenen_sum += hedeflenen;

    }


    let result = Object.keys(sumMap).map(function (id) {
        return {
            id: parseInt(id),
            oran: (sumMap[id].gerceklesen_sum * 100) / sumMap[id].hedeflenen_sum,
            kod: sumMap[id].kod,
            tanim: sumMap[id].tanim
        };
    });

    return result;

}



// Function to initialize scatter chart
function initializeBirimScatterChart(canvasId, data) {

    let selectedYearBirim = parseInt(document.getElementById('year-select-birim').value);

    let yearDataMap = calculateBirimScatterChartData(data);

    const scatterData = {
        datasets: [{
            label: "",
            data: [{

                x: selectedYearBirim,
                y: yearDataMap.get(selectedYearBirim).yVal
            }],
            pointRadius: 7,
            backgroundColor: '#EC6C8D'
        }],
    };

    let scatter_ctx = document.getElementById('birim-scatter-chart-' + canvasId).getContext('2d');

    let scatterChart = new Chart(scatter_ctx, {
        type: 'line',
        data: scatterData,
        options: {
            responsive: true,
            scales: {
                x: {
                    offset: true // Set offset to true to center the X value
                },
                y: {
                    position: 'left',
                    min: 0,
                    max: 100,
                    ticks: {
                        maxTicksLimit: 10,
                    }
                }
            },
            plugins: {
                display: false,
                legend: {
                    display: false
                }
            }

        },
    });

    scatterChartArrayBirim.push(scatterChart);

}

function updateBirimScatterChart(canvasId, data) {

    selectedYearBirim = parseInt(document.getElementById('year-select-birim').value);

    let yearDataMap = calculateBirimScatterChartData(data);

    let chartToUpdate = scatterChartArrayBirim[canvasId];

    chartToUpdate.data.datasets[0].data[0].x = 0;
    chartToUpdate.data.datasets[0].data[0].y = 0;
    chartToUpdate.data.labels = [];
    chartToUpdate.update();

    chartToUpdate.data.datasets[0].data[0].x = selectedYearBirim;
    chartToUpdate.data.datasets[0].data[0].y = yearDataMap.get(selectedYearBirim).yVal;


    chartToUpdate.update();

}

// Function to initialize bar chart
function initializeBirimBarChart(canvasId, barData) {
    
    let result = calculateBirimBarChartData(barData);


    let data = {
        labels: [],
        datasets: [{
            data: [],
            backgroundColor: '#00BBA4',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1,
            maxBarThickness: 30,
            color: '#000000',
            tanim: []
        }]
    };

    for (let i = 0; i < result.length; i++) {

        data.labels.push(result[i].kod);
        data.datasets[0].data.push(result[i].oran);
        data.datasets[0].tanim.push(result[i].tanim);
    }


    let options = {
        indexAxis: 'y',
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
                callbacks: {
                    label: (context) => {
                        return 'Hedef: ' + '\n' + context.dataset.tanim[context.dataIndex];
                    }
                },
                boxWidth: 10,
                boxHeight: 10
            }
        },
        layout: {
            padding: {
                top: 10,
                bottom: 50
            }
        }

    };

    let ctx = document.getElementById('birim-bar-chart-' + canvasId).getContext('2d');

    let chart = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: options
    });

    barChartArrayBirim.push(chart);

}

function updateBirimBarChart(canvasId, barData) {

    let result = calculateBirimBarChartData(barData);


    let chartToUpdate = barChartArrayBirim[canvasId];

    chartToUpdate.data.datasets[0].data = [];
    chartToUpdate.data.labels = [];
    chartToUpdate.update();

    for (let i = 0; i < result.length; i++) {

        chartToUpdate.data.labels.push(result[i].kod);
        chartToUpdate.data.datasets[0].data.push(result[i].oran);
        chartToUpdate.data.datasets[0].tanim.push(result[i].tanim);
    }

    chartToUpdate.update();


}
