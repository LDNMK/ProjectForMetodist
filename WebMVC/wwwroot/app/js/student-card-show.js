function getStudentCardShow() {
    return `
            <div class="student-card__show">
            <div class="student-card__show-general">
                <!-- <form class="student-card__find" action="get"> -->
                <div class="student-card__show-grid">
                    <div class="form-element form-select">
                        <select class="form-element-field" id="specialization">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Test 1</option>
                            <option value="2">Lorem ipsum dolor</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="specialization">Спеціальність</label>
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
                    <div class="form-element form-input">
                        <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="year">Рік</label>
                    </div>
                    <div class="form-element form-select">
                        <select class="form-element-field" id="specialization">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Test 1</option>
                            <option value="2">Lorem ipsum dolor</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="specialization">Курс</label>
                    </div>
                    <div class="form-element form-select">
                        <select class="form-element-field" id="specialization">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Test 1</option>
                            <option value="2">Lorem ipsum dolor</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="specialization">Група</label>
                    </div>
                </div>

                <div class="student-card__show-buttons">
                    <button class="btn student-card__show-btn-clear">
                        <i class="btn-icon fas fa-trash-alt"></i>
                        <span class="btn-text">Очистити</span>
                    </button>
                    <button class="btn student-card__show-btn-show">
                        <i class="btn-icon fas fa-search"></i>
                        <span class="btn-text">Знайти студентів</span>
                    </button>
                </div>
                <!-- </form> -->
            </div>

            <div class="student-card__show-info">
                <div class="form-element form-select">
                    <select class="form-element-field" id="specialization">
                        <option class="form-select-placeholder" value="" disabled selected></option>
                        <option value="1">Сидорчук Владислав Геннадійович</option>
                    </select>
                    <div class="form-element-bar"></div>
                    <label class="form-element-label" for="specialization">Навчальна картка студента</label>
                </div>

                <div class="student-card__show-row">
                    <div class="form-element form-input">
                        <input id="surname" class="form-element-field" placeholder="Введіть прізвище"
                            type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="surname">Прізвище</label>
                    </div>
                    <div class="form-element form-input">
                        <input id="name" class="form-element-field" placeholder="Введіть ім'я" type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="name">Ім'я</label>
                    </div>
                    <div class="form-element form-input">
                        <input id="first-name" class="form-element-field" placeholder="Введіть по-батькові"
                            type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="first-name">По-батькові</label>
                    </div>
                </div>

                <div class="student-card__show-row student-card__show-average-score">
                    <div class="form-element form-input">
                        <input id="average-scrore" class="form-element-field" placeholder="Введіть середній бал"
                            type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="average-scrore">Середній бал</label>

                        <button class="btn student-card__show-average-score-btn">
                            <i class="fas fa-calculator"></i>
                        </button>
                    </div>
                </div>

                <div class="student-card__show-row">
                    <div class="form-element form-input">
                        <input id="birthday" class="form-element-field" placeholder="Введіть дату народження"
                            type="date" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="birthday">Дата народження</label>
                    </div>
                    <div class="form-element form-input">
                        <input id="birthday-place" class="form-element-field"
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
                        <select class="form-element-field" id="student-status">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">Переведений з групою</option>
                            <option value="2">В академічній відпустці</option>
                            <option value="3">Не закрив сесію</option>
                            <option value="4">Виключенний з навчання</option>
                            <option value="5">Закінчив степінь</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="student-status">Статус студента</label>
                    </div>
                </div>
            </div>
        </div>
    `;
}