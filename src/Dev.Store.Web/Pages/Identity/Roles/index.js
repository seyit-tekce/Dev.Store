var l = abp.localization.getResource("IdentityResource");
var roles = {
    const: {
        grid: $("#RolesGrid"),
        _identityRoleAppService: dev.store.identity.role,
        _permissionsModal: new abp.ModalManager(abp.appPath + 'AbpPermissionManagement/PermissionManagementModal'),
        _claimTypeEditModal: new abp.ModalManager({
            viewUrl: abp.appPath + 'Identity/Roles/ClaimTypeEditModal',
            modalClass: 'claimTypeEdit'
        }),
        _editModal: new abp.ModalManager(abp.appPath + 'Identity/Roles/EditModal'),
        _createModal: new abp.ModalManager(abp.appPath + 'Identity/Roles/CreateModal')
    },
    actions: {
        create: function (e) {
            roles.const._createModal.open();
            roles.const._createModal.onResult(function () {
                roles.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        edit: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            roles.const._editModal.open({
                id: recordId
            });
            roles.const._editModal.onResult(function () {
                roles.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        claims: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            roles.const._claimTypeEditModal.open({
                id: recordId
            });
            roles.const._claimTypeEditModal.onResult(function () {
                roles.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        permissions: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            var recordName = roles.const.grid.data("kendoGrid").dataSource.data().filter(c => c.Id == recordId).map(a => a.Name)[0]
            e.preventDefault();
            roles.const._permissionsModal.open({
                providerName: 'R',
                providerKey: recordName
            });

            roles.const._permissionsModal.onResult(function () {
                roles.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        changeHistory: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            abp.auditLogging.openEntityHistoryModal(
                "Volo.Abp.Identity.IdentityRole",
                recordId
            );
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeleteConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        roles.const._identityRoleAppService.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
                                roles.const.grid.find(".k-pager-refresh").trigger("click");
                            });
                    }
                });
        }

    },
    init: function () {


    }
};


