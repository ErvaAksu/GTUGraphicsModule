// stratejik_plan_performansi.js
// stratejik plan performansı sayfasında kullanılan js fonksiyonları

// Global array variables for charts

var scatterChartArray = []
var barChartArray = []

var selectedYear;

// Function to export data to Excel
function exportToExcel() {
    // Create a new workbook
    var wb = XLSX.utils.book_new();

    // Process scatter chart data
    var scatterData = [];
    scatterChartArray.forEach(function (scatterChart, index) {
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
    var barData = [{ "Yıl": selectedYear }];
    barChartArray.forEach(function (barChart, index) {
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
function calculateScatterChartData(scatterData1) {

    let gerceklesenMap = new Map();
    let hedeflenen = 0.0;

    for (let i = 0; i < scatterData1.PerformansGostergeleri.length; i++)
    {

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

function calculateBarChartData(barData) {

    selectedYear = parseInt(document.getElementById('year-select').value);

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

            if (year == selectedYear) {
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
function initializeScatterChart(canvasId, data) {

    selectedYear = parseInt(document.getElementById('year-select').value);

    let yearDataMap = calculateScatterChartData(data);

   

    let scatterData = {
        datasets: [{
            label: "",
            data: [{

                x: selectedYear,
                y: yearDataMap.get(selectedYear).yVal
            }],
            pointRadius: 7,
            backgroundColor: '#EC6C8D'
        }],
    };

    let scatter_ctx = document.getElementById('scatter-chart-' + canvasId).getContext('2d');

    let scatterChart = new Chart(scatter_ctx, {
        type: 'line',
        data: scatterData,
        options: {
            destroy: true,
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

    scatterChartArray.push(scatterChart);

}

function updateScatterChart(canvasId, data) {

    selectedYear = parseInt(document.getElementById('year-select').value);

    let yearDataMap = calculateScatterChartData(data);

    

    let chartToUpdate = scatterChartArray[canvasId];

    chartToUpdate.data.datasets[0].data[0].x = 0;
    chartToUpdate.data.datasets[0].data[0].y = 0;
    chartToUpdate.data.labels = [];
    chartToUpdate.update();

    chartToUpdate.data.datasets[0].data[0].x = selectedYear;
    chartToUpdate.data.datasets[0].data[0].y = yearDataMap.get(selectedYear).yVal;
    

    chartToUpdate.update();

}

// Function to initialize bar chart
function initializeBarChart(canvasId, barData) {

    let result = calculateBarChartData(barData);


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
        destroy: true,
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
                displayColors: false,
                bodyFontFamily: 'Arial', // Set the font family for the tooltip body
                bodyFontSize: 14, // Set the font size for the tooltip body
                bodySpacing: 10,
                callbacks: {
                    label: (context) => {
                        return context.dataset.tanim[context.dataIndex];
                    }
                },
                boxWidth: 50,
                boxHeight: 100
            }
            
        },
        layout: {
            padding: {
                top: 10,
                bottom: 50
            }
        }
        
    };



    let ctx = document.getElementById('bar-chart-' + canvasId).getContext('2d');


    let bar_chart = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: options
    });

    barChartArray.push(bar_chart);

}


function updateBarChart(canvasId, barData) {

    let result = calculateBarChartData(barData);
   

    let chartToUpdate = barChartArray[canvasId];

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