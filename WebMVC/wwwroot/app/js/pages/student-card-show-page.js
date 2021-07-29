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
                        <div class="form-checkbox form-checkbox-inline">
                            <label class="form-checkbox-label">
                                <input class="form-checkbox-field" type="checkbox" id="select-year"/>
                                <i class="form-checkbox-button"></i>
                                <span>Обрати рік<small>*</small></span>
                            </label>
                            <span class="form-element-hint form-element-hint--static">* - щоб знайти студента за попередні роки</span>
                        </div>

                        <div class="form-element form-input">
                            <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" disabled />
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
                            <select class="form-element-field" id="student">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="student">Студент</label>
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
                            <select class="form-element-field" id="speciality" data-obj-key="specialityId" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="speciality">Спеціальність</label>
                        </div>
                    </div>

                    <div class="main__col">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="degree" data-obj-key="degreeId" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Бакалавр</option>
                                <option value="2">Магістр</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="degree">Рівень вищої
                                освіти/освітньо-кваліфікаційний
                                рівень</label>
                        </div>
                    </div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="surname" data-obj-key="lastName" class="form-element-field" placeholder="Введіть прізвище"
                                type="text" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="surname">Прізвище</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="name" data-obj-key="firstName" class="form-element-field" placeholder="Введіть ім'я" type="text" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="name">Ім'я</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="first-name" data-obj-key="patronymic" class="form-element-field" placeholder="Введіть по-батькові"
                                type="text" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="first-name">По-батькові</label>
                        </div>
                    </div>

                    <div class="main__col-3 student-card__show-average-score">
                        <div class="form-element form-input">
                            <input id="average-score" class="form-element-field" placeholder="Введіть середній бал"
                                type="text" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="average-score">Середній бал</label>

                            <button class="btn student-card__show-average-score-btn" disabled>
                                <i class="fas fa-calculator"></i>
                            </button>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="birthdate" data-obj-key="birthdate" class="form-element-field" placeholder="Введіть дату народження"
                                type="date" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthdate">Дата народження</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="birthday-place" data-obj-key="birthPlace" class="form-element-field"
                                placeholder="Введіть місце народження" type="text" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthday-place">Місце народження</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="nationality" class="form-element-field" placeholder="Введіть громадянство"
                                type="text" data-obj-key="citizenship" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="nationality">Громадянство</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="marital-status" data-obj-key="maritalStatusId" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Одружений/Заміжня</option>
                                <option value="2">Не одружений/Не заміжня</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="marital-status">Сімейний стан</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="graduated-school-name" class="form-element-field" placeholder="Введіть назву навчального закладу"
                                type="text" data-obj-key="graduatedSchoolName" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="graduated-school-name">Закінчив(ла)</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="graduated-year" class="form-element-field" placeholder="Введіть рік закінчення"
                                type="number" data-obj-key="graduatedYear" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="graduated-year">Рік закінчення</label>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="home" class="form-element-field"
                            placeholder="Введіть місце проживання/реєстрації" type="text" data-obj-key="registration" disabled/>
                        <div class="form-element-bar" ></div>
                        <label class="form-element-label" for="home">Місце проживання/реєстрації</label>
                    </div>

                    <div class="form-element form-input">
                        <input id="benefits" class="form-element-field" placeholder="Введіть пільги якщо є"
                            type="text" data-obj-key="exemption" disabled/>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="benefits">Наявність пільг при вступі</label>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="order-date" class="form-element-field" placeholder="Введіть дату зарахування"
                                type="date" data-obj-key="orderDate" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-date">Зарахований(а) наказом від</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="order-number" class="form-element-field" placeholder="Введіть №"
                                type="number" data-obj-key="orderNumber" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-number">№</label>
                        </div>
                    </div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="employment-number" class="form-element-field" placeholder="Введіть №"
                                type="number" data-obj-key="employmentNumber" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-number">Трудова книжка №</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-date" class="form-element-field" placeholder="Введіть дату видачі"
                                type="date" data-obj-key="employmentGivenDate" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-date">Дата видачі</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-issued" class="form-element-field"
                                placeholder="Введіть ким видано" type="text" data-obj-key="employmentAuthority" disabled/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-issued">Ким видано</label>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="registration-number" class="form-element-field"
                            placeholder="Введіть реєстраційний номер облікової картки платника податків або серію та номер паспорту"
                            type="text" data-obj-key="registrOrPassportNumber" disabled/>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="registration-number">Реєстраційний номер облікової
                            картки платника податків або серія та номер паспорту</label>
                    </div>

                    <div class="main__show-row">
                        <div class="form-element form-select">
                            <select class="form-element-field" data-obj-key="studentStateId" id="student-status" disabled>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Переведений з групою</option>
                                <option value="2">В академічній відпустці</option>
                                <option value="3">Перехід в іншу группу</option>
                                <option value="4">Не закрив сесію</option>
                                <option value="5">Відрахований</option>
                                <option value="6">Здобув степінь</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="student-status">Статус студента</label>
                        </div>
                    </div>

                    <div class="main__col student-card__show-transfer-history">
                        <div class="main__col-3 student-card__show-transfer-history-header">
                            <span>Курс</span>
                            <span>Номер наказу</span>
                            <span>Дата наказу</span>
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
    }

    static _studentCardSubscribe() {
        const findBtn = document.querySelector('.student-card__show-btn-find');
        const editBtn = document.querySelector('.student-card__show-btn-edit');
        const saveBtn = document.querySelector('.student-card__show-btn-save');
        const averageScoreBtn = document.querySelector('.student-card__show-average-score-btn');
        const transferHistoryContainer = document.querySelector('.student-card__show-transfer-history-container');
        

        const groupSelect = document.querySelector('#group');
        const courseSelect = document.querySelector('#course');
        const studentSelect = document.querySelector('#student');
        const specialitySelect = document.querySelector('#speciality');

        const yearCheckbox = document.querySelector('#select-year');
        const yearInput = document.querySelector('#year');

        findBtn.addEventListener('click', () => {
            fetchStudent(studentSelect.value);
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
            fetchStudentUpdate(studentSelect.value);
        });

        averageScoreBtn.addEventListener('click', () => {
            console.log('Average score');
        });

        yearCheckbox.addEventListener('change', () => {
            yearInput.disabled = !yearCheckbox.checked;
            
            if (!yearCheckbox.checked) {
                yearInput.value = "";
                yearInput.classList.remove('-hasValue');

                groupSelect.dispatchEvent(new Event('change'));
            }
        });

        yearInput.addEventListener('change', () => {
            fetchStudents(groupSelect.value, yearInput.value);
        });

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        });

        groupSelect.addEventListener('change', () => {
            if (yearCheckbox.checked && !yearInput.value) {
                console.log("Error: year wasn't selected");
            } else if (yearCheckbox.checked && yearInput.value) {
                fetchStudents(groupSelect.value, yearInput.value);
            } else {
                fetchStudents(groupSelect.value);
            }
        });

        async function fetchGroups(course) {
            if (course == "") {
                return;
            }

            const response = await fetch(`api/Group/GetGroups?course=${course}`);
            const groups = await response.json();

            console.log(groups);

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');

            studentSelect.value = "";
            studentSelect.innerHTML = optionDefault;
            studentSelect.classList.remove('-hasValue');
        };

        async function fetchStudents(groupId, year = null) {
            if (groupId == "" || year == "") {
                return;
            }

            let url = `api/StudentCard/GetStudents?groupId=${groupId}`;
            if (year) {
                url += `&year=${year}`
            }
            
            const response = await fetch(url);
            const students = await response.json();

            console.log(students);

            let options = students.map(x => `<option value=${x.studentId}>${x.studentName}</option>`);
            options.push(optionDefault);

            studentSelect.innerHTML = options.join('');
            studentSelect.classList.remove('-hasValue');
        };

        async function fetchStudent(id) {
            if (id == "") {
                return;
            }

            const response = await fetch(`api/StudentCard/ShowStudentInfo?studentId=${id}`);
            const student = await response.json();

            StudentCardShowPage._dataObjKeyFields.forEach(x => {
                x.value = student[x.getAttribute("data-obj-key")];

                if (x.value) {
                    x.classList.add('-hasValue');
                }
            });

            let transferHistoryContainer = document.querySelector('.student-card__show-transfer-history-container');
            transferHistoryContainer.innerHTML = getStudentTransferHistoryRows(student.transferHistory);

            console.log(student);
        }

        async function fetchStudentUpdate(id) {
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

            console.log(student);

            const response = await fetch(`api/StudentCard/UpdateStudentCardInfo?studentId=${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(student)
            });

            // TODO: Check response
        }

        async function fetchSpeciality() {
            const response = await fetch(`api/StudentCard/GetSpecialities`);
            const specialities = await response.json();

            let options = specialities.map(x => `<option value=${x.id}>${x.name}</option>`);
            options.push(optionDefault);

            specialitySelect.innerHTML = options.join('');
            specialitySelect.classList.remove('-hasValue');
        }

        window.onload = fetchSpeciality();
    }

    static _idsToClear() {
        return [
            '#speciality',
            '#specialization',
            '#year',
            '#course',
            '#group',
            '#student'
        ];
    }
}
