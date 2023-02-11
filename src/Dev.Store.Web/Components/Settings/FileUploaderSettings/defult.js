(function ($) {
    $("#FileSettingForm").on('submit', function (event) {
        debugger
        event.preventDefault();
        if (!$(this).valid()) {
            return;
        }

        var form = $(this).serializeFormToObject();
        window.dev.store.settings.fileUploaderSetting.update(form).then(function (result) {
            $(document).trigger("AbpSettingSaved");
        });

    });

})(jQuery);