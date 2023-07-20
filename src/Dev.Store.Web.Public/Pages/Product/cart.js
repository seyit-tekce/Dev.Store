$(function () {
    var cart = {
        consts: {
            items: [],
            storage: localStorage

        },
        functions: {
            add: function (prd) {
                var productId = $("#productSection").data("productid");
                if (productId == null) {
                    return;
                }
                dev.store.cartProducts.cartProduct.create({
                    productId: productId,
                    amount: 1,
                }).then(x => {

                    debugger;


                });


            },
            remove: function () {

            },



        }






    }


    window.cart = cart;

});