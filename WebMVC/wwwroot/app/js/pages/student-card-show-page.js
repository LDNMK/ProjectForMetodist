class StudentCardShowPage extends Page {
    constructor() {
        super();
    }

    static _dataObjKeyFields = null;

    static is() {
        return 'student-card--show-page';
    }

    static getPage() {
        return `
            <div class="student-card__show">
                <div class="student-card__show-general">
                    <h1 class="student-card__show-title">Пошук</h1>
                    <!-- <form class="student-card__find" action="get"> -->
                    
                    <div class="student-card__show-grid">
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
                            <select class="form-element-field" id="student">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="student">Студент</label>
                        </div>
                    </div>

                    <div class="student-card__show-buttons">
                        <button class="btn student-card__show-btn-clear">
                            <i class="btn-icon fas fa-trash-alt"></i>
                            <span class="btn-text">Очистити</span>
                        </button>
                        <button class="btn student-card__show-btn-find">
                            <i class="btn-icon fas fa-search"></i>
                            <span class="btn-text">Знайти студента</span>
                        </button>
                    </div>
                    <!-- </form> -->
                </div>

                <div class="student-card__show-info">
                    <h1 class="student-card__show-title">Навчальна картка студента</h1>
                    <div class="student-card__show-info-buttons">
                        <button class="btn student-card__show-btn-edit">
                            <i class="btn-icon fas fa-user-edit"></i>
                            <span class="btn-text">Редагувати</span>
                        </button>
                        <button class="btn student-card__show-btn-save">
                            <i class="btn-icon fas fa-save"></i>
                            <span class="btn-text">Зберегти</span>
                        </button>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="speciality">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Test 1</option>
                                <option value="2">Lorem ipsum dolor</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="speciality">Спеціальність</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="specialization">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Test 1</option>
                                <option value="2">Lorem ipsum dolor</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="specialization">Спеціалізація</label>
                        </div>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-input">
                            <input id="surname" data-obj-key="lastName" class="form-element-field" placeholder="Введіть прізвище"
                                type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="surname">Прізвище</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="name" data-obj-key="firstName" class="form-element-field" placeholder="Введіть ім'я" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="name">Ім'я</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="first-name" data-obj-key="patronymic" class="form-element-field" placeholder="Введіть по-батькові"
                                type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="first-name">По-батькові</label>
                        </div>
                    </div>

                    <div class="student-card__show-row student-card__show-average-score">
                        <div class="form-element form-input">
                            <input id="average-score" class="form-element-field" placeholder="Введіть середній бал"
                                type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="average-score">Середній бал</label>

                            <button class="btn student-card__show-average-score-btn">
                                <i class="fas fa-calculator"></i>
                            </button>
                        </div>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-input">
                            <input id="birthday" data-obj-key="birthday" class="form-element-field" placeholder="Введіть дату народження"
                                type="date" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthday">Дата народження</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="birthday-place" data-obj-key="birthPlace" class="form-element-field"
                                placeholder="Введіть місце народження" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthday-place">Місце народження</label>
                        </div>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-input">
                            <input id="nationality" class="form-element-field" placeholder="Введіть громадянство"
                                type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="nationality">Громадянство</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="marital-status">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Одружений/Заміжня</option>
                                <option value="2">Не одружений/Не заміжня</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="marital-status">Сімейний стан</label>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="home" class="form-element-field"
                            placeholder="Введіть місце проживання/реєстрації" type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="home">Місце проживання/реєстрації</label>
                    </div>

                    <div class="form-element form-input">
                        <input id="benefits" class="form-element-field" placeholder="Введіть пільги якщо є"
                            type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="benefits">Наявність пільг при вступі</label>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-input">
                            <input id="order-date" class="form-element-field" placeholder="Введіть дату зарахування"
                                type="date" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-date">Зарахований(а) наказом від</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="order-number" class="form-element-field" placeholder="Введіть №"
                                type="number" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-number">№</label>
                        </div>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-input">
                            <input id="employment-number" class="form-element-field" placeholder="Введіть №"
                                type="number" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-number">Трудова книжка №</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-date" class="form-element-field" placeholder="Введіть дату видачі"
                                type="date" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-date">Дата видачі</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-issued" class="form-element-field"
                                placeholder="Введіть ким видано" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-issued">Ким видано</label>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="registration-number" class="form-element-field"
                            placeholder="Введіть реєстраційний номер облікової картки платника податків або серію та номер паспорту"
                            type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="registration-number">Реєстраційний номер облікової
                            картки платника податків або серія та номер паспорту</label>
                    </div>

                    <div class="student-card__show-row">
                        <div class="form-element form-select">
                            <select class="form-element-field" data-obj-key="studentStateId" id="student-status">
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
                </div>
            </div>
        `;
    }

    static init() {
        this._initDataObjKeyFields();
        this._studentCardShowSubscribe();
        subscribeFormElements();
    }

    static _initDataObjKeyFields() {
        this._dataObjKeyFields = content.querySelectorAll("[data-obj-key]");
    }

    static _studentCardShowSubscribe() {
        const clearBtn = document.querySelector('.student-card__show-btn-clear');
        const findBtn = document.querySelector('.student-card__show-btn-find');
        const editBtn = document.querySelector('.student-card__show-btn-edit');
        const saveBtn = document.querySelector('.student-card__show-btn-save');
        const averageScoreBtn = document.querySelector('.student-card__show-average-score-btn');

        const groupSelect = document.querySelector('#group');
        const courseSelect = document.querySelector('#course');
        const studentSelect = document.querySelector('#student');

        const year = document.querySelector('#year');

        clearBtn.addEventListener('click', () => {
            let ids = this._idsToClear();

            let items = document.querySelectorAll(ids.join(', '));
            items.forEach(x => {
                x.classList.remove('-hasValue');
                x.value = "";
            });
        })

        findBtn.addEventListener('click', () => {
            fetchStudent(studentSelect.value);
        })

        editBtn.addEventListener('click', () => {
            console.log('Edit');
        })

        saveBtn.addEventListener('click', () => {
            fetchStudentSave(studentSelect.value);
        })

        averageScoreBtn.addEventListener('click', () => {
            console.log('Average score');
        })

        year.addEventListener('change', () => {
            fetchGroups(year.value, courseSelect.value);
        })

        courseSelect.addEventListener('change', () => {
            fetchGroups(year.value, courseSelect.value);
        })

        groupSelect.addEventListener('change', () => {
            fetchStudents(groupSelect.value);
        })

        async function fetchGroups(year, course) {
            if (year == "" || course == "") {
                return;
            }

            const response = await fetch(`api/Group/GetListOfGroups?course=${course}&year=${year}`);
            const groups = await response.json();

            console.log(groups);

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        async function fetchStudents(groupId) {
            if (groupId == "") {
                return;
            }

            const response = await fetch(`api/StudentCard/GetListOfStudents?groupId=${groupId}`);
            const students = await response.json();

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
                x.classList.add('-hasValue');
            });

            console.log(student);
        }

        async function fetchStudentSave(id) {
            let student = {};
            StudentCardShowPage._dataObjKeyFields.forEach(x => {
                student[x.getAttribute('data-obj-key')] = x.value;
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


        // Delete
        year.value = 2021;
        year.classList.add('-hasValue');

        courseSelect.value = "1"
        courseSelect.classList.add('-hasValue');

        let event = new Event("change");
        courseSelect.dispatchEvent(event);

        // groupSelect.value = 1;
        // groupSelect.classList.add('-hasValue');

        //document.getElementById('show').onclick = function (e) {
        //    e.preventDefault();

        //    var studentId = document.getElementById('student').value;

        //    var url = 'api/StudentCard/ShowStudentInfo?studentId=' + studentId;
        //    fetch(url, {
        //        method: 'GET'
        //    })
        //        .then((resp) => resp.json())
        //        .then(function (data) {
        //            let studentInfo = data;

        //            document.getElementById('surname').value = studentInfo.lastName;
        //            document.getElementById('name').value = studentInfo.firstName;
        //            document.getElementById('middle_name').value = studentInfo.patronymic;
        //            document.getElementById('birthday').value = studentInfo.birthday;
        //            document.getElementById('birthplace').value = studentInfo.birthPlace;
        //            document.getElementById('citizenship').value = studentInfo.immenseness;
        //            document.getElementById('marital_status').value = studentInfo.maritalStatusId;
        //            document.getElementById('registration_place').value = studentInfo.registration;
        //            document.getElementById('exemption').value = studentInfo.exemption;
        //            document.getElementById('date_reckoned').value = studentInfo.orderDate;
        //            //document.getElementById('competition').value = studentInfo.expirienceCompetitionId;
        //            //document.getElementById('transfer_order').value = studentInfo.transferFrom;
        //            //document.getElementById('by_direction').value = studentInfo.transferDirection;
        //            //document.getElementById('special_conditions_of_competition').value = studentInfo.competitionConditions;
        //            //document.getElementById('out_of_competition').value = studentInfo.outOfCompetitionInfo;
        //            //document.getElementById('full_refund').value = studentInfo.ammendsId;
        //            document.getElementById('number_reckoned').value = studentInfo.orderNumber;
        //            document.getElementById('employment_history_number').value = studentInfo.employmentNumber;
        //            document.getElementById('employment_given_date').value = studentInfo.employmentGivenDate;
        //            document.getElementById('employment_history_by_whom_issued').value = studentInfo.employmentAuthority;
        //            document.getElementById('registration_or_passport_number').value = studentInfo.registrOrPassportNumber;
        //            document.getElementById('student_status').value = studentInfo.studentStateId;

        //        })
        //};

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
