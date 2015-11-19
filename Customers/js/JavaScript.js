$(main)

function main() {
    bindListeners();
}
function bindListeners(){
    $("#ClickForSearch").on("click", displaysearchField);
}
function displaysearchField() {
    $(".searchFieldByName").slideToggle();
    $(".searchFieldByCity").slideToggle();
    $("#linkCancelSearchByName").slideToggle();
}