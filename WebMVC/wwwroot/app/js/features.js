const apiHelper = new ApiHelper();

async function getGroupsAsOptions(course, year) {
    let options = [];

    const groups = await apiHelper.fetchGetGroups(course, year);
    if (groups) {
        options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
        options.push(optionDefault);
    }

    return options;
}

async function getStudentsAsOptions(groupId, year) {
    let options = [];

    const students = await apiHelper.fetchGetStudents(groupId, year);
    if (students) {
        options = students.map(x => `<option value=${x.studentId}>${x.studentName}</option>`);
        options.push(optionDefault);
    }

    return options;
}

async function getSpecialitiesAsOptions(degreeId) {
    let options = [];

    const specialities = await apiHelper.fetchGetSpecialities(degreeId);
    if (specialities) {
        options = specialities.map(x => `<option value=${x.id}>${x.name}</option>`);
        options.push(optionDefault);
    }

    return options;
}
