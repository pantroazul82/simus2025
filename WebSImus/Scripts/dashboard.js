$(function () {
    
    /* Rickshaw dashboard chart */
    var seriesData = [ [], [] ];
    var random = new Rickshaw.Fixtures.RandomData(1000);

    for(var i = 0; i < 100; i++) {
        random.addData(seriesData);
    }

    var rdc = new Rickshaw.Graph( {
            element: document.getElementById("dashboard-chart"),
            renderer: 'area',
            width: $("#dashboard-chart").width(),
            height: 250,
            series: [{color: "#33414E",data: seriesData[0],name: 'New'}, 
                     {color: "#3FBAE4",data: seriesData[1],name: 'Returned'}]
    } );

    rdc.render();

    var legend = new Rickshaw.Graph.Legend({graph: rdc, element: document.getElementById('dashboard-legend')});
    var shelving = new Rickshaw.Graph.Behavior.Series.Toggle({graph: rdc,legend: legend});
    var order = new Rickshaw.Graph.Behavior.Series.Order({graph: rdc,legend: legend});
    var highlight = new Rickshaw.Graph.Behavior.Series.Highlight( {graph: rdc,legend: legend} );        

    var rdc_resize = function() {                
            rdc.configure({
                    width: $("#dashboard-chart").width(),
                    height: $("#dashboard-chart").height()
            });
            rdc.render();
    }

    var hoverDetail = new Rickshaw.Graph.HoverDetail({graph: rdc});

    window.addEventListener('resize', rdc_resize);        

    rdc_resize();
    /* END Rickshaw dashboard chart */
  
   
});

