function getGroupItemWithDeleteButton(groupName, groupId) {
    if (groupId == "" || groupName == "") {
        return null;
    }

    let item = document.createElement('li');
    item.classList.add('group__item');
    item.setAttribute('data-group-id', groupId);

    let delBtn = document.createElement('i');
    delBtn.classList.add('fas', 'fa-minus-square');
    delBtn.addEventListener('click', (e) => {
        e.target.closest('ul').removeChild(item);
    });

    let span = document.createElement('span');
    span.innerText = groupName;

    item.insertAdjacentElement('beforeend', delBtn);
    item.insertAdjacentElement('beforeend', span);

    return item;
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
                <input class="item__data-subject" data-table-key="subject" type="text" value="${item?.subject ?? ""}" ${item ? 'disabled' : ''} data-is-disabled>
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
                <input type="checkbox" data-table-key="isIndividualPlanExistFall" ${item?.isIndividualPlanExistFall ? 'checked' : ''} ${item ? 'disabled' : ''} data-is-disabled>
                <select name="control-form-fall" data-table-key="controlTypeFall" id="control-fall" ${item ? 'disabled' : ''} data-is-disabled>
                    <option value="0" ${item?.controlTypeFall == 0 ? 'selected' : ''}></option>
                    <option value="1" ${item?.controlTypeFall == 1 ? 'selected' : ''}>Кредит</option>
                    <option value="2" ${item?.controlTypeFall == 2 ? 'selected' : ''}>Екзамен</option>
                </select>
            </div>
            <div class="item item__col-2">
                <input type="checkbox" data-table-key="isIndividualPlanExistSpring" ${item?.isIndividualPlanExistSpring ? 'checked' : ''} ${item ? 'disabled' : ''} data-is-disabled>
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