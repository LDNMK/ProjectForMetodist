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

                    <div class="form-checkbox form-checkbox-inline">
                        <label class="form-checkbox-label">
                            <input class="form-checkbox-field" type="checkbox" id="select-student"/>
                            <i class="form-checkbox-button"></i>
                            <span>Обрати студента</span>
                        </label>
                    </div>

                    <div class="form-element form-select">
                        <select class="form-element-field" id="student" disabled>
                            <option class="form-select-placeholder" value="" disabled selected></option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="student">
                            Студент
                            <i class="btn-clear btn-hide fas fa-times"></i>
                        </label>
                    </div>
                </div>

                <div class="transfer__actions">
                    <h1 class="main__page-subtitle">Дії</h1>

                    <div>
                        <button class="btn transfer__btn-transfer" data-transfer-key="1">
                            <i class="btn-icon fas fa-user-check"></i>
                            <span class="btn-text">Перевести</span>
                        </button>
                    </div>
                    <div>
                        <button class="btn transfer__btn-vacation" data-transfer-key="2" disabled>
                            <i class="btn-icon fas fa-user-lock"></i>
                            <span class="btn-text">Академічна відпустка</span>
                        </button>
                    </div>
                    <div>
                        <button class="btn transfer__btn-leave" data-transfer-key="3" disabled>
                            <i class="btn-icon fas fa-user-clock"></i>
                            <span class="btn-text">Залишити на другий рік</span>
                        </button>
                    </div>
                    <div>
                        <button class="btn transfer__btn-remove" data-transfer-key="4" disabled>
                            <i class="btn-icon fas fa-user-times"></i>
                            <span class="btn-text">Відрахувати</span>
                        </button>
                    </div>
                    <div>
                        <button class="btn transfer__btn-resume" data-transfer-key="5" disabled>
                            <i class="btn-icon fas fa-user-plus"></i>
                            <span class="btn-text">Відновити</span>
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
        const studentCheckbox = document.querySelector('#select-student');
        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const studentSelect = document.querySelector('#student');

        const clearStudentBtn = document.querySelector('.btn-clear');
        const buttons = [
            document.querySelector('.transfer__btn-transfer'),
            document.querySelector('.transfer__btn-vacation'),
            document.querySelector('.transfer__btn-leave'),
            document.querySelector('.transfer__btn-remove'),
            document.querySelector('.transfer__btn-resume')
        ];

        buttons.forEach(b => {
            b.addEventListener('click', () => {
                if (studentCheckbox.checked && !studentSelect.value) {
                    console.log(`Error: the student wasn't select`)
                } else if (studentSelect.value) {
                    fetchTransferStudent(b.getAttribute('data-transfer-key'));
                } else {
                    fetchTransferGroup(groupSelect.value);
                }
            });
        });

        clearStudentBtn.addEventListener('click', () => {
            studentSelect.classList.remove('-hasValue');
            studentSelect.value = "";
            clearStudentBtn.classList.add('btn-hide');

            updateDisableAttrButtons(!(!!studentSelect.value));
        });

        groupSelect.addEventListener('change', () => {
            fetchStudents(groupSelect.value);
        });

        studentCheckbox.addEventListener('click', () => {
            studentSelect.disabled = !studentCheckbox.checked;

            if (!studentCheckbox.checked) {
                clearStudentBtn.dispatchEvent(new Event('click'));
            }
        });

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        });

        studentSelect.addEventListener('change', () => {
            clearStudentBtn.classList[studentSelect.value ? 'remove' : 'add']('btn-hide');
            
            updateDisableAttrButtons(!(!!studentSelect.value));
        });

        async function updateDisableAttrButtons(value) {
            buttons.forEach(b => {
                if (!b.classList.contains('transfer__btn-transfer')) {
                    b.disabled = value;
                }
            });
        }

        async function fetchGroups(course) {
            if (course == "") {
                return;
            }

            const response = await fetch(`api/Group/GetListOfGroups?course=${course}`);
            const groups = await response.json();

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');

            clearStudentBtn.dispatchEvent(new Event('click'));
            studentSelect.innerHTML = "";
        };

        async function fetchStudents(groupId) {
            if (groupId == "") {
                studentSelect.innerHTML = "";
                return;
            }

            const response = await fetch(`api/StudentCard/GetListOfStudents?groupId=${groupId}`);
            const students = await response.json();

            let options = students.map(x => `<option value=${x.studentId}>${x.studentName}</option>`);
            options.push(optionDefault);

            studentSelect.innerHTML = options.join('');
            studentSelect.classList.remove('-hasValue');

            clearStudentBtn.dispatchEvent(new Event('click'));
        };

        async function fetchTransferGroup(groupId) {
            console.log('transfer group');

            return;

            if (groupId == "") {
                return;
            }

            const response = await fetch(`api/Transfer/TransferGroups`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(groupId)
            });
        }

        async function fetchTransferStudent(action) {
            let groupId = groupSelect.value;
            let studentId = studentSelect.value;

            console.log(action);

            if (groupId == "" || studentId == "") {
                return;
            }

            return;

            const response = await fetch(`api/Transfer/TransferStudent`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json'
                },
                // How to send params? via object? should create DTO?
                body: JSON.stringify(groupId)
            });
        }
    }
}
