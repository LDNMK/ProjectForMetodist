class ProgressPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'progress--page';
    }

    static get page() {
        return `
            <div class="progress__grid">
                <div class="progress__find">
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
                            <select class="form-element-field" id="semestr">
                                <option class="form-select-placeholder" value="" disabled selected></option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                            </select>
                            <div class="form-element-bar"></div>
                            <label class="form-element-label" for="semestr">Семестр</label>
                        </div>
                    </div>
                    <div class="main__buttons">
                        <button class="btn progress__btn-find">
                            <i class="btn-icon fas fa-table"></i>
                            <span class="btn-text">Показати</span>
                        </button>
                    </div>
                </div>

                <div class="progress__info">
                    <h1 class="main__page-title">Успішніcть</h1>

                    <div class="progress__table">
                        <div class="progress__row progress__row-head">
                            <div class="progress__row-cell progress__row-cell-title-student">
                                <span>Студент</span>
                            </div>

                            <div class="progress__row-cell progress__row-cell-title-subject">
                                <span>Назва навчальної дисципліни</span>
                            </div>
                            <ul class="progress__row-cell progress__row-cell-subjects">
                                
                            </ul>

                            <div class="progress__row-cell progress__row-cell-title-final-mark">
                                <span>Рейт. бал</span>
                            </div>
                        </div>
                    </div>

                    <div class="main__buttons">
                        <button class="btn progress__btn-edit">
                            <i class="btn-icon far fa-edit"></i>
                            <span class="btn-text">Редагувати</span>
                        </button>
                        <button class="btn progress__btn-save">
                            <i class="btn-icon fas fa-upload"></i>
                            <span class="btn-text">Зберегти</span>
                        </button>
                    </div>
                </div>
            </div>
        `;
    }

    static init() {
        this._subscribePageElements();
        subscribeFormElements();
    }

    static _subscribePageElements() {
        const yearInput = document.querySelector('#year');
        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const semestrSelect = document.querySelector('#semestr');

        const progressTable = document.querySelector('.progress__table');
        const subjectsList = document.querySelector('.progress__row-cell-subjects');

        const progressFindBtn = document.querySelector('.progress__btn-find');
        const progressEditBtn = document.querySelector('.progress__btn-edit');
        const progressSaveBtn = document.querySelector('.progress__btn-save');

        yearInput.addEventListener('change', () => {
            // fetchGroups(courseSelect.value, yearInput.value);
        });

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        });

        progressFindBtn.addEventListener('click', () => {
            let response = {
                'subjects': [
                    {
                        'name': 'ПрІС',
                        'id': 1
                    },
                    {
                        'name': 'Веб програмування',
                        'id': 2
                    },
                    {
                        'name': 'ЕлкСх',
                        'id': 3
                    },
                    {
                        'name': 'Фізкультура',
                        'id': 4
                    },
                    {
                        'name': 'Теорія Алгоритмів',
                        'id': 5
                    }
                ],
                'students': [
                    {
                        'id': 1,
                        'name': 'Гуржій Анастасія Олександрівна',
                        'subjects': [
                            {
                                'id': 5,
                                'mark': 2
                            },
                            {
                                'id': 2,
                                'mark': 60
                            },
                            {
                                'id': 3,
                                'mark': 88
                            },
                            {
                                'id': 4,
                                'mark': 95
                            },
                            {
                                'id': 1,
                                'mark': 78
                            }
                        ]
                    },
                    {
                        'id': 2,
                        'name': 'Сидорчук Владислав Геннадійович',
                        'subjects': [
                            {
                                'id': 1,
                                'mark': 100
                            },
                            {
                                'id': 3,
                                'mark': 80
                            },
                            {
                                'id': 4,
                                'mark': 90
                            },
                            {
                                'id': 5,
                                'mark': 43
                            }
                        ]
                    }
                ]
            };

            // get plan
            response.subjects.forEach(s => {
                subjectsList.insertAdjacentHTML('beforeend', getProgressSubjectCell(s));
            });

            response.students.forEach(s => {
                progressTable.insertAdjacentHTML('beforeend', getProgressStudentRow(s, response.subjects));
            });

            fetchPlan();
        });

        progressEditBtn.addEventListener('click', () => {
            let items = progressTable.querySelectorAll('.progress__row-cell-marks input');

            items.forEach(item => {
                item.disabled = !item.disabled;
            });
        });

        progressSaveBtn.addEventListener('click', () => {
            let progressObj = [];

            let studentRows = progressTable.querySelectorAll('.progress__row-student');
            studentRows.forEach(sr => {
                let student = {
                    id: sr.getAttribute('data-student-id'),
                    name: sr.querySelector('.progress__row-cell-student span')?.innerText
                };

                student.subjects = [...sr.querySelectorAll('.progress__row-cell-input')]
                    .map(x => {
                        return {
                            id: +x.getAttribute('data-subject-id'),
                            mark: x.value
                        }
                    });

                progressObj.push(student);
            });

            console.log(progressObj);
        });

        async function fetchPlan() {
            // TODO
        }

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
    }
}
