
$(document).ready(function () {
    $(".number").click(
       function () {
           var valCoordinate = $(this).html();
           var span = $('input:checked').nextAll('span').first();
           span.html(valCoordinate);
           UpdateRover();
       });
    $("#left").click(
        function () {
            currentDirection = "L";
            buildDirectionString();
            UpdateRover();
        });
    $("#forward").click(
        function () {
            currentDirection = "M";
            buildDirectionString();
            UpdateRover();
        });
    $("#right").click(
        function () {
            currentDirection = "R";
            buildDirectionString();
            UpdateRover();
        });
    $('#rover-picker').on('change',
        function () {
            $("#directions").empty();
            instructions = "";
        });
    $('#heading').on('change',
        function () {
            UpdateRover();
        });
    $("#submit").click(
       function () {
           var listOfRovers = [];
           $.each( $('#rovers > div'), function() {
               $(this).each(function () {
                   var idString = $(this).attr('id');
                   var idStringArray = idString.split('_'); //wanted to use data-attribute but couldn't get it to work!
                   var id = idStringArray[1];   
                   var position = $('#roverCurrent_'+id).html();
                   var directions = $('#roverHeading_'+id).html();                   
                   var rover = {'Id':id,'StartingLocation': position,'Directions':directions};
                   listOfRovers.push(rover); 
               });
           });
           var areax = $('#x-coord').html();
           var areay =  $('#y-coord').html();

           var jsonObject = {
               'AreaX': areax,
               'AreaY': areay,
               'ListOfRovers': listOfRovers
           };


           console.log(JSON.stringify(jsonObject));
           $.ajax({
               type: "POST",
               url: "../api/GetLocation/",
               data: jsonObject,
               dataType: "json",
               success: function (returnData) {
                   console.log(returnData);
                   $.each(returnData.ListOfRovers, function () {
                       console.log(this);
                       var roverId = this.Id;
                       $('#roverFinal_' + roverId).html(this.EndLocation);
                   });
               },
               error: function (XMLHttpRequest, textStatus, errorThrown) {
                   alert('oops, somethingwent wrong!');
               }
           });
       });


});

var currentDirection = "";
var currentCoordinate = 0;
var instructions = "";

function buildDirectionString() {
    if (instructions == "") {        
        instructions = currentDirection;
    }
    else{
        instructions = instructions + currentDirection;
    }
    $("#directions").html(instructions);
}
function UpdateRover() {
    var rover = $('#rover-picker option:selected').val();
    var roverNumber = rover.split('_');
    var updateRover = $(rover);
    var coordinate = $('#x-start').html() + $('#y-start').html() + $('#heading option:selected').val();
    $('#roverCurrent_'+ roverNumber[1]).html(coordinate);
    $('#roverHeading_' + roverNumber[1]).html($('#directions').html());
}
