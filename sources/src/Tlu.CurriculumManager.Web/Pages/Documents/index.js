const InLibrary = {
    NotExist: 0,
    Exist: 1
}

$(function () {
    var l = abp.localization.getResource('CurriculumManager');
    var createModal = new abp.ModalManager(abp.appPath + 'Documents/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Documents/EditModal');

    devmoba.datatables.enableIndividualColumnSearch('#DocumentsTable', [
        { name: "id" },
        { name: "name" },
        { name: "libraryCode" },
        { name: "inLibrary", options: inLibrany },
        { name: "isbn" },
        { searchDisabled: true }
    ]);

    var datatableConfig = abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        lengthMenu: [10, 20, 30],
        searching: true,
        autoWidth: true,
        scrollCollapse: true,
        orderCellsTop: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.documents.document.getList, () => {
            return devmoba.datatables.searchHelper.getSearchConditions();
        }),
        columnDefs: [
            { targets: [0] },
            { targets: [1] },
            { targets: [2] },
            {
                targets: [3],
                render: function (data, type, row, meta) {
                    if (data == InLibrary.NotExist)
                        return `<span style="color: green;">Có sẵn</span>`;
                    return `<span style="color: red;">Không có sẵn</span>`;
                }
            },
            { targets: [4] },
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
                                tlu.curriculumManager.documents.document.delete(data.record.id)
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
            { data: "id", width: "100px", className: "content-cell" },
            { data: "name", width: "350px", className: "content-cell" },
            { data: "libraryCode", width: "200px", className: "content-cell" },
            { data: "inLibrary", width: "200px", className: "content-cell" },
            { data: "isbn", width: "200px", className: "content-cell" }
        ]
    });

    var dataTable = $('#DocumentsTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDocumentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});