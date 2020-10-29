function SubjectGroup( Id, Name, Note, CurriculumId, ParentId, UnitTotal ) {
    this.id = Id;
    this.name = Name;
    this.note = Note;
    this.curriculumId = CurriculumId;
    this.parentId = ParentId;
    this.unitTotal = UnitTotal;
}

function Curriculum(Id, Name) {
    this.id = Id;
    this.name = Name;
}

function EditViewModel(id, curriculumId, parentId) {
    var self = this;
    self.curriculums = ko.observableArray([new Curriculum(curriculumId, "")]);

    self.subjectGroups = ko.observableArray([new SubjectGroup(parentId, "")]);
    self.subjectGroup = ko.observable();
    self.selectedCurriculum = ko.observable(curriculumId);
    self.selectedSubjectGroup = ko.observable(parentId);


    self.subjectGroup(tlu.curriculumManager.subjectGroups.subjectGroup.get(id).done(function (value) {
        self.subjectGroup(new SubjectGroup(
            value.id,
            value.name,
            value.note,
            value.curriculumId,
            value.parentId,
            value.UnitTotal));
        curriculumId = value.curriculumId;
    }));
    
    tlu.curriculumManager.curriculums.curriculum.getAllSelection().done(function (result) {
        self.curriculums.push(new Curriculum(null, "--"));
        $.each(result, function (index, value) {
            self.curriculums.push(new Curriculum(
                value.id,
                value.name
            ));
        });
    });

    self.getListSubjetGroups = ko.computed(function () {
        if (self.selectedCurriculum() >= 1) {
            tlu.curriculumManager.subjectGroups.subjectGroup.getByCurriculumId(self.selectedCurriculum()).done(function (result) {
                self.subjectGroups.removeAll();
                self.subjectGroups.push(new SubjectGroup(
                    null,
                    "--"
                ));
                $.each(result, function (index, value) {
                    self.subjectGroups.push(new SubjectGroup(
                        value.id,
                        value.name,
                        value.note,
                        value.curriculumId,
                        value.parentId,
                        value.UnitTotal
                    ));
                });
            });
        }
    });
}