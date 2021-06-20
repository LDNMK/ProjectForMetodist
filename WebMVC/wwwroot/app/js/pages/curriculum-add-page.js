class CurriculumAddPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'curriculum--add-page';
    }

    static _counter = 1;

    static get page() {
        return `
            <div class="curriculum__grid">
                <div class="curriculum__find">
                    <div class="curriculum__find-filter">
                        <h1 class="main__page-subtitle">Пошук</h1>

                        <div class="form-element form-input">
                            <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="year">Рік</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="course">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="course">Курс</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="group">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="group">Група</label>
                        </div>

                        <div class="main__buttons">
                            <button class="btn curriculum-group__btn-add">
                                <i class="btn-icon fa fa-plus"></i>
                                <span class="btn-text">Додати групу</span>
                            </button>
                        </div>
                    </div>
                    <div class="curriculum__find-list">
                        <h1 class="main__page-subtitle">Список груп</h1>
                        <ul class="curriculum__find-groups">

                        </ul>
                    </div>
                </div>

                <div class="curriculum__info">
                    <h1 class="main__page-title">Навчальний план студента</h1>

                    <div class="curriculum__info-head">
                        <div class="form-element form-input">
                            <input id="plan-name" class="form-element-field"
                                placeholder="Введіть назву навчального плану" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="plan-name">Назва навчального плану</label>
                        </div>

                        <button class="btn curriculum__info-add-btn">
                            <i class="btn-icon fa fa-plus"></i>
                            <span class="btn-text">Створити навчальний план</span>
                        </button>
                    </div>

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
                                <button class="btn curriculum__table-row-btn" id="add-row-btn">
                                    <i class="btn-icon item__data-btn-add far far fa-plus-square"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        `;
    }

    static init() {
        this._groupCardSubscribe();
        subscribeFormElements();
    }

    static _groupCardSubscribe() {
        const list = document.querySelector('.curriculum__find-groups');

        const planTable = document.querySelector('.curriculum__table');
        const lastRow = document.querySelector('.curriculum__table-row-last');
        const addRowBtn = document.querySelector('#add-row-btn');
        
        const yearInput = document.querySelector('#year');
        const planNameInput = document.querySelector('#plan-name');

        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const groupAddBtn = document.querySelector('.curriculum-group__btn-add');
        const curriculumSaveBtn = document.querySelector('.curriculum__info-add-btn');

        yearInput.addEventListener('change', () => {
            fetchGroups(courseSelect.value, yearInput.value);
        });

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        });

        groupAddBtn.addEventListener('click', () => {
            let item = getGroupItemWithDeleteButton(groupSelect.options[group.selectedIndex].text, groupSelect.value);
            if (item) {
                list.insertAdjacentElement('beforeend', item);
            }
        });

        curriculumSaveBtn.addEventListener('click', () => {
            if (yearInput == '' || planNameInput == '')
                return alert('bad');
            let curriculum = {};
            let rows = planTable.querySelectorAll('.curriculum__table-row-data');

            curriculum.subjectInfo = [];
            for (let i = 0; i < rows.length; i++) {
                let data = rows[i].querySelectorAll('[data-table-key]');

                let rowJson = {};
                for (let j = 0; j < data.length; j++) {
                    rowJson[data[j].getAttribute('data-table-key')] = data[j][data[j].type == "checkbox" ? 'checked' : 'value'];
                }

                curriculum.subjectInfo.push(rowJson);
            }

            curriculum.name = planNameInput.value;
            curriculum.year = yearInput.value;
            curriculum.groupIds = [...list.children]
                .map(x => +x.getAttribute('data-group-id'))
                .filter((v, i, a) => a.indexOf(v) === i);

            console.log(curriculum);

            const response = await fetch(`api/YearPlan/AddYearPlan`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(curriculum)
            });
        });

        async function fetchGroups(course, year) {
            if (course == "") {
                return;
            }

            let url = `api/Group/GetListOfGroups?course=${course}`;
            url += year ? `&year=${year}` : "";

            const response = await fetch(url);
            const groups = await response.json();

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        addRowBtn.addEventListener('click', () => {
            lastRow.insertAdjacentHTML('beforebegin', getRow());
        });

        function getRow(item) {
            return `
                <div class="curriculum__table-row curriculum__table-row-data">
                    <div class="item item__no-border">
                        <i class="item__data-btn-remove far fa-minus-square" onclick="removeCurriculumRow(this);"></i>
                    </div>
                    <div class="item">
                        <input class="item__data-subject" data-table-key="name" type="text" value="${item?.name ?? ""}">
                    </div>
                    <div class="item item__col-2">
                        <div class="item__subitem">
                            <label for="hours">Годин</label>
                            <input class="item__data-hours" data-table-key="hours" type="text" value="${item?.hours ?? ""}" id="hours"
                                pattern="[0-9]">
                        </div>
                        <div class="item__subitem">
                            <label for="ects">Кредитів</label>
                            <input class="item__data-credits" data-table-key="ects" type="text" value="${item?.ects ?? ""}" id="ects"
                                pattern="[0-9]">
                        </div>
                    </div>
                    <div class="item item__col-2">
                        <input type="checkbox" data-table-key="isIndividualTaskExistFall" ${item?.fall?.isActive ? 'checked' : ''}>
                        <select name="control-form-fall" data-table-key="controlTypeFall" id="control-fall">
                            <option value="0" ${item?.fall?.control == 0 ? 'selected' : ''}></option>
                            <option value="1" ${item?.fall?.control == 1 ? 'selected' : ''}>Кредит</option>
                            <option value="2" ${item?.fall?.control == 2 ? 'selected' : ''}>Екзамен</option>
                        </select>
                    </div>
                    <div class="item item__col-2">
                        <input type="checkbox" data-table-key="isIndividualTaskExistSpring" ${item?.spring?.isActive ? 'checked' : ''}>
                        <select name="control-form-spring" data-table-key="controlTypeSpring" id="control-spring">
                            <option value="0" ${item?.spring?.control == 0 ? 'selected' : ''}></option>
                            <option value="1" ${item?.spring?.control == 1 ? 'selected' : ''}>Кредит</option>
                            <option value="2" ${item?.spring?.control == 2 ? 'selected' : ''}>Екзамен</option>
                        </select>
                    </div>
                    <div class="item">
                        <input class="item__data-department" data-table-key="department" type="text" value="${item?.department ?? ""}">
                    </div>
                </div>
            `;
        }


    }
}
