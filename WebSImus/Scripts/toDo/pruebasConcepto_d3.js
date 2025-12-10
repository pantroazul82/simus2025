$(document).ready(function() {
    
    /* D3 principios */    
    
    var sampleSVG = d3.select("#rectSVG")
        .append("svg")
        .append("rect")
        .attr("width",50)
        .attr("height",200)
        .style("fill","#28b6d6");
    
    var sampleSVG = d3.select("#circleSVG")
        .append("svg")
        .attr("width",50)
        .attr("height",50)
        .append("circle")
        .attr("cx",25)
        .attr("cy",25)
        .attr("r",25)
        .style("fill","#c1314a");
    
    var sampleSVG = d3.select("#textoSVG")
        .append("svg")
        .attr("width",250)
        .attr("height",50)
        .append("text")
        .text("Ejemplo y texto desde javascript")
        .attr("x",0)
        .attr("y",25)
        .style("fill","#4c2c54");
    
    /* D3 pintar datos en la caja #drawdata */

    var w = 330;
    var h = 200;
    var padding = 5;
    var dataset = [5, 10, 21, 15, 40, 25, 13, 16, 8, 30];

    var svg = d3.select("#drawdata")
        .append("svg")
        .attr("width", w)
        .attr("height", h);

    function colorPicker(v) {
        if (v <= 20) { return "#389b7f"; }
        else if (v > 20) { return "#c1314a";}
    }

    svg.selectAll("rect")
        .data(dataset)
        .enter()
        .append("rect")
    .attr({
        x: function (d, i) { return i * (w / dataset.length);},
        y: function (d) { return h - (d * 4);},
        width: w / dataset.length - padding,
        height: function (d) { return (d * 4)},
        fill: function(d) { return colorPicker(d);}
    });

    svg.selectAll("text")
    .data(dataset)
    .enter()
    .append("text")
    .text(function (d) { return d; })
    .attr({
        "text-anchor": "middle",
        x: function (d, i) { return i * (w / dataset.length) + (w / dataset.length - padding) / 2; },
        y: function (d) { return h - (d * 4) + 14; },
        "fill": "#ffffff"
    });

});
