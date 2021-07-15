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
            <div class="item display-none">
                <input class="item__data-subject-id" data-table-key="id" type="text" value="${item?.id ?? 0}" ${item ? 'disabled' : ''} data-is-disabled>
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
                <select name="control-form-fall" data-table-key="individualTaskFallType" id="individual-task-fall" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="" ${item?.individualTaskFallType == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.individualTaskFallType == 1 ? 'selected' : ''}>1</option>
                    <option value="2" ${item?.individualTaskFallType == 2 ? 'selected' : ''}>2</option>
                    <option value="3" ${item?.individualTaskFallType == 3 ? 'selected' : ''}>КР</option>
                </select>
                <select name="control-form-fall" data-table-key="controlFallType" id="control-fall" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="0" ${item?.controlFallType == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.controlFallType == 1 ? 'selected' : ''}>Залік</option>
                    <option value="2" ${item?.controlFallType == 2 ? 'selected' : ''}>Екзамен</option>
                </select>
            </div>
            <div class="item item__col-2">
                <select name="control-form-fall" data-table-key="individualTaskSpringType" id="individual-task-spring" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="" ${item?.individualTaskSpringType == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.individualTaskSpringType == 1 ? 'selected' : ''}>1</option>
                    <option value="2" ${item?.individualTaskSpringType == 2 ? 'selected' : ''}>2</option>
                    <option value="3" ${item?.individualTaskSpringType == 3 ? 'selected' : ''}>КР</option>
                </select>
                <select name="control-form-spring" data-table-key="controlSpringType" id="control-spring" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="0" ${item?.controlSpringType == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.controlSpringType == 1 ? 'selected' : ''}>Залік</option>
                    <option value="2" ${item?.controlSpringType == 2 ? 'selected' : ''}>Екзамен</option>
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
                    ${
                        Math.round(student.subjects
                            .map(x => x.mark)
                            ?.reduce((sum, mark) => sum += mark, 0) / student.subjects.length)
                    }
                         
                    
                </span>
            </div>
        </div>
    `;
}

function getTransferStudentHead() {
    return `
        <li class="transfer__student-head">
            <span>
                ФІО
            </span>
            <span>
                Статус
            </span>
            <span>
                Що зробити
            </span>
        </li>
    `;
}

function getTransferStudentRow(student) {
    return `
        <li class="transfer__student-row">
            <span class="display-none" data-transfer-key="id">${student.id}</span>
            <span>
                <span data-transfer-key="lastName">${student.lastName}</span>
                <span data-transfer-key="firstName">${student.firstName}</span>
                <span data-transfer-key="patronymic">${student.patronymic}</span>
            </span>
            <select name="status" data-transfer-key="stateId">
                <option value="1" ${student.stateId == 1 ? "selected" : ""}>Перевести з групою</option>
                <option value="2" ${student.stateId == 2 ? "selected" : ""}>Академ. відпустка</option>
                <option value="3" ${student.stateId == 3 ? "selected" : ""}>Перехід в іншу групу</option>
                <option value="4" ${student.stateId == 4 ? "selected" : ""}>Не закрив сесію</option>
                <option value="5" ${student.stateId == 5 ? "selected" : ""}>Відрахований</option>
                <option value="6" ${student.stateId == 6 ? "selected" : ""}>Здобув степінь</option>
            </select>
            <select name="action" data-transfer-key="actionId">
                <option value=""></option>
                <option value="1">Перевести з групою</option>
                <option value="2">Академ. відпустка</option>
                <option value="3">Залиш. на наст. рік</option>
                <option value="4">Відрахувати</option>
                <option value="5">Відновити</option>
            </select>
        </li>
    `;
}