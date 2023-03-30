var product = {
    conts: {},
    functions: {
        sets: {
            setPrice: function (price) {
                $(".price-detail").fadeOut(200, function () {
                    $(".price-detail").html(price).fadeIn(200);
                });
            },
            init: function (price) {
                product.functions.sets.setPrice(price);
            }
        }


    },
    init: function () {

    }


}

product.init();