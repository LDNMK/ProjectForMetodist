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
                            <select class="form-element-field" id="course" data-obj-key="course" data-required>
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
                            <select class="form-element-field" id="group" data-obj-key="groupId" data-required>
                                <option class="form-select-placeholder" value="" disabled selected></option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="group">Група</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="groupYear" class="form-element-field" data-obj-key="groupYear" placeholder="Введіть рік" type="number" data-required/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="groupYear">Рік</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="form-element form-select">
                        <select class="form-element-field" id="degree" data-obj-key="degreeId" data-required>
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Бакалавр</option>
                            <option value="2">Магістр</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="degree">Рівень вищої освіти/освітньо-кваліфікаційний рівень</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="form-element form-select">
                        <select class="form-element-field" id="speciality" data-obj-key="specialityId" data-required>
                            <option class="form-select-placeholder" value="" disabled selected></option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="speciality">Спеціальність</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="student-card__add-gap"></div>

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="surname" data-obj-key="lastName" class="form-element-field"
                                placeholder="Введіть прізвище" type="text" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="surname">Прізвище</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="name" data-obj-key="firstName" class="form-element-field"
                                placeholder="Введіть ім'я" type="text" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="name">Ім'я</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="first-name" data-obj-key="patronymic" class="form-element-field"
                                placeholder="Введіть по-батькові" type="text" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="first-name">По-батькові</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="birthdate" data-obj-key="birthdate" class="form-element-field"
                                placeholder="Введіть дату народження" type="date" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthdate">Дата народження</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="birthdate-place" data-obj-key="birthPlace" class="form-element-field"
                                placeholder="Введіть місце народження" type="text" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="birthdate-place">Місце народження</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="citizenship" class="form-element-field" placeholder="Введіть громадянство"
                                type="text" data-obj-key="citizenship" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="citizenship">Громадянство</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field" id="marital-status" data-obj-key="maritalStatusId">
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
                                type="text" data-obj-key="graduatedSchoolName" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="graduated-school-name">Закінчив(ла)</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="graduated-year" class="form-element-field" placeholder="Введіть рік закінчення"
                                type="number" data-obj-key="graduatedYear" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="graduated-year">Рік закінчення</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="form-element form-input">
                            <input id="home" class="form-element-field"
                                placeholder="Введіть місце проживання/реєстрації" type="text" data-obj-key="registration" data-required />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="home">Місце проживання/реєстрації</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="form-element form-input">
                        <input id="benefits" class="form-element-field" placeholder="Введіть пільги якщо є"
                            type="text" data-obj-key="exemption" data-required />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="benefits">Наявність пільг при вступі</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="order-date" class="form-element-field" placeholder="Введіть дату зарахування"
                                type="date" data-obj-key="orderDate"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-date">Зарахований(а) наказом від</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="order-number" class="form-element-field" placeholder="Введіть №"
                                type="text" data-obj-key="orderNumber"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="order-number">№</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-select">
                            <select class="form-element-field -hasValue" id="experience" data-obj-key="experienceCompetitionId">
                                <option value="1" selected>Інформація відсутня</option>
                                <option value="2">Із стажем</option>
                                <option value="3">Без стажу</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="experience">1. За конкурсом</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="transferFrom" class="form-element-field"
                                placeholder="Введіть порядок переведення з" type="text" data-obj-key="transferFrom"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="transferFrom">2. У порядку переведення з</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="transfer-direction" class="form-element-field" placeholder="Введіть направленням"
                                type="text" data-obj-key="transferDirection"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="transfer-direction">3. За направленням</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="competition-conditions" class="form-element-field" placeholder="Введіть особливі умови"
                                type="text" data-obj-key="competitionConditions"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="competition-conditions">4. За особливими умовами участі у
                                конкурсі</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <input id="out-of-competitionInfo" class="form-element-field"
                                placeholder="Введіть поза конкурсом" type="text" data-obj-key="outOfCompetitionInfo"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="out-of-competitionInfo">5. Поза конкурсом</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-select">
                            <select class="form-element-field -hasValue" id="amends" data-obj-key="amendsId">
                                <option value="1" selected>Інформація відсутня</option>
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
                            <input id="employment-number" class="form-element-field" value="0" placeholder="Введіть №"
                                type="number" data-obj-key="employmentNumber"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-number">Трудова книжка №</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-given-date" class="form-element-field" placeholder="Введіть дату видачі"
                                type="date" data-obj-key="employmentGivenDate"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-given-date">Дата видачі</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                        <div class="form-element form-input">
                            <input id="employment-authority" class="form-element-field"
                                placeholder="Введіть ким видано" type="text" data-obj-key="employmentAuthority"/>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="employment-authority">Ким видано</label>
                            <small class="form-element-hint">Необхідно задати значення</small>
                        </div>
                    </div>

                    <div class="form-element form-input">
                        <input id="registr-or-passport-number" class="form-element-field"
                            placeholder="Введіть реєстраційний номер облікової картки платника податків або серію та номер паспорту"
                            type="text" data-obj-key="registrOrPassportNumber" data-required />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="registr-or-passport-number">Реєстраційний номер облікової
                            картки платника податків або серія та номер паспорту</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
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
        this._requiredFields = [...this._dataObjKeyFields].filter(x => x.hasAttribute('data-required'));

        this._requiredFields.forEach(x => {
            x.addEventListener('change', (e) => isFieldEmpty(e));
        });
    }

    static _studentCardSubscribe() {
        const saveBtn = document.querySelector('.student-card__show-btn-save');

        const groupSelect = document.querySelector('#group');
        const courseSelect = document.querySelector('#course');
        const degreeSelect = document.querySelector('#degree');
        const specialitySelect = document.querySelector('#speciality');

        saveBtn.addEventListener('click', () => {
            studentSave();
        })

        courseSelect.addEventListener('change', () => {
            findGroups(courseSelect.value);
        })

        degreeSelect.addEventListener('change', () =>{
            findSpecialities(degree.value);
        });

        async function findSpecialities(degreeId) {
            let options = await getSpecialitiesAsOptions(degreeId);
            specialitySelect.innerHTML = options.join('');
            specialitySelect.classList.remove('-hasValue');
        }

        async function findGroups(course) {
            if (course == "") {
                return;
            }

            const options = await getGroupsAsOptions(course);
            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        async function studentSave() {
            if (!validateFields(StudentCardAddPage._requiredFields)) {
                return;
            }

            let student = {};
            StudentCardAddPage._dataObjKeyFields.forEach(x => {
                student[x.getAttribute('data-obj-key')] = x.value;
            });

            apiHelper.fetchStudentCardSave(student);           
        }
    }
}

StudentCardAddPage.is = 'test';