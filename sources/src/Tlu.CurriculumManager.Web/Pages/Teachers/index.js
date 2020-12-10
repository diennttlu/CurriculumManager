$(function () {
    var l = abp.localization.getResource('CurriculumManager');
    var createModal = new abp.ModalManager(abp.appPath + 'Teachers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Teachers/EditModal');

    moment.locale(abp.localization.currentCulture.twoLetterIsoLanguageName);

    devmoba.datatables.enableIndividualColumnSearch('#TeachersTable', [
        { name: "id" },
        { name: "name" },
        { name: "position" },
        { name: "genre" },
        { searchDisabled: true }
    ]);

    var datatableConfig = abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: false,
        paging: true,
        lengthMenu: [10, 20, 30],
        searching: true,
        autoWidth: true,
        scrollCollapse: true,
        orderCellsTop: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.teachers.teacher.getList, () => {
            return devmoba.datatables.searchHelper.getSearchConditions();
        }),
        columnDefs: [
            {
                targets: [0]
            },
            {
                targets: [1]
            },
            {
                targets: [2],
                render: function(data, type, row, meta) {
                    return data == 0 ? "Giảng viên" : "Trưởng bộ môn";
                }
            },
            { targets: [3] },
            {
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            action: function (data) {
                                editModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            confirmMessage: function (data) {
                                return l('RecordDeletionConfirmationMessage', data.record.name);
                            },
                            action: function (data) {
                                tlu.curriculumManager.teachers.teacher.delete(data.record.id)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();
                                    });
                            }
                        }
                    ]
                }
            }
        ],
        columns: [
            { data: "id", width: "30px", className: "content-cell" },
            { data: "name", width: "300px", className: "content-cell" },
            { data: "position", width: "300px", className: "content-cell" },
            { data: "genre.name", width: "300px", className: "content-cell" }
        ]
    });

    var dataTable = $('#TeachersTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTeacherButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});