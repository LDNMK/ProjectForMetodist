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
                                <option value="1">Осінній</option>
                                <option value="2">Весняний</option>
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
            findGroups(courseSelect.value, yearInput.value);
        });

        courseSelect.addEventListener('change', () => {
            findGroups(courseSelect.value);
        });

        progressFindBtn.addEventListener('click', () => {
            // get plan
            fetchPlan(yearInput.value, groupSelect.value, semestrSelect.value);
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

                student.subjects = [...sr.querySelectorAll('.progress__row-cell-mark, .progress__row-cell-mark-with-cw')]
                    .map(x => {
                        let mark = x.querySelector('.progress__row-cell-mark-value');
                        let date = x.querySelector('.progress__row-cell-mark-date');
                        let cwMark = x.querySelector('.progress__row-cell-cw-value');

                        let studentSubject = {
                            id: +mark.getAttribute('data-subject-id'),
                            mark: mark.value == "" ? null : mark.value,
                            modifiedOn: date.value == "" ? null : date.value,
                        };

                        if (cwMark) {
                            studentSubject.taskMark = cwMark.value == "" ? null : cwMark.value;
                        }

                        return studentSubject;
                    });

                progressObj.push(student);
            });

            console.log(progressObj);

            fetchUpdateProgress(progressObj);
        });

        

        async function fetchPlan(year, groupId, semesterId) {
            if (year == "" || groupId == "" || semesterId == "") {
                return;
            }

            clearProgressTable();

            let url = `api/Progress/GetProgress?year=${year}&groupId=${groupId}&semesterId=${semesterId}`;
            console.log(url);

            const response = await fetch(url);
            const progress = await response.json();

            progress.subjects.forEach(s => {
                subjectsList.insertAdjacentHTML('beforeend', getProgressSubjectCell(s));
            });

            progress.students.forEach(s => {
                progressTable.insertAdjacentHTML('beforeend', getProgressStudentRow(s, progress.subjects));
            });

            console.log(progress);
        }

        function clearProgressTable() {
            let subjectRows =  progressTable.querySelectorAll('.progress__row-cell-subject, .progress__row-cell-subject-with-cw');
            for (let i = 0, l = subjectRows.length; i < l; i++) {
                subjectRows[i].remove();
            }

            let studentRows = progressTable.querySelectorAll('.progress__row-student');
            for (let i = 0, l = studentRows.length; i < l; i++) {
                studentRows[i].remove();
            }
        }

        async function findGroups(course, year) {
            if (course == "") {
                return;
            }

            const options = await getGroupsAsOptions(course, year);
            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        async function fetchUpdateProgress(progressObj) {
            console.log(progressObj);
            // console.log(JSON.stringify(progressObj));

            const response = await fetch(`api/Progress/UpdateProgress`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(progressObj)
            });

            console.log(response);
        };
    }
}
