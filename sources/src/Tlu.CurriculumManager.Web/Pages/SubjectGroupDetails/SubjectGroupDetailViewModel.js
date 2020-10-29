
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

function SubjectGroupViewModel(curriculums) {
    var self = this;
    self.curriculums = curriculums;
    self.selectedCurriculum = ko.observable(1);
    self.selectedSubjectGroup = ko.observable();
    self.subjectGroups = ko.observableArray([]);
    self.subjects = ko.observableArray([]);

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

    self.getSubjects = ko.computed(function () {
        if (self.selectedSubjectGroup() >= 1) {
            //tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.getSubjectBySubjectGroupId(self.selectedSubjectGroup()).done(function (result) {
            //    self.subjects.removeAll();
            //    $.each(result, function (index, value) {
            //        self.subjects.push(new Subject(value));
            //    });
            //});
            return self.selectedSubjectGroup();
        }
    });
}
