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

                    <div class="main__col-4">
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
                        <div class="form-element form-select">
                            <select class="form-element-field" id="plan">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="plan">План</label>
                        </div>
                    </div>
                    <div class="main__buttons">
                        <button class="btn curriculum__btn-find">
                            <i class="btn-icon fas fa-search"></i>
                            <span class="btn-text">Знайти</span>
                        </button>
                    </div>
                </div>

                <div class="curriculum__info">
                    <h1 class="main__page-title">Навчальний план студента</h1>

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

        const planNameInput = document.querySelector('#plan-name');
        const yearInput = document.querySelector('#year');
        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const yearPlanSelect = document.querySelector('#plan');

        const curriculumFindBtn = document.querySelector('.curriculum__btn-find');
        const curriculumEditBtn = document.querySelector('.curriculum-info__btn-edit');
        const curriculumSaveBtn = document.querySelector('.curriculum-info__btn-save');

        yearInput.addEventListener('change', () => {
            fetchGroups(courseSelect.value, yearInput.value);
        });

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        });

        groupSelect.addEventListener('change', () => {
            fetchYearPlans(groupSelect.value);
        });

        curriculumFindBtn.addEventListener('click', () => {
            //let response = {
            //    planId: 1,
            //    name: "Plan 2021",
            //    data: [
            //        {
            //            controlTypeFall: "1",
            //            controlTypeSpring: "0",
            //            department: "Department 1",
            //            ects: "2",
            //            hours: "12",
            //            isIndividualPlanExistFall: true,
            //            isIndividualPlanExistSpring: false,
            //            subject: "Subject 1"
            //        },
            //        {
            //            controlTypeFall: "0",
            //            controlTypeSpring: "2",
            //            department: "Department 2",
            //            ects: "2",
            //            hours: "35",
            //            isIndividualPlanExistFall: false,
            //            isIndividualPlanExistSpring: true,
            //            subject: "Subject 2"
            //        }
            //    ]
            //};

            fetchYearPlan(yearPlanSelect.value);
        });

        curriculumEditBtn.addEventListener('click', () => {
            let items = planTable.querySelectorAll('[data-is-disabled]');

            items.forEach(item => {
                item.disabled = !item.disabled;
            });
        });

        curriculumSaveBtn.addEventListener('click', () => {
            updateYearPlan(yearPlanSelect.value);
        });

        async function updateYearPlan(yearPlanId) {
            if (yearPlanId == "") {
                return;
            }

            console.log(yearPlan);

            let yearPlan //

            const response = await fetch(`api/YearPlan/UpdateYearPlan?yearPlanId=${yearPlanId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(yearPlan)
            });
        };

        async function fetchYearPlan(yearPlanId) {
            if (yearPlanId == "") {
                return;
            }

            let url = `api/YearPlan/ShowYearPlan?yearPlanId=${yearPlanId}`;
            // get plan
            const response = await fetch(url);
            const yearPlan = await response.json();

            planNameInput.value = yearPlan.name;
            planNameInput.classList.add('-hasValue');

            console.log(yearPlan);

            yearPlan.subjectInfo.forEach(r => {
                lastRow.insertAdjacentHTML('beforebegin', addCurriculumRow(r));
            });
        };

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

        async function fetchYearPlans(group) {
            if (group == "") {
                return;
            }

            let url = `api/YearPlan/GetYearPlanByGroup?groupId=${group}`;

            const response = await fetch(url);
            const yearPlan = await response.json();

            console.log(yearPlan);

            let options = yearPlan.map(x =>`<option value=${x.planId}>${x.planName}</option>`);
            options.push(optionDefault);

            yearPlanSelect.innerHTML = options.join('');
            yearPlanSelect.classList.remove('-hasValue');
        };

        addRowBtn.addEventListener('click', () => {
            if (!addRowBtn.hasAttribute('disabled')) {
                lastRow.insertAdjacentHTML('beforebegin', addCurriculumRow());
            }
        });
    }
}
