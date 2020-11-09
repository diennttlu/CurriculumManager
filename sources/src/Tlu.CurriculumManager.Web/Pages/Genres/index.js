$(function () {
    var l = abp.localization.getResource('CurriculumManager');
    var createModal = new abp.ModalManager(abp.appPath + 'Genres/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Genres/EditModal');

    moment.locale(abp.localization.currentCulture.twoLetterIsoLanguageName);

    devmoba.datatables.enableIndividualColumnSearch('#GenresTable', [
        { name: "id" },
        { name: "name" },
        { name: "facultyId", options: allFaculties },
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
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.genres.genre.getList, () => {
            return devmoba.datatables.searchHelper.getSearchConditions();
        }),
        columnDefs: [
            { targets: [0] },
            { targets: [1] },
            { targets: [2] },
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
                                tlu.curriculumManager.genres.genre.delete(data.record.id)
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
            { data: "name", width: "auto", className: "content-cell" },
            { data: "faculty.name", width: "300px", className: "content-cell" }
        ]
    });

    var dataTable = $('#GenresTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewGenreButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $(".search_c_2").select2();
});