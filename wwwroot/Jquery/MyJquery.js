

$(document).ready(function(){
  var energy = $(".energy")
  var fullness = $(".fullness")
  var happiness = $(".happiness")
  var meals = $(".meals")
  var message = $(".action_message")
  var playAgain = $(".PlayAgain")
  playAgain.hide()
  
  function hasFinished() {
   
    $(".status").hide()
    $(".feed").hide()
    $(".play").hide()
    $(".work").hide()
    $(".sleep").hide()
    playAgain.show()
  }

  

  $(".feed").on('click', function(){
    
    var data = $("DojodachiData").serialize();
    console.log(`presubmit value is ${meals.val()}`)
    console.log(`presubmit value is ${fullness.val()}`)
    $.ajax({
      type: "POST",
      url: `/Feed/${happiness.val()}/${fullness.val()}/${energy.val()}/${meals.val()}`,
      data: data,
      dataType: "json"
    }).done(function(response){
      if(response.hasWon){
        message.html(response.message)
        hasFinished()
      }
      else{
      $(".status").html(`Fullness:  ${response.fullness}  Happiness: ${response.happiness}  Meals: ${response.meals}  Energy: ${response.energy}`)
      meals.val(response.meals)
      fullness.val(response.fullness)
      happiness.val(response.happiness)
      energy.val(response.energy)
      message.html(response.message)
      }
    })
  
    return false;
  })

  $(".play").on('click', function () {

    var data = $("DojodachiData").serialize();
    $.ajax({
      type: "POST",
      url: `Play/${happiness.val()}/${fullness.val()}/${energy.val()}/${meals.val()}`,
      data: data,
      dataType: "json"
    }).done(function (response) {
      if (response.hasWon) {
        message.html(response.message)
        hasFinished();
      }
      else {
        $(".status").html(`Fullness:  ${response.fullness}  Happiness: ${response.happiness}  Meals: ${response.meals}  Energy: ${response.energy}`)
        meals.val(response.meals)
        fullness.val(response.fullness)
        happiness.val(response.happiness)
        energy.val(response.energy)
        message.html(response.message)
      }
    })

    

    return false;
  })

  $(".work").on('click', function () {

    var data = $("DojodachiData").serialize();
    console.log("clicked...")
    $.ajax({
      type: "POST",
      url: `Work/${happiness.val()}/${fullness.val()}/${energy.val()}/${meals.val()}`,
      data: data,
      dataType: "json"
    }).done(function (response) {
      if (response.hasLost) {
        message.html(response.message)
        hasFinished()
      }
      else {
        $(".status").html(`Fullness:  ${response.fullness}  Happiness: ${response.happiness}  Meals: ${response.meals}  Energy: ${response.energy}`)
        meals.val(response.meals)
        fullness.val(response.fullness)
        happiness.val(response.happiness)
        energy.val(response.energy)
        message.html(response.message)
      }
    })



    return false;
  })

  $(".sleep").on('click', function () {

    var data = $("DojodachiData").serialize();
    console.log("clicked...")
    $.ajax({
      type: "POST",
      url: `Sleep/${happiness.val()}/${fullness.val()}/${energy.val()}/${meals.val()}`,
      data: data,
      dataType: "json"
    }).done(function (response) {
      if (response.hasLost){
        message.html(response.message)
        hasFinished()
        

      }
      else {
        $(".status").html(`Fullness:  ${response.fullness}  Happiness: ${response.happiness}  Meals: ${response.meals}  Energy: ${response.energy}`)
        meals.val(response.meals)
        fullness.val(response.fullness)
        happiness.val(response.happiness)
        energy.val(response.energy)
        message.html(response.message)
      }
    })



    return false;
  })
  
  playAgain.on("click", function() {
    $.ajax({
      type: "GET",
      url: "/"
    }).done(function(){
      playAgain.hide()
    })
  })

})