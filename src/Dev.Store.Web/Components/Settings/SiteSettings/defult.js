(function ($) {
    $("#SiteSetting").on('submit', function (event) {
       
        event.preventDefault();
        if (!$(this).valid()) {
            return;
        }
        var form = $(this).serializeFormToObject();
        window.dev.store.settings.siteSetting.update(form).then(function (result) {
            $(document).trigger("AbpSettingSaved");
        });

    });

})(jQuery);
