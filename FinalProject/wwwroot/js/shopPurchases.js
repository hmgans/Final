$(function () {
    console.log("loaded");
})

/**
 * I use these globals to keep track of the users money and nos so they do not have to refresht he page
 * */
var nos = 0;
var firstRefresh = true;
var money = 0;

/*
 * this java script function takes in email and money amount and sends it to the controller
 * if the controller is successful it changes the html to reflect the change
 * if it isn't successful it does not change anything
 * */
function buy_nos(e, email, par, nosNum, moneySum, moneyID) {
    console.log("in buy_nos function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true) {
        firstRefresh = false;
        nos = nosNum;
        money = moneySum;
    }


    $.ajax({
        url: "/Users/BuyNos",

        data:
        {
            Email: email,
            Money: money
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {

        console.log("action taken: " + result)
        if (result.money == true) {
            swal.fire({
                type: 'error',
                title: 'You do not have enough Gamer Points!',
                text: 'Buy some more!'
            })
        }
        else {

            nos++;
            money -= 100;

            $("#" + moneyID).text("You currently have " + money + " Gamer Points");

            $("#" + par).text("You currently have " + nos + " containers!");

            Swal.fire
                ({
                    type: 'success',
                    title: 'You bought Nos!',
                    text: 'Race on gamer!'
                })

        }



    }).fail(function (jqXHR, textStatus, errorThrown) {

        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
        Swal.fire
            ({
                type: 'error',
                title: 'Something went wrong...',
                text: 'Try again later!'
            })
    }).always(function () {
        console.log("but I will always do this")
    });
}
/*
 * this java script function takes in email and money amount and sends it to the controller
 * if the controller is successful it changes the html to reflect the change
 * if it isn't successful it does not change anything
 * */
function buy_blue(e, email, moneySum, moneyID) {
    console.log("in buy_blue function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true) {
        firstRefresh = false;
        money = moneySum;
    }


    $.ajax({
        url: "/Users/BuyBlueSkin",

        data:
        {
            Email: email,
            Money: money
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {

        console.log("action taken: " + result)
        if (result.money == true) {
            swal.fire({
                type: 'error',
                title: 'You do not have enough Gamer Points!',
                text: 'Buy some more!'
            })
        }
        else {

            money -= 200;

            $("#" + moneyID).text("You currently have " + money + " Gamer Points");

            $("#bluebtn").text("Purchased").prop("disabled", true).css('background-color', 'green');

            Swal.fire
                ({
                    type: 'success',
                    title: 'You bought a blue skin!',
                    text: 'Race on gamer!'
                })

        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
        Swal.fire
            ({
                type: 'error',
                title: 'Something went wrong...',
                text: 'Try again later!'
            })
    }).always(function () {
        console.log("but I will always do this")
    });
}
/*
 * this java script function takes in email and money amount and sends it to the controller
 * if the controller is successful it changes the html to reflect the change
 * if it isn't successful it does not change anything
 * */
function buy_green(e, email, moneySum, moneyID) {
    console.log("in buy_green function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true) {
        firstRefresh = false;
        money = moneySum;
    }


    $.ajax({
        url: "/Users/BuyGreenSkin",

        data:
        {
            Email: email,
            Money: money
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {

        console.log("action taken: " + result)
        if (result.money == true) {
            swal.fire({
                type: 'error',
                title: 'You do not have enough Gamer Points!',
                text: 'Buy some more!'
            })
        }
        else {

            money -= 200;

            $("#" + moneyID).text("You currently have " + money + " Gamer Points");

            $("#greenbtn").text("Purchased").prop("disabled", true).css('background-color', 'green');

            Swal.fire
                ({
                    type: 'success',
                    title: 'You bought a green skin!',
                    text: 'Race on gamer!'
                })

        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
        Swal.fire
            ({
                type: 'error',
                title: 'Something went wrong...',
                text: 'Try again later!'
            })
    }).always(function () {
        console.log("but I will always do this")
    });
}
/*
 * this java script function takes in email and money amount and sends it to the controller
 * if the controller is successful it changes the html to reflect the change
 * if it isn't successful it does not change anything
 * */
function buy_purple(e, email, moneySum, moneyID) {
    console.log("in buy_purple function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true) {
        firstRefresh = false;
        money = moneySum;
    }


    $.ajax({
        url: "/Users/BuyPurpleSkin",

        data:
        {
            Email: email,
            Money: money
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {

        console.log("action taken: " + result)
        if (result.money == true) {
            swal.fire({
                type: 'error',
                title: 'You do not have enough Gamer Points!',
                text: 'Buy some more!'
            })
        }
        else {

            money -= 200;

            $("#" + moneyID).text("You currently have " + money + " Gamer Points");

            $("#purplebtn").text("Purchased").prop("disabled", true).css('background-color', 'green');

            Swal.fire
                ({
                    type: 'success',
                    title: 'You bought a purple skin!',
                    text: 'Race on gamer!'
                })

        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
        Swal.fire
            ({
                type: 'error',
                title: 'Something went wrong...',
                text: 'Try again later!'
            })
    }).always(function () {
        console.log("but I will always do this")
    });
}

/*
 * this java script function takes in email and money amount and sends it to the controller
 * if the controller is successful it changes the html to reflect the change
 * if it isn't successful it does not change anything
 * */
function buy_chrome(e, email, moneySum, moneyID) {
    console.log("in buy_chrome function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true) {
        firstRefresh = false;
        money = moneySum;
    }


    $.ajax({
        url: "/Users/BuyChromeSkin",

        data:
        {
            Email: email,
            Money: money
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {

        console.log("action taken: " + result)
        if (result.money == true) {
            swal.fire({
                type: 'error',
                title: 'You do not have enough Gamer Points!',
                text: 'Buy some more!'
            })
        }
        else {

            money -= 500;

            $("#" + moneyID).text("You currently have " + money + " Gamer Points");

            $("#chromebtn").text("Purchased").prop("disabled", true).css('background-color', 'green');

            Swal.fire
                ({
                    type: 'success',
                    title: 'You bought a chrome skin!',
                    text: 'Race on gamer!'
                })

        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
        Swal.fire
            ({
                type: 'error',
                title: 'Something went wrong...',
                text: 'Try again later!'
            })
    }).always(function () {
        console.log("but I will always do this")
    });
}

/*
 * this java script function takes in email and money amount and sends it to the controller
 * if the controller is successful it changes the html to reflect the change
 * if it isn't successful it does not change anything
 * */
function buy_points(e, email, moneySum, moneyID) {
    console.log("in buy_money function");

    console.log(e);

    e.preventDefault();

    if (firstRefresh == true) {
        firstRefresh = false;
        money = moneySum;
    }

    $.ajax({
        url: "/Users/BuyPoints",

        data:
        {
            Email: email,
            Money: money
        },

        //method: "POST"
        method: e.srcElement.method
    }).done(function (result) {

        console.log("action taken: " + result)


        money += 500;

        $("#" + moneyID).text("You currently have " + money + " Gamer Points");


        Swal.fire
            ({
                type: 'success',
                title: 'You bought Gamer Points!',
                text: 'Race on gamer!'
            })



    }).fail(function (jqXHR, textStatus, errorThrown) {

        console.log("failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
        Swal.fire
            ({
                type: 'error',
                title: 'Something went wrong...',
                text: 'Try again later!'
            })
    }).always(function () {
        console.log("but I will always do this")
    });

}