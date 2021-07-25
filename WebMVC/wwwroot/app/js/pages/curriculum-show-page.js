class CurriculumShowPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'curriculum--show-page';
    }

    static get page() {
        return `
            <div class="curriculum__grid">
                <div class="curriculum__find-filter curriculum__find-filter--show">
                    <h1 class="main__page-subtitle">Пошук</h1>

                    <div class="main__col-3">
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
                        <div class="form-element form-input display-none">
                            <input id="plan-id" class="form-element-field"
                                placeholder="Введіть id навчального плану" type="text" data-is-disabled disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="plan-name">Id навчального плану</label>
                        </div>
                    </div>
                    <div class="main__buttons">
                        <button class="btn curriculum__btn-find">
                            <i class="btn-icon fas fa-search"></i>
                            <span class="btn-text">Знайти навчальний план</span>
                        </button>
                    </div>
                </div>

                <div class="curriculum__info">
                    <h1 class="main__page-title">Навчальний план групи</h1>

                    <div class="curriculum__info-head">
                        <div class="form-element form-input form-element-w250">
                            <input id="plan-name" class="form-element-field"
                                placeholder="Введіть назву навчального плану" type="text" data-is-disabled disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="plan-name">Назва навчального плану</label>
                        </div>

                        <div class="curriculum__info-buttons--show">
                            <button class="btn curriculum-info__btn-edit">
                                <i class="btn-icon far fa-edit"></i>
                                <span class="btn-text">Редагувати</span>
                            </button>
                            <button class="btn curriculum-info__btn-save">
                                <i class="btn-icon fas fa-upload"></i>
                                <span class="btn-text">Зберегти</span>
                            </button>
                        </div>
                    </div>

                    ${getCurriculumTable(true)}
                </div>
            </div>
        `;
    }

    static init() {
        this._subscribePageElements();
        subscribeFormElements();
    }

    static _subscribePageElements() {
        const planTable = document.querySelector('.curriculum__table');
        const lastRow = document.querySelector('.curriculum__table-row-last');
        const addRowBtn = document.querySelector('#add-row-btn');

        const planIdInput = document.querySelector('#plan-id');
        const planNameInput = document.querySelector('#plan-name');
        const yearInput = document.querySelector('#year');
        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');

        const curriculumFindBtn = document.querySelector('.curriculum__btn-find');
        const curriculumEditBtn = document.querySelector('.curriculum-info__btn-edit');
        const curriculumSaveBtn = document.querySelector('.curriculum-info__btn-save');

        yearInput.addEventListener('change', () => {
            fetchGroups(courseSelect.value, yearInput.value);
        });

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value, yearInput.value);
        });

        curriculumFindBtn.addEventListener('click', () => {
            fetchYearPlan(groupSelect.value, yearInput.value);
        });

        curriculumEditBtn.addEventListener('click', () => {
            let items = planTable.querySelectorAll('[data-is-disabled]');

            items.forEach(item => {
                item.disabled = !item.disabled;
            });
        });

        curriculumSaveBtn.addEventListener('click', () => {
            updateYearPlan(planIdInput.value);
        });

        async function updateYearPlan(yearPlanId) {
            if (yearPlanId == "") {
                return;
            }

            let curriculum = {
                id: yearPlanId,
                name: planNameInput.value,
                year: yearInput.value,
                groupdIds: [ groupSelect.value ],
                subjectInfo: []
            };

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

            console.log(curriculum);

            const response = await fetch(`api/YearPlan/UpdateYearPlan?yearPlanId=${yearPlanId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(curriculum)
            });

            console.log(response);
            addNotification("". notificationMessages.curriculumEditSaveError);
        };

        async function fetchYearPlan(groupId, year) {
            if (groupId == "") {
                return;
            }

            const response = await fetch(`api/YearPlan/GetYearPlanByGroup?groupId=${groupId}&year=${year}`);
            console.log(response);

            if (!response.ok) {
                console.log('Year plan not found');
                return;
            }

            const yearPlan = await response.json();
            console.log(yearPlan);

            planIdInput.value = yearPlan.id;
            planIdInput.classList.add('-hasValue');
            planNameInput.value = yearPlan.name;
            planNameInput.classList.add('-hasValue');


            yearPlan.subjectInfo.forEach(r => {
                lastRow.insertAdjacentHTML('beforebegin', addCurriculumRow(r));
            });
        };

        async function fetchGroups(course, year) {
            if (course == "") {
                return;
            }

            let url = `api/Group/GetGroups?course=${course}`;
            url += year ? `&year=${year}` : "";

            const response = await fetch(url);
            const groups = await response.json();

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        addRowBtn.addEventListener('click', () => {
            if (!addRowBtn.hasAttribute('disabled')) {
                lastRow.insertAdjacentHTML('beforebegin', addCurriculumRow());
            }
        });
    }
}
