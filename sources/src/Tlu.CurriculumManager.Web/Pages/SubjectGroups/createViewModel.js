function SubjectGroup(Id, Name) {
    this.id = Id;
    this.name = Name;
}

function CreateViewModel(curriculums) {
    var self = this;
    self.curriculums = curriculums;
    self.selectedCurriculum = ko.observable();
    self.subjectGroups = ko.observableArray([]);

    self.getListSubjetGroups = ko.computed(function () {
        if (self.selectedCurriculum() >= 1) {
            tlu.curriculumManager.subjectGroups.subjectGroup.getByCurriculumId(self.selectedCurriculum()).done(function (result) {
                self.subjectGroups.removeAll();
                self.subjectGroups.push(new SubjectGroup(
                    null,
                    "--"
                ));
                $.each(result, function (index, value) {
                    var name = `${value.displayOrder}. ${value.name}`;
                    if (value.parent) {
                        name = `${value.parent.displayOrder}.${value.displayOrder}. ${value.name}`;
                    }
                    self.subjectGroups.push(new SubjectGroup(
                        value.id,
                        name
                    ));
                });
            });
        }
    });
}