class TransferPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'transfer--page';
    }

    static get page() {
        return `
            <h1 class="main__page-title">Переведення</h1>
            <div class="transfer__grid">
                <div class="transfer__filter">
                    <h1 class="main__page-subtitle">Пошук</h1>

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
                        <input id="year" class="form-element-field" data-obj-key="year" placeholder="Введіть рік" type="number" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="year">Рік</label>
                        <small class="form-element-hint">Необхідно задати значення</small>
                    </div>

                    <div class="main__buttons">
                        <button class="btn transfer__btn-find" id="btn-find">
                            <i class="btn-icon fas fa-users"></i>
                            <span class="btn-text">Знайти студентів</span>
                        </button>
                    </div>
                </div>

                <div class="transfer__students">
                    <h1 class="main__page-subtitle">Список студентів</h1>

                    <div>
                        <div class="transfer__student-head">
                            <span>ФІО</span>
                            <span>Статус</span>
                        </div>
                        <ul class="transfer__students-list">
                            
                        </ul>
                    </div>

                    <div class="main__buttons">
                        <button class="btn transfer__btn-transfer" id="btn-transfer">
                            <i class="btn-icon fas fa-people-arrows"></i>
                            <span class="btn-text">Зберегти</span>
                        </button>
                    </div>
                </div>
            </div>
        `;
    }

    static init() {
        this._groupCardSubscribe();
        subscribeFormElements();
    }

    static _groupCardSubscribe() {
        const studentsList = document.querySelector('.transfer__students-list');

        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const yearInput = document.querySelector('#year');
        const fieldsForValidate = [courseSelect, yearInput, groupSelect];
        
        const findBtn = document.querySelector('#btn-find');
        const transferBtn = document.querySelector('#btn-transfer');

        courseSelect.addEventListener('change', (e) => {
            if (!isFieldEmpty(e)) {
                findGroups(courseSelect.value);
            }
        });

        groupSelect.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        yearInput.addEventListener('change', (e) => {
            isFieldEmpty(e);
        });

        findBtn.addEventListener('click', () => {
            if (validateFields(fieldsForValidate)) {
                findStudents(groupSelect.value, yearInput.value);
            }
        });

        transferBtn.addEventListener('click', () => {
            saveTransferStudent();
        });
        
        async function findGroups(course) {
            if (course == "") {
                return;
            }

            const options = await getGroupsAsOptions(course);
            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        async function findStudents(groupId, year) {
            if (groupId == "" || year == "") {
                return;
            }

            studentsList.innerHTML = "";

            const students = await apiHelper.fetchGetStudentsForTransfer(groupId, year);
            students.forEach(x => {
                studentsList.insertAdjacentHTML('beforeend', getTransferStudentRow(x));
            });
        };

        async function saveTransferStudent() {
            let students = [];

            const data = [...studentsList.querySelectorAll('.transfer__student-row.active')];
            data.forEach(x => {
                const studentData = x.querySelectorAll('[data-transfer-key]');
                
                let student = {
                    groupId: groupSelect.value
                };

                studentData.forEach(s => {
                    student[s.getAttribute('data-transfer-key')] = s.tagName == "SPAN" ? s.innerText : s.value;
                });

                students.push(student);
            });

            apiHelper.fetchUpdateTransferStudents(students);
        }
    }
}
