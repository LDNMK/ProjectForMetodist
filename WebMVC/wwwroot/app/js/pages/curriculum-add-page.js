class CurriculumAddPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'curriculum--add-page';
    }

    static get page() {
        return `
            <div class="curriculum__grid">
                <div class="curriculum__find">
                    <div class="curriculum__find-filter curriculum__find-filter--add">
                        <h1 class="main__page-subtitle">Пошук</h1>
                        
                        <div class="form-element form-select">
                            <select class="form-element-field" id="course">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="course">Курс</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="group">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="group">Група</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
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
                        <div class="form-element form-input form-element-w250">
                            <input id="plan-name" class="form-element-field"
                                placeholder="Введіть назву навчального плану" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="plan-name">Назва навчального плану</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input form-element-w170">
                            <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="year">Рік</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
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

    static buttons = {
        "remove": "<i class='remove fas fa-minus-square' onClick='CurriculumAddPage.removeGroupFromList(this)'></i>"
    };

    static removeGroupFromList(e) {
        const parent = e.closest('.group__item');
        parent.remove();
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

        yearInput.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        groupSelect.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        courseSelect.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findGroups(courseSelect.value);
            }
        });

        planNameInput.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        groupAddBtn.addEventListener('click', (e) => {
            if (validateFields([courseSelect, groupSelect], true)) {
                let item = getGroupItemWithButton(groupSelect.options[group.selectedIndex].text, groupSelect.value, CurriculumAddPage.buttons['remove']);
                if (item) {
                    list.insertAdjacentHTML('beforeend', item);
                }
            }
        });

        curriculumSaveBtn.addEventListener('click', () => {
            if (!validateFields([yearInput, planNameInput], true)) {
                return;
            }

            let curriculum = {};
            curriculum.subjectInfo = [];

            let rows = planTable.querySelectorAll('.curriculum__table-row-data');
            for (let i = 0; i < rows.length; i++) {
                let data = rows[i].querySelectorAll('[data-table-key]');

                let rowJson = {};
                for (let j = 0; j < data.length; j++) {
                    if ((data[j].tagName == "SELECT" || data[j].tagName == "INPUT") && data[j].value == "") {
                        rowJson[data[j].getAttribute('data-table-key')] = null;
                        continue;
                    }
                    
                    rowJson[data[j].getAttribute('data-table-key')] = data[j].value;
                }

                curriculum.subjectInfo.push(rowJson);
            }

            curriculum.name = planNameInput.value;
            curriculum.year = yearInput.value;
            curriculum.groupIds = [...list.children]
                .map(x => +x.getAttribute('data-group-id'))
                .filter((v, i, a) => a.indexOf(v) === i);

            createYearPlan(curriculum);
        });

        async function createYearPlan(data) {
            apiHelper.fetchCreateYearPlan(data);
        }

        async function findGroups(course) {
            if (course == "") {
                return;
            }

            const options = await getGroupsAsOptions(course);
            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        addRowBtn.addEventListener('click', () => {
            lastRow.insertAdjacentHTML('beforebegin', addCurriculumRow());
        });
    }
}
