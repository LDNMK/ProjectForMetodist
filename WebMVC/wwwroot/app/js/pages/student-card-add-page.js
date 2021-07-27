class StudentCardAddPage extends Page {
    constructor() {
        super();
    }

    static _dataObjKeyFields = null;

    static get is() {
        return 'student-card--add-page';
    }

    static get page() {
        return `
            <div class="student-card__add">
                <div class="student-card__add-info">
                    <h1 class="main__page-title">Навчальна картка студента</h1>

                    <div class="main__col-3">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="course" data-obj-key="course">
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
                            <select class="form-element-field" id="group" data-obj-key="groupId">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="group">Група</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="groupYear" class="form-element-field" data-obj-key="groupYear" placeholder="Введіть рік" type="number" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="groupYear">Рік</label>
                        </div>
                    </div>

                    <div class="form-element form-select">
                        <select class="form-element-field" id="degree" data-obj-key="degreeId">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Бакалавр</option>
                            <option value="2">Магістр</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="degree">Рівень вищої
                            освіти/освітньо-кваліфікаційний
                            рівень</label>
                    </div>

                    <div class="form-element form-select">
                        <select class="form-element-field" id="speciality" data-obj-key="specialityId">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="speciality">Спеціальність</label>
                    </div>

                    <div class="student-card__add-gap"></div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="surname" data-obj-key="lastName" class="form-element-field"
                                placeholder="Введіть прізвище" type="text"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="surname">Прізвище</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="name" data-obj-key="firstName" class="form-element-field"
                                placeholder="Введіть ім'я" type="text"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="name">Ім'я</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="first-name" data-obj-key="patronymic" class="form-element-field"
                                placeholder="Введіть по-батькові" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="first-name">По-батькові</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="birthdate" data-obj-key="birthdate" class="form-element-field"
                                placeholder="Введіть дату народження" type="date" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthdate">Дата народження</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="birthdate-place" data-obj-key="birthPlace" class="form-element-field"
                                placeholder="Введіть місце народження" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthdate-place">Місце народження</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="citizenship" class="form-element-field" placeholder="Введіть громадянство"
                                type="text" data-obj-key="citizenship"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="citizenship">Громадянство</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="marital-status" data-obj-key="maritalStatusId">
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
                            <input id="home" class="form-element-field"
                                placeholder="Введіть місце проживання/реєстрації" type="text" data-obj-key="registration"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="home">Місце проживання/реєстрації</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="benefits" class="form-element-field" placeholder="Введіть пільги якщо є"
                                type="text" data-obj-key="exemption"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="benefits">Наявність пільг при вступі</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="order-date" class="form-element-field" placeholder="Введіть дату зарахування"
                                type="date" data-obj-key="orderDate"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-date">Зарахований(а) наказом від</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="order-number" class="form-element-field" placeholder="Введіть №"
                                type="number" data-obj-key="orderNumber"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-number">№</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="experience" data-obj-key="experienceCompetitionId">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Із стажем</option>
                                <option value="2">Без стажу</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="experience">1. За конкурсом</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="transferFrom" class="form-element-field"
                                placeholder="Введіть порядок переведення з" type="text" data-obj-key="transferFrom"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="transferFrom">2. У порядку переведення з</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="transfer-direction" class="form-element-field" placeholder="Введіть направленням"
                                type="text" data-obj-key="transferDirection"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="transfer-direction">3. За направленням</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="competition-conditions" class="form-element-field" placeholder="Введіть особливі умови"
                                type="text" data-obj-key="competitionConditions"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="competition-conditions">4. За особливими умовами участі у
                                конкурсі</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="out-of-competitionInfo" class="form-element-field"
                                placeholder="Введіть поза конкурсом" type="text" data-obj-key="outOfCompetitionInfo"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="out-of-competitionInfo">5. Поза конкурсом</label>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="amends" data-obj-key="amendsId">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Державний кредит</option>
                                <option value="2">Фізична особа</option>
                                <option value="3">Юридичная особа</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="amends">6. На умовах повного
                                відшкодування</label>
                        </div>
                    </div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="employment-number" class="form-element-field" placeholder="Введіть №"
                                type="number" data-obj-key="employmentNumber"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-number">Трудова книжка №</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-given-date" class="form-element-field" placeholder="Введіть дату видачі"
                                type="date" data-obj-key="employmentGivenDate"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-given-date">Дата видачі</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-authority" class="form-element-field"
                                placeholder="Введіть ким видано" type="text" data-obj-key="employmentAuthority"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-authority">Ким видано</label>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="registr-or-passport-number" class="form-element-field"
                            placeholder="Введіть реєстраційний номер облікової картки платника податків або серію та номер паспорту"
                            type="text" data-obj-key="registrOrPassportNumber"/>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="registr-or-passport-number">Реєстраційний номер облікової
                            картки платника податків або серія та номер паспорту</label>
                    </div>

                    <div class="main__col-3">
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

                    <div class="main__buttons">
                        <button class="btn student-card__show-btn-save">
                            <i class="btn-icon fas fa-save"></i>
                            <span class="btn-text">Зберегти</span>
                        </button>
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
        const saveBtn = document.querySelector('.student-card__show-btn-save');

        const groupSelect = document.querySelector('#group');
        const courseSelect = document.querySelector('#course');
        const degreeSelect = document.querySelector('#degree');
        const specialitySelect = document.querySelector('#speciality');

        saveBtn.addEventListener('click', () => {
            fetchStudentSave();
        })

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        })

        degreeSelect.addEventListener('change', () =>{
            fetchSpecialities(degree.value);
        });

        async function fetchSpecialities(degreeId) {
            const response = await fetch(`api/StudentCard/GetSpecialities?degreeId=${degreeId}`);
            const specialities = await response.json();

            let options = specialities.map(x => `<option value=${x.id}>${x.name}</option>`);
            options.push(optionDefault);

            specialitySelect.innerHTML = options.join('');
            specialitySelect.classList.remove('-hasValue');
        }

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
        };

        async function fetchStudentSave() {
            let student = {};
            StudentCardAddPage._dataObjKeyFields.forEach(x => {
                student[x.getAttribute('data-obj-key')] = x.value;
            });

            console.log(student);

            const response = await fetch(`api/StudentCard/SaveStudentCardInfo`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(student)
            });

            if (!response.ok) {
                var error = await response.json();

                console.log(error);
                return;
            }           
        }
    }
}

StudentCardAddPage.is = 'test';