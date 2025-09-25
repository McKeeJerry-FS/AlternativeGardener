// This is the Javascript file that is associated with the Dashboard only!
// This file will hold all of the scripting involved with datatables and charts used on the dashboard

$(document).ready(function () {
    // DataTable init
    $('#dashboardGardenTable').DataTable();
    $('#dashboardPlantTable').DataTable();

    // Water Quality Chart init (requires Chart.js loaded on the page)
    const canvas = document.getElementById('waterQualityChart');
    if (canvas && window.Chart) {
        const ctx = canvas.getContext('2d');
        const chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [
                    {
                        label: 'pH',
                        data: [6.2, 6.3, 6.5, 6.4, 6.6, 6.7, 6.5],
                        borderColor: 'rgb(75, 192, 192)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        tension: 0.3,
                        yAxisID: 'y',
                    },
                    {
                        label: 'EC (mS/cm)',
                        data: [1.6, 1.7, 1.8, 1.8, 1.9, 2.0, 1.9],
                        borderColor: 'rgb(255, 159, 64)',
                        backgroundColor: 'rgba(255, 159, 64, 0.2)',
                        tension: 0.3,
                        yAxisID: 'y1',
                    },
                    {
                        label: 'Water Temp (F)',
                        data: [60, 65, 70, 75, 70, 65, 60],
                        borderColor: 'rgb(255, 104, 25)',
                        backgroundColor: 'rgba(255, 104, 25, 0.2)',
                        tension: 0.3,
                        yAxisID: 'y2',
                    }
                ]
            },
            options: {
                responsive: true,
                interaction: { mode: 'index', intersect: false },
                stacked: false,
                plugins: {
                    legend: { position: 'top' },
                    title: { display: true, text: 'Water Quality (Last 7 Days)' }
                },
                scales: {
                    y: {
                        type: 'linear',
                        position: 'left',
                        title: { display: true, text: 'pH' },
                        min: 5.5,
                        max: 7.5
                    },
                    y1: {
                        type: 'linear',
                        position: 'right',
                        title: { display: true, text: 'EC (mS/cm)' },
                        grid: { drawOnChartArea: false },
                        min: 1.0,
                        max: 2.5
                    },
                    y2: {
                        type: 'linear',
                        position: 'right',
                        title: { display: true, text: 'Temp (F)' },
                        grid: { drawOnChartArea: false },
                        min: 50,
                        max: 90
                    }
                }
            }
        });
    }

    // Average Plant Growth Chart in Card4
    const growthCanvas = document.getElementById('plantGrowthChart');
    if (growthCanvas && window.Chart) {
        const gctx = growthCanvas.getContext('2d');
        const growthChart = new Chart(gctx, {
            type: 'bar',
            data: {
                labels: ['Week 1', 'Week 2', 'Week 3', 'Week 4', 'Week 5', 'Week 6'],
                datasets: [
                    {
                        label: 'Average Height (cm)',
                        data: [3, 5, 8, 12, 16, 20],
                        backgroundColor: 'rgba(54, 162, 235, 0.5)',
                        borderColor: 'rgb(54, 162, 235)',
                        borderWidth: 1,
                    }
                ]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { position: 'top' },
                    title: { display: true, text: 'Average Plant Growth (Last 6 Weeks)' }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        title: { display: true, text: 'Height (cm)' }
                    }
                }
            }
        });
    }
});
