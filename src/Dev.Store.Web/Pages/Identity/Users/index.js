var l = abp.localization.getResource("DevStore");
users = {
    const: {
        _identityUserAppService: volo.abp.identity.identityUser,
        _identityUserWithRolesAppService: window.dev.store.identity.user,
        _claimTypeEditModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/ClaimTypeEditModal', modalClass: 'claimTypeEdit' }),
        _editModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/EditModal', modalClass: 'editUser' }),
        _createModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/CreateModal', modalClass: 'createUser' }),
        _permissionsModal: new abp.ModalManager(abp.appPath + 'AbpPermissionManagement/PermissionManagementModal'),
        _changeUserPasswordModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/SetPassword', modalClass: 'changeUserPassword' }),
        _lockoutModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/Lock', modalClass: 'lock' }),
        _twoFactorModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/TwoFactor', modalClass: 'twoFactor' }),
        grid: $("#UsersGrid")
    },
    actions: {
        create: function (e) {
            users.const._createModal.onOpen(function () {
                $("#UserInfo_Password").val("*");
                $("#UserInfo_Password").parents(".form-group").hide();
            });
            users.const._createModal.open();
            users.const._createModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        edit: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._editModal.open({
                id: recordId
            });

            users.const._editModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        claims: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._claimTypeEditModal.open({
                id: recordId
            });
            users.const._claimTypeEditModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        lock: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._lockoutModal.open({
                id: recordId
            });

            users.const._lockoutModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        unlock: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            users.const._identityUserAppService
                .unlock(recordId)
                .then(function () {
                    abp.notify.success(l("UserUnlocked"));
                    users.const.grid.data('kendoGrid').dataSource.read();
                    users.const.grid.data('kendoGrid').refresh();
                });

        },
        permissions: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._permissionsModal.open({
                providerName: 'U',
                providerKey: recordId
            });

            users.const._permissionsModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        setPassword: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._changeUserPasswordModal.open({
                id: recordId
            });

            users.const._changeUserPasswordModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },

        twoFactor: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._twoFactorModal.open({
                id: recordId
            });
            users.const._twoFactorModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        changeHistory: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            abp.auditLogging.openEntityHistoryModal(
                "Volo.Abp.Identity.IdentityUser",
                recordId
            );

        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeleteConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        users.const._identityUserAppService.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
                                users.const.grid.find(".k-pager-refresh").trigger("click");
                            });
                    }
                });
        }
    },
    init: function () {


    }
};


