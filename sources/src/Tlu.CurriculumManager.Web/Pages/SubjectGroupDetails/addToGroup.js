function Curriculum(Id, Name) {
    this.id = Id;
    this.name = Name;
}

function SubjectGroup(Id, Name) {
    this.id = Id;
    this.name = Name;
}

function Subject({ id, code, name, unit, condition, hoursStudy, coefficient }) {
    this.id = id;
    this.code = code;
    this.name = name;
    this.unit = unit;
    this.condition = condition;
    this.hoursStudy = hoursStudy;
    this.coefficient = coefficient;
}

function AddToGroupViewModel() {
    var self = this;
    self.curriculums = ko.observableArray([]);
    self.selectedCurriculum = ko.observable(1);
    self.selectedSubjectGroup = ko.observable();
    self.subjectGroups = ko.observableArray([]);
    self.subjects = ko.observableArray([]);

    tlu.curriculumManager.curriculums.curriculum.getAllSelection().done(function (result) {
        $.each(result, function (index, value) {
            self.curriculums.push(new Curriculum(
                value.id,
                value.name
            ));
        });
    });

    self.getSubjectGroups = ko.computed(function () {
        if (self.selectedCurriculum() >= 1) {
            tlu.curriculumManager.subjectGroups.subjectGroup.getByCurriculumId(self.selectedCurriculum()).done(function (result) {
                self.subjectGroups.removeAll();
                $.each(result, function (index, value) {
                    self.subjectGroups.push(new SubjectGroup(
                        value.id,
                        value.name
                    ));
                });
            });
        }
    });
    //self.getSubjects = ko.computed(function () {
    //    if (self.selectedSubjectGroup() >= 1) {
    //        tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.getSubjectBySubjectGroupId(self.selectedSubjectGroup()).done(function (result) {
    //            self.subjects.removeAll();
    //            $.each(result, function (index, value) {
    //                self.subjects.push(new Subject(value));
    //            });
    //        });
    //    }
    //}); 
}

var viewModel = new AddToGroupViewModel();

ko.applyBindings(viewModel);

var delayInMilliseconds = 300; //1 second

var _dataTableChosensTable;
var _dataTableSubjectsTable;

setTimeout(function () {

    $(function () {
        var l = abp.localization.getResource('CurriculumManager');
        moment.locale(abp.localization.currentCulture.twoLetterIsoLanguageName);

        devmoba.datatables.enableIndividualColumnSearch('#SubjectsTable', [
            { name: "code" },
            { name: "name" },
            { searchDisabled: true }
        ]);

        var datatableSubjectConfig = abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            lengthMenu: [20, 30, 50, 100],
            searching: true,
            autoWidth: true,
            scrollCollapse: true,
            orderCellsTop: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.subjects.subject.getList, () => {
                return devmoba.datatables.searchHelper.getSearchConditions();
            }),
            columnDefs: [
                { targets: [1] },
                { targets: [2] },
                {
                    render: function (data, type, row, meta) {
                        //alert(row.id);
                        return `<button onclick="AddToGroupFunc(${row.id}, ${viewModel.selectedSubjectGroup()})" class="btn btn-primary">Thêm</button>`;
                    }
                }
            ],
            columns: [
                { data: "code", width: "60px", className: "content-cell" },
                { data: "name", width: "350px", className: "content-cell" }
            ]
        });

        _dataTableSubjectsTable = $('#SubjectsTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableSubjectConfig));

        //devmoba.datatables.enableIndividualColumnSearch('#ChosensTable', [
        //    { name: "code" },
        //    { name: "name" },
        //    { searchDisabled: true }
        //]);

        var datatableChosenConfig = abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            lengthMenu: [20, 30, 50, 100],
            searching: false,
            autoWidth: true,
            scrollCollapse: true,
            orderCellsTop: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.getSubjectBySubjectGroupId, () => {
                var res = devmoba.datatables.searchHelper.getSearchConditions();
                res.subjectGroupId = viewModel.selectedSubjectGroup();
                return res;
            }),
            columnDefs: [
                { targets: [1] },
                { targets: [2] },
                {
                    render: function (data, type, row, meta) {
                        return `<button onclick="RemoveGroupFunc(${row.subjectGroupDetailId})" class="btn btn-danger">Gỡ</button>`;
                    }
                }
            ],
            columns: [
                { data: "code", width: "60px", className: "content-cell" },
                { data: "name", width: "350px", className: "content-cell" }
            ]
        });

        _dataTableChosensTable = $('#ChosensTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableChosenConfig));

        
        $("#selectSubjectGroup").change(function () {
            _dataTableSubjectsTable.ajax.reload();
            _dataTableChosensTable.ajax.reload();
        });
        
    });
}, delayInMilliseconds);

function AddToGroupFunc(id, subjectGroupId) {
    tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.isExists({ subjectId: id, subjectGroupId: subjectGroupId }).then(function (result) {
        if (!result) {
            tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.create({ subjectId: id, subjectGroupId: subjectGroupId }).then(function (result) {
                if (result.id) {
                    _dataTableChosensTable.ajax.reload();
                }
            });
        } else {
            abp.notify.info("Đã tồn tại trong nhóm!");
        }
    });
    
};

function RemoveGroupFunc(id) {
    tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.delete(id).done(function (result) {
        _dataTableChosensTable.ajax.reload();
    });
};

//$(".btnAddToGroup").click(function () {
//    alert(($this).data("id"));
//});

//$(".btnRemoveToGroup").on("click", function (e) {
//    e.preventDefault();

//}); // chua co SubjectGroupDetailID