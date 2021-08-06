class CreateReportPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'create-report--page';
    }

    static get page() {
        return `
            <h1 class="main__page-title">Створення звіту</h1>
            <div class="create-report">
                <div class="main__col-3">
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

                    <div class="form-element form-input">
                        <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="year">Рік</label>
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
                </div>
                <div class="form-element form-select">
                    <select class="form-element-field" id="student">
                        <option class="form-select-placeholder" value="" disabled selected></option>
                    </select>
                    <div class="form-element-bar"></div>
                    <label class="form-element-label" for="student">Студент</label>
                    <small class="form-element-hint">Необхідно задати значення</small>
                </div>
                <div class="main__buttons">
                    <button class="btn create-report__create-btn">
                        <i class="btn-icon fas fa-plus"></i>
                        <span class="btn-text">Створити звіт</span>
                    </button>
                </div>
            </div>
        `;
    }

    static init() {
        this._groupCardSubscribe();
        subscribeFormElements();
    }

    static _groupCardSubscribe() {
        const courseSelect = document.querySelector('#course');
        const yearInput = document.querySelector('#year');
        const groupSelect = document.querySelector('#group');
        const studentSelect = document.querySelector('#student');
        const createBtn = document.querySelector('.create-report__create-btn');
        
        let fieldsForValidation = [
            courseSelect,
            yearInput,
            groupSelect,
            studentSelect
        ];

        courseSelect.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findGroups(courseSelect.value, yearInput.value);
            }
        });

        yearInput.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findGroups(courseSelect.value, yearInput.value);
            }
        });

        groupSelect.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findStudents(groupSelect.value);
            }
        });

        studentSelect.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        createBtn.addEventListener('click', () => {
            if (validateFields(fieldsForValidation)) {
                createReport(studentSelect.value)
            }
        })

        async function findGroups(course, year) {
            const options = await getGroupsAsOptions(course, year);
            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');

            studentSelect.value = "";
            studentSelect.innerHTML = optionDefault;
            studentSelect.classList.remove('-hasValue');
        };

        async function findStudents(groupId) {
            const options = await getStudentsAsOptions(groupId);
            studentSelect.innerHTML = options.join('');
            studentSelect.classList.remove('-hasValue');
        };

        async function createReport(studentId) {
            toggleMask();
            await apiHelper.fetchCreateReport(studentId);
            toggleMask();
        };
    }
}
