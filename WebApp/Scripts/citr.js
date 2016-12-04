function initLookupAutocomplete(id, name, url) {
    var limit = 10;
    $("#" + name).autocomplete({
        source: function (request, response) {
            $("#" + id).val("");
            $.ajax({
                url: url,
                datatype: "json",
                data: {
                    term: request.term
                },
                success: function (data) {
                    var slicedData = data.slice(0, limit);
                    response($.map(slicedData, function (val, item) {
                        return {
                            label: val.StationName,
                            value: val.StationName,
                            stationId: val.StationId
                        }
                    }))
                }
            })
        },
        select: function (event, ui) {
            $("#" + id).val(ui.item.stationId);
        }
    });
}

function initLoadingAnimation() {
    $("#placesForm").submit(function (e) {
        if (e.result) {
            $("#train").addClass("animated infinite wobble");
        }
    });
}

function disableLoadingAnimation() {
    $("#train").removeClass("animated infinite wobble");
}
