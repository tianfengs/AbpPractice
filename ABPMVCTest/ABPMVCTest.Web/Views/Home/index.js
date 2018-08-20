$(function() {

    Highcharts.setOptions({
        lang: {
          
                printChart: '打印图表',
                downloadJPEG: '下载为JPEG图片',
                downloadPDF: '下载为PDF',
                downloadPNG: '下载为PNG图片',
                downloadSVG: '下载为SVG矢量图',
                months: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
                weekdays: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"],
                shortMonths: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"],
        }
    });
    var nowDate = new Date();
    var option = {
           
        chart: {
            type: 'area'
        },
        title: {
            text: '收入趋势图'
        },
        subtitle: {
            text: '没有选择时间范围的话，默认显示当日/月前后3天/月的数据'
        },
        credits: {
            enabled:false
        },
        xAxis: {
            type: 'datetime',
            tickmarkPlacement: 'on',
            title: {
                enabled: false
            },
            dateTimeLabelFormats: {
                day: "%Y-%m-%d",
                week: "%A",
                month: "%Y-%m",
                year: "%Y"
            }
        },
        yAxis: {
            title: {
                text: '单位：元'
            },
            labels: {
                formatter: function() {
                    return this.value;
                }
            }
        },
        tooltip: {
            shared: true,
            valueSuffix: ' 元',
            dateTimeLabelFormats: {
                day: "%Y-%m-%d,%A",
                week: "%A开始, %Y-%m-%d",
                month: "%Y-%m",
                year: "%Y"
            }
        },
        plotOptions: {
            area: {
                stacking: 'normal',
                lineColor: '#666666',
                lineWidth: 1,
                marker: {
                    lineWidth: 1,
                    lineColor: '#666666'
                }
            },
            series: {
                pointStart:Date.UTC(nowDate.getFullYear(),nowDate.getMonth(),nowDate.getDate()-3) ,
                pointInterval: 24 * 36e5 //一天
            }
        },
        series: [{}]
    }

    var url = "/Home/GetJsonResult";

    $.getJSON(url, function(data) {
        option.series = data;
        $('#container').highcharts(option);
    });
  
});