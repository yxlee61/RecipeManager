$("input[data-autocomplete-source]").each(function () {
  var target = $(this);
  target.autocomplete({ source: target.attr("data-autocomplete-source") });
});

$("#heatBtn").click(function () {
  var message = "Heating Instructions: Loosen lid, remove portion cups (if included), "
  + "reheat until internal temperature of 165\xB0 is reached, approximately "
  + "1-2 minutes in microwave. After heating, let stand 2 more minutes before "
  + "removing from microwave. CAUTION container and contents will be "
  + "HOT! Keep refrigerated until use. Do NOT consume past use by date.";

  $("#instructions").val(message);
  return false;
});

$("#storeBtn").click(function () {
  var message = "Important: Keep refrigerated until use. Do NOT consume past Use by "
  + "date. Consuming raw or undercooked meats, poultry, seafood, shellfish "
  + "or eggs may increase your risk of food-borne illness.";

  $("#instructions").val(message);
  return false;
});

$("#clearBtn").click(function () {
  $("#instructions").val("");
  return false;
});