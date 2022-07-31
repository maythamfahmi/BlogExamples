
$(document).ready(function() {
    var baseUrl = "http://localhost:40692";

    $("#searchbutton").click(function() {
        console.log("Sending request to server.");
        $.ajax({
            method: "GET",
            url: baseUrl + "/search",
            //data: {query: $('#searchbox').val()}
        }).success( function (data) { 
            console.log("Received response " + data);
            $("#responsesize").html("<p> Your query has been found on " + data.urlList.length +  " websites <br> <Strong>Query Time: </Strong>" + data.queryTime + " microseconds" + "</p>");
            buffer = "<ul>\n";
            $.each(data.urlList, function(index, value) { 
                buffer += "<li>" + data.titleList[index] + "<br>" + "<a href=\"" + value + "\">" + value + "</a></li>\n";
            });
            buffer += "</ul>";
            $("#urllist").html(buffer);
        });
    });
});
