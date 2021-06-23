function getGroupItemWithButton(groupName, groupId, button) {
    if (groupId == "" || groupName == "" || button == undefined) {
        return null;
    }

    return `
        <li class="group__item" data-group-id=${groupId}>
            ${button}
            <span>${groupName}</span>
        </li>
    `;
}

function removeCurriculumRow(e) {
    if (!e.hasAttribute('disabled')) {
        let row = e.closest('.curriculum__table-row-data');
        row.remove();
    }
}

function addCurriculumRow(item) {
    return `
        <div class="curriculum__table-row curriculum__table-row-data" >
            <div class="item item__no-border">
                <button class="btn curriculum__table-row-btn" id="remove-row-btn" onclick="removeCurriculumRow(this);" ${item ? 'disabled' : ''} data-is-disabled>
                    <i class="btn-icon far fa-minus-square"></i>
                </button>
            </div>
            <div class="item">
                <input class="item__data-subject" data-table-key="name" type="text" value="${item?.name ?? ""}" ${item ? 'disabled' : ''} data-is-disabled>
            </div>
            <div class="item item__col-2">
                <div class="item__subitem">
                    <label for="hours">Годин</label>
                    <input class="item__data-hours" data-table-key="hours" type="text" value="${item?.hours ?? ""}" id="hours"
                        pattern="[0-9]" ${item ? 'disabled' : ''} data-is-disabled>
                </div>
                <div class="item__subitem">
                    <label for="ects">Кредитів</label>
                    <input class="item__data-credits" data-table-key="ects" type="text" value="${item?.ects ?? ""}" id="ects"
                        pattern="[0-9]" ${item ? 'disabled' : ''} data-is-disabled>
                </div>
            </div>
            <div class="item item__col-2">
                <input type="checkbox" data-table-key="isIndividualTaskExistFall" ${item?.isIndividualTaskExistFall ? 'checked' : ''} ${item ? 'disabled' : ''} data-is-disabled>
                <select name="control-form-fall" data-table-key="controlTypeFall" id="control-fall" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="0" ${item?.controlTypeFall == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.controlTypeFall == 1 ? 'selected' : ''}>Кредит</option>
                    <option value="2" ${item?.controlTypeFall == 2 ? 'selected' : ''}>Екзамен</option>
                </select>
            </div>
            <div class="item item__col-2">
                <input type="checkbox" data-table-key="isIndividualTaskExistSpring" ${item?.isIndividualTaskExistSpring ? 'checked' : ''} ${item ? 'disabled' : ''} data-is-disabled>
                <select name="control-form-spring" data-table-key="controlTypeSpring" id="control-spring" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="0" ${item?.controlTypeSpring == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.controlTypeSpring == 1 ? 'selected' : ''}>Кредит</option>
                    <option value="2" ${item?.controlTypeSpring == 2 ? 'selected' : ''}>Екзамен</option>
                </select>
            </div>
            <div class="item">
                <input class="item__data-department" data-table-key="department" type="text" value="${item?.department ?? ""}" ${item ? 'disabled' : ''} data-is-disabled>
            </div>
        </div>
    `;
}

function getCurriculumTable(disable = false) {
    return `
        <div class="curriculum__table">
            <div class="curriculum__table-row curriculum__table-head">
                <div class="item item__no-border"></div>
                <div class="item"><span>Назва дисципліни</span></div>
                <div class="item"><span>Кількість годин/кредитів ECTS</span></div>
                <div class="item item__grid">
                    <p>Осінній семестр</p>
                    <div class="item__col-2">
                        <span>Індивідуальне завдання</span>
                        <span>Форма контролю</span>
                    </div>
                </div>
                <div class="item item__grid">
                    <p>Весняний семестр</p>
                    <div class="item__col-2">
                        <span>Індивідуальне завдання</span>
                        <span>Форма контролю</span>
                    </div>
                </div>
                <div class="item"><span>Кафедра</span></div>
            </div>

            <div class="curriculum__table-row curriculum__table-row-last">
                <div class="item item__no-border item__full-row">
                    <button class="btn curriculum__table-row-btn" id="add-row-btn" ${disable ? 'disabled' : ''} data-is-disabled>
                        <i class="btn-icon far fa-plus-square"></i>
                    </button>
                </div>
            </div>
        </div>
    `;
}

function getProgressSubjectCell(subject) {
    return `
        <li class="progress__row-cell progress__row-cell-subject"><span data-subject-id="${subject.id}">${subject.name}</span></li>
    `;
}

function getProgressStudentRow(student, subjects) {
    return `
        <div class="progress__row progress__row-student" data-student-id="${student.id}">
            <div class="progress__row-cell progress__row-cell-student">
                <span>${student.name}</span>
            </div>
            <ul class="progress__row-cell progress__row-cell-marks">
                ${
                    subjects.map(s => {
                        return `
                            <li class="progress__row-cell progress__row-cell-mark">
                                <input class="progress__row-cell-input" type="text" value="${student.subjects.find(x => x.id == s.id)?.mark ?? ''}" pattern="[0-9]" data-subject-id="${s.id}" disabled>
                            </li>
                        `;
                    }).join('')
                }
            </ul>
            <div class="progress__row-cell progress__row-cell-final-mark">
                <span data-student-final>
                    ${Math.round(student.subjects
                        .map(x => x.mark)
                        .reduce((sum, mark) => sum += mark) / student.subjects.length)
                    }
                </span>
            </div>
        </div>
    `;
}