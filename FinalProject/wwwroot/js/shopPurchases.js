$(function () {
    console.log("loaded");
})

var nos = 0;
var firstRefresh = true;

function buy_nos(e, email, par, nosNum)
{
    console.log("in buy_nos function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true)
    {
        firstRefresh = false;
        nos = nosNum;
    }

    nos++;

    $.ajax({
        url: "/Users/BuyNos",

        data:
        {
            Email: email
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {
        console.log("action taken: " + result)
        $("#" + par).text("You currently have " + nos + " containers!");
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
    }).always(function () {
        console.log("but I will always do this")
    });
}

function buy_blue()
{

}

function buy_green()
{

}

function buy_purple()
{

}

function buy_chrome()
{

}