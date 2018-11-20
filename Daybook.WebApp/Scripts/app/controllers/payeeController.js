

var payeeController = function () {

    var init = function () {
        $(".js-delete-payee").click(deletePayee);
    };

    var deletePayee = function (e) {
        var btn = $(e.target);

        var payeeid = btn.attr("data-payee-id");

        console.log(payeeid);
    };

    return {
        init: init
    }
}();