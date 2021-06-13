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
                    <h1 class="student-card__title">Навчальна картка студента</h1>

                    <div class="main__col-2">
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
                    </div>

                    <div class="form-element form-select">
                        <select class="form-element-field" id="degree">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Бакалавр</option>
                            <option value="2">Магістр</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="degree">Рівень вищої
                            освіти/освітньо-кваліфікаційний
                            рівень</label>
                    </div>

                    <div class="main__col-2">
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

                    <div class="main__col-3">
                        <div class="form-element form-input">
                            <input id="surname" data-obj-key="lastName" class="form-element-field"
                                placeholder="Введіть прізвище" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="surname">Прізвище</label>
                        </div>
                        <div class="form-element form-input">
                            <input id="name" data-obj-key="firstName" class="form-element-field"
                                placeholder="Введіть ім'я" type="text" />
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
                            <input id="birthday" data-obj-key="birthday" class="form-element-field"
                                placeholder="Введіть дату народження" type="date" />
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

                    <div class="main__col-2">
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

                    <div class="main__col-2">
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
                    </div>

                    <div class="main__col-2">
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

                    <div class="main__col-2">
                        <div class="form-element form-select">
                            <select class="form-element-field" id="experience">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Із стажем</option>
                                <option value="2">Без стажу</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="experience">1. За конкурсом</label>
                        </div>
                        <div class="form-element form-input">
                            <!-- Change id and for attributes -->
                            <input id="change1" class="form-element-field"
                                placeholder="Введіть порядок переведення з" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="change1">2. У порядку переведення з</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <!-- Change id and for attributes -->
                            <input id="change2" class="form-element-field" placeholder="Введіть направленням"
                                type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="change2">3. За направленням</label>
                        </div>
                        <div class="form-element form-input">
                            <!-- Change id and for attributes -->
                            <input id="change3" class="form-element-field" placeholder="Введіть особливі умови"
                                type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="change3">4. За особливими умовами участі у
                                конкурсі</label>
                        </div>
                    </div>

                    <div class="main__col-2">
                        <div class="form-element form-input">
                            <!-- Change id and for attributes -->
                            <input id="change4" class="form-element-field"
                                placeholder="Введіть поза конкурсом" type="text" />
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="change4">5. Поза конкурсом</label>
                        </div>
                        <div class="form-element form-select">
                            <!-- Change id and for attributes -->
                            <select class="form-element-field" id="change5">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">Державний кредит</option>
                                <option value="2">Фізична особа</option>
                                <option value="3">Юридичная особа</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="change5">6. На умовах повного
                                відшкодування</label>
                        </div>
                    </div>

                    <div class="main__col-3">
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

        saveBtn.addEventListener('click', () => {
            fetchStudentSave();
        })

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        })

        async function fetchGroups(course) {
            if (course == "") {
                return;
            }

            const response = await fetch(`api/Group/GetListOfGroups?course=${course}`);
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

            // TODO: Process response
        }


        // Delete
        //year.value = 2021;
        //year.classList.add('-hasValue');

        //courseSelect.value = "1"
        //courseSelect.classList.add('-hasValue');

        let event = new Event("change");
        courseSelect.dispatchEvent(event);


        // Init selects
        
    }
}

StudentCardAddPage.is = 'test';