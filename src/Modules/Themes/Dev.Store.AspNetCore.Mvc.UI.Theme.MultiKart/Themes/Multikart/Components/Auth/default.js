$(function () {
    var loginModal = new abp.ModalManager(abp.appPath + 'Login/Index');
    var mainBar = new abp.WidgetManager('[data-widget-name="Auth"]');

    loginModal.onResult(function () {
        mainBar.refresh();
    });
    $(document).on("click", "#loginbutton", function () {
        loginModal.open();
    }).on("click", "#logout", function () {
        $.ajax({
            url: "/api/account/logout", success: function () {
                mainBar.refresh();
            }
        });
    })
});

