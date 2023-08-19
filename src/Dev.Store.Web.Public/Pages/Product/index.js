var product = {
    conts: {
        product: {
        }

    },
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
        },
        sizes: {
            setPrice: function (price) {
                $(".price-detail").html(price);
            }
        },
        cart: {
            addToChart: function (e) {
                window.cart.functions.add(e);
            }
        }
    },
    init: function () {
    }
}
$(".size-slick").slick({
    infinite: false,
    centerPadding: '20px',
    slidesToShow: 3,
    slidesToScroll: 1,
    centerMode: true,
    variableWidth: true,
    focusOnSelect: true
});
product.init();
$(document).ready(function () {
    if ($(window).width() > 991) {
        $(".product_img_scroll, .pro_sticky_info").stick_in_parent();
    }
}).on("click", '[data-size-price]', function (e) {
    e.preventDefault();
    product.functions.sizes.setPrice($(this).attr('data-size-price'));
    $(".size-active").removeClass("size-active").addClass("size-deactive");
    $(this).find("img").addClass("size-active").removeClass("size-deactive");
});

$(function () {
    $('#product-sizes').owlCarousel({
        loop: false,
        margin: 10,
        nav: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 3,
                nav: false
            },
            1000: {
                items: 5,
                nav: true,
                loop: false
            }
        }
    })

})

