// stratejik_plan_genel.js
// stratejik plan genel sayfasında kullanılan js fonksiyonları

var lineChartBirim;
var polarChartBirim;
var currentYearBirim;

// Function to export data to Excel
function exportToExcelBirim() {
    // Create a new workbook
    var wb = XLSX.utils.book_new();

    var lineData = [];
    var lineDataset = lineChartBirim.data.datasets[0];
    lineDataset.data.forEach(function (value, i) {
        var linePoint = {

            Yıl: lineChart.data.labels[i],
            Değer: value
        };
        lineData.push(linePoint);
    });

    var lineWS = XLSX.utils.json_to_sheet(lineData);
    XLSX.utils.book_append_sheet(wb, lineWS, "Line Chart Data");


    var polarData = [{ "Yıl": currentYearBirim }];
    var polarDataset = polarChartBirim.data.datasets[0];
    polarDataset.data.forEach(function (value, i) {
        var polarPoint = {

            Kod: polarChartBirim.data.labels[i],
            Değer: value
        };
        polarData.push(polarPoint);
    });

    var polarWS = XLSX.utils.json_to_sheet(polarData);
    XLSX.utils.book_append_sheet(wb, polarWS, "Polar Chart Data");


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


// Function to initialize line chart
function initializeBirimLineChart(lineData) {

    let currentDate = new Date();

    currentYearBirim = currentDate.getFullYear();

    let veriKategorileri_labels = []

    let yearDataMap = new Map();

    lineData.forEach((data, index) => {

        let gerceklesenMap = new Map();
        let hedeflenen = 0.0;

        for (let i = 0; i < data.PerformansGostergeleri.length; i++) {

            for (let j = 0; j < data.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger.length; j++) {
                let year = data.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].periyod;

                if (!gerceklesenMap.has(year)) {
                    gerceklesenMap.set(year, { gerceklesen: 0 });
                }


                gerceklesenMap.get(year).gerceklesen += data.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].gerceklesen_deger;


            }
            //   if (currentYear == data.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.Kalite_PerformansGostergeGerceklesenDeger[j].periyod)


            hedeflenen += data.PerformansGostergeleri[i].Kalite_PerformansGostergeHedeflenenDeger.hedeflenen_deger;


        }


        gerceklesenMap.forEach((yearData, year) => {

            if (!yearDataMap.has(year)) {
                yearDataMap.set(year, { yVals: [], sum: 0, count: 0 });
            }

            let yVal = (yearData.gerceklesen * 100) / hedeflenen;

            yearDataMap.get(year).yVals.push(yVal);
            yearDataMap.get(year).sum += yVal;
            yearDataMap.get(year).count++;

        });

        veriKategorileri_labels.push(data.VeriKategorisi.kod);

    });


    let year_labels = []
    let year_data = []

    yearDataMap.forEach((data, year) => {

        year_labels.push(year);
        year_data.push(data.sum / data.count);

    });



    let lineChartData = {
        labels: year_labels,
        datasets: [{
            label: "",
            data: year_data,
            backgroundColor: 'rgba(75, 192, 192, 0.5)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 2,
            pointRadius: 8,
            pointBackgroundColor: 'rgba(75, 192, 192, 1)',
            pointBorderColor: '#fff',
            pointBorderWidth: 2
        }]
    };


    // Configuration options for the line chart
    let lineChartOptions = {
        scales: {
            x: {
                type: 'linear',
                position: 'bottom',
                ticks: {
                    maxTicksLimit: 5,
                    callback: function (value, index, values) {
                        // Check if the value is a whole number (integer)
                        if (Number.isInteger(value)) {
                            // Format the year without a comma
                            return value.toString();
                        } else {
                            // For non-integer values, return the default formatting
                            return value;
                        }
                    }
                }
            },
            y: {
                type: 'linear',
                position: 'left',
                beginAtZero: true,
                max: 100
            }
        },
        plugins: {

            title: {
                display: true,
                text: 'Yıllara göre hedeflerin gerçekleşme yüzdesi',
                font: {
                    size: 18,
                },
                padding: {
                    top: 10,
                    bottom: 30
                }

            },
            legend: {
                display: false
            }

        }



    };

    // Get the container and canvas elements
    let container = document.querySelector('div');
    let lineCtx = document.getElementById('line-chart-birim').getContext('2d');

    // Create the line chart
    lineChartBirim = new Chart(lineCtx, {
        type: 'line',
        data: lineChartData,
        options: lineChartOptions
    });

    let polarChartData = {
        datasets: [{
            data: [],
            backgroundColor: ['#EF6A93', '#6CBC71', '#0083A1', '#660025'],
            label: 'Polar Area Chart'
        }],
        labels: []

    };

    yearDataMap.get(currentYearBirim).yVals.forEach((data) => {
        polarChartData.datasets[0].data.push(data);

    });

    veriKategorileri_labels.forEach((data) => {
        polarChartData.labels.push(data);

    });


    // Configuration options for the polar area chart
    let polarChartOptions = {
        legend: {
            display: false, // Hide legend label
        },
        responsive: true,
        maintainAspectRatio: false,
        scales: {
            r: {
                beginAtZero: true,
                max: 100
            }
        }
    };

    let polarCtx = document.getElementById('polar-chart-birim').getContext('2d');

    // Create or update the polar area chart
    polarChartBirim = new Chart(polarCtx, {
        type: 'polarArea',
        data: polarChartData,
        options: polarChartOptions
    });

    // Display the polar area chart canvas
    polarCtx.canvas.style.display = 'block';

    // Handle click events on the line chart points
    lineCtx.canvas.addEventListener('click', function (event) {
        let activePoints = lineChartBirim.getElementsAtEventForMode(event, 'point', lineChartBirim.options);
        if (activePoints.length > 0) {
            // Extract the data of the clicked point
            let clickedData = lineChartData.datasets[activePoints[0].datasetIndex].data[activePoints[0].index];
            let clicked_label = lineChartData.labels[activePoints[0].index];
            polarChartBirim.data.datasets[0].data = [];
            polarChartBirim.data.labels = [];
            polarChartBirim.update();


            if (clickedData != 0) {

                currentYearBirim = clicked_label;

                yearDataMap.get(clicked_label).yVals.forEach((data) => {
                    polarChartBirim.data.datasets[0].data.push(data);
                });

                veriKategorileri_labels.forEach((data) => {
                    polarChartData.labels.push(data);

                });

                polarChartBirim.update();

            }

        }
    });


}
