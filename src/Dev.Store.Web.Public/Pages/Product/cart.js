$(function () {
    var cart = {
        consts: {
            items: [],
            storage: localStorage

        },
        functions: {
            add: function (e) {
                $(e).find("a").html('<i class="fa fa-spinner me-1" aria-hidden="true"></i>')
                var productId = $("#productSection").data("productid");
                if (productId == null) {
                    return;
                }
                dev.store.cartProducts.cartProduct.addToChart({
                    productId: productId,
                    amount: 1,
                }).then((e) => {
                    $(e).find("a").html('Sepete Eklendi')
                    location.href = "/cart";
                });


            },
            remove: function () {

            },



        }






    }


    window.cart = cart;

});