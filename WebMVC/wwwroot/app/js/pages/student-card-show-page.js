class StudentCardShowPage extends Page {
    constructor() {
        super();
    }

    static _dataObjKeyFields = null;

    static get is() {
        return 'student-card--show-page';
    }

    static get page() {
        return `
            <div class="student-card__show">
                <div class="student-card__show-general">
                    <h1 class="main__page-title">Пошук</h1>
                    <div class="student-card__show-grid">
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
                        <div class="form-element form-input">
                            <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="year">Рік</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="student">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="student">Студент</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__buttons">
                        <button class="btn student-card__show-btn-find">
                            <i class="btn-icon fas fa-search"></i>
                            <span class="btn-text">Знайти студента</span>
                        </button>
                    </div>
                </div>

                <div class="student-card__show-info">
                    <h1 class="main__page-title">Навчальна картка студента</h1>
                    <div class="main__buttons">
                        <button class="btn student-card__show-btn-edit">
                            <i class="btn-icon fas fa-user-edit"></i>
                            <span class="btn-text">Редагувати</span>
                        </button>
                        <button class="btn student-card__show-btn-save">
                            <i class="btn-icon fas fa-save"></i>
                            <span class="btn-text">Зберегти</span>
                        </button>
                    </div>

                    <div class="main__col">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="speciality" data-obj-key="specialityId" data-required disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="speciality">Спеціальність</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="degree" data-obj-key="degreeId" data-required disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Бакалавр</option>
                                <option value="2">Магістр</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="degree">Рівень вищої
                                освіти/освітньо-кваліфікаційний
                                рівень</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="surname" data-obj-key="lastName" class="form-element-field" placeholder="Введіть прізвище"
                                type="text" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="surname">Прізвище</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="name" data-obj-key="firstName" class="form-element-field" placeholder="Введіть ім'я" type="text" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="name">Ім'я</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="first-name" data-obj-key="patronymic" class="form-element-field" placeholder="Введіть по-батькові"
                                type="text" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="first-name">По-батькові</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <!--
                    <div class="main__col-3 student-card__show-average-score">
                        <div class="form-element form-input">
                            <input id="average-score" class="form-element-field" placeholder="Введіть середній бал"
                                type="text" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="average-score">Середній бал</label>

                            <button class="btn student-card__show-average-score-btn" disabled>
                                <i class="fas fa-calculator"></i>
                            </button>
                        </div>
                    </div>
                    -->

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="birthdate" data-obj-key="birthdate" class="form-element-field" placeholder="Введіть дату народження"
                                type="date" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthdate">Дата народження</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="birthday-place" data-obj-key="birthPlace" class="form-element-field"
                                placeholder="Введіть місце народження" type="text" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthday-place">Місце народження</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="nationality" class="form-element-field" placeholder="Введіть громадянство"
                                type="text" data-obj-key="citizenship" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="nationality">Громадянство</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="marital-status" data-obj-key="maritalStatusId" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Інформація відсутня</option>
                                <option value="2">Одружений/Заміжня</option>
                                <option value="3">Не одружений/Не заміжня</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="marital-status">Сімейний стан</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="graduated-school-name" class="form-element-field" placeholder="Введіть назву навчального закладу"
                                type="text" data-obj-key="graduatedSchoolName" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="graduated-school-name">Закінчив(ла)</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="graduated-year" class="form-element-field" placeholder="Введіть рік закінчення"
                                type="number" data-obj-key="graduatedYear" data-required disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="graduated-year">Рік закінчення</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="home" class="form-element-field"
                            placeholder="Введіть місце проживання/реєстрації" type="text" data-obj-key="registration" data-required disabled/>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="home">Місце проживання/реєстрації</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="form-element form-input">
                        <input id="benefits" class="form-element-field" placeholder="Введіть пільги якщо є"
                            type="text" data-obj-key="exemption" data-required disabled/>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="benefits">Наявність пільг при вступі</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="order-date" class="form-element-field" placeholder="Введіть дату зарахування"
                                type="date" data-obj-key="orderDate" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-date">Зарахований(а) наказом від</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="order-number" class="form-element-field" placeholder="Введіть №"
                                type="text" data-obj-key="orderNumber" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-number">№</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="experience" data-obj-key="experienceCompetitionId" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Інформація відсутня</option>
                                <option value="2">Із стажем</option>
                                <option value="3">Без стажу</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="experience">1. За конкурсом</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="transferFrom" class="form-element-field"
                                placeholder="Введіть порядок переведення з" type="text" data-obj-key="transferFrom" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="transferFrom">2. У порядку переведення з</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="transfer-direction" class="form-element-field" placeholder="Введіть направленням"
                                type="text" data-obj-key="transferDirection" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="transfer-direction">3. За направленням</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="competition-conditions" class="form-element-field" placeholder="Введіть особливі умови"
                                type="text" data-obj-key="competitionConditions" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="competition-conditions">4. За особливими умовами участі у
                                конкурсі</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="out-of-competitionInfo" class="form-element-field"
                                placeholder="Введіть поза конкурсом" type="text" data-obj-key="outOfCompetitionInfo" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="out-of-competitionInfo">5. Поза конкурсом</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="amends" data-obj-key="amendsId" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Інформація відсутня</option>
                                <option value="2">Державний кредит</option>
                                <option value="3">Фізична особа</option>
                                <option value="4">Юридичная особа</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="amends">6. На умовах повного
                                відшкодування</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="employment-number" class="form-element-field" placeholder="Введіть №"
                                type="number" data-obj-key="employmentNumber" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-number">Трудова книжка №</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-date" class="form-element-field" placeholder="Введіть дату видачі"
                                type="date" data-obj-key="employmentGivenDate" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-date">Дата видачі</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-issued" class="form-element-field"
                                placeholder="Введіть ким видано" type="text" data-obj-key="employmentAuthority" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-issued">Ким видано</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="registration-number" class="form-element-field"
                            placeholder="Введіть реєстраційний номер облікової картки платника податків або серію та номер паспорту"
                            type="text" data-obj-key="registrOrPassportNumber" data-required disabled/>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="registration-number">Реєстраційний номер облікової
                            картки платника податків або серія та номер паспорту</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="main__show-row">
                        <div class="form-element form-select">
                            <select class="form-element-field" data-obj-key="studentStateId" id="student-status" data-required disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Активний</option>
                                <option value="2">В академічній відпустці</option>
                                <option value="3">Відрахований</option>
                                <option value="4">Здобув(ла) степінь</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="student-status">Статус студента</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col student-card__show-transfer-history">
                        <div class="student-card__show-transfer-history-header">
                            <span>Курс</span>
                            <span>Номер наказу</span>
                            <span>Дата наказу</span>
                            <span>Контент</span>
                        </div>
                        <div class="student-card__show-transfer-history-container">
                            
                        </div>
                    </div>
                </div>
            </div>
        `;
    }

    static init() {
        this._initDataObjKeyFields();
        this._studentCardSubscribe();
        subscribeFormElements();
    }

    static _initDataObjKeyFields() {
        this._dataObjKeyFields = content.querySelectorAll("[data-obj-key]");
        this._requiredFields = [...this._dataObjKeyFields].filter(x => x.hasAttribute('data-required'));

        this._requiredFields.forEach(x => {
            x.addEventListener('change', (e) => isFieldEmpty(e));
        });
    }

    static _studentCardSubscribe() {
        const findBtn = document.querySelector('.student-card__show-btn-find');
        const editBtn = document.querySelector('.student-card__show-btn-edit');
        const saveBtn = document.querySelector('.student-card__show-btn-save');
        // const averageScoreBtn = document.querySelector('.student-card__show-average-score-btn');
        const transferHistoryContainer = document.querySelector('.student-card__show-transfer-history-container');
        
        const specialitySelect = document.querySelector('#speciality');
        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const yearInput = document.querySelector('#year');
        const studentSelect = document.querySelector('#student');

        let requiredFieldsForFind = [
            courseSelect,
            yearInput,
            groupSelect,
            studentSelect
        ];

        findBtn.addEventListener('click', () => {
            if (validateFields(requiredFieldsForFind)) {
                findStudent(studentSelect.value);
            }
        });

        editBtn.addEventListener('click', () => {
            this._dataObjKeyFields.forEach(item => {
                item.disabled = !item.disabled;
            });

            let transferHistory = transferHistoryContainer.querySelectorAll('[data-history-key]');
            console.log(transferHistory);
            transferHistory.forEach(x => {
                x.disabled = !x.disabled;
            });
        });

        saveBtn.addEventListener('click', () => {
            if (validateFields(StudentCardShowPage._requiredFields)) {
                studentUpdate(studentSelect.value);
            }
        });

        // averageScoreBtn.addEventListener('click', () => {
        //     console.log('Average score');
        // });
        
        courseSelect.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findGroups(courseSelect.value);
            }
        });

        groupSelect.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findStudents(groupSelect.value, yearInput.value);
            }
        });

        yearInput.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findStudents(groupSelect.value, yearInput.value);
            }
        });
        
        studentSelect.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        async function findGroups(course) {
            if (course == "") {
                return;
            }

            const options = await getGroupsAsOptions(course);
            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');

            studentSelect.value = "";
            studentSelect.innerHTML = optionDefault;
            studentSelect.classList.remove('-hasValue');
        };

        async function findStudents(groupId, year = null) {
            if (groupId == "" || year == "") {
                return;
            }

            let options = await getStudentsAsOptions(groupId, year);
            studentSelect.innerHTML = options.join('');
            studentSelect.classList.remove('-hasValue');
        };

        async function findStudent(id) {
            if (id == "") {
                return;
            }

            const student = await apiHelper.fetchGetStudent(id);
            StudentCardShowPage._dataObjKeyFields.forEach(x => {
                x.value = student[x.getAttribute("data-obj-key")];

                if (x.value) {
                    x.classList.add('-hasValue');
                }
            });

            let transferHistoryContainer = document.querySelector('.student-card__show-transfer-history-container');
            transferHistoryContainer.innerHTML = getStudentTransferHistoryRows(student.transferHistory);
        }

        async function studentUpdate(id) {
            let student = {};
            StudentCardShowPage._dataObjKeyFields.forEach(x => {
                student[x.getAttribute('data-obj-key')] = x.value != "" ? x.value : undefined;
            });

            const transferHistoryRows = transferHistoryContainer.querySelectorAll('.student-card__show-transfer-history-row');
            student.transferHistory = [...transferHistoryRows]
                .map(row => {
                    let items = row.querySelectorAll('[data-history-key]');

                    let history = {};
                    items.forEach(x => {
                        history[x.getAttribute('data-history-key')] = x.value != "" ? x.value : undefined;
                    });

                    return history;
                });

            apiHelper.fetchStudentCardUpdate(id, student);
        }

        async function findSpeciality() {
            let options = await getSpecialitiesAsOptions(0);
            specialitySelect.innerHTML = options.join('');
            specialitySelect.classList.remove('-hasValue');
        }

        window.onload = findSpeciality();
    }
}
