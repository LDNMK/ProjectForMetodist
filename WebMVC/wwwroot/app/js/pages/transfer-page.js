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

                    <div class="form-element form-input">
                        <input id="year" class="form-element-field" data-obj-key="year" placeholder="Введіть рік" type="number" />
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

                    <div class="main__buttons">
                        <button class="btn transfer__btn-find" id="btn-find">
                            <i class="btn-icon fas fa-users"></i>
                            <span class="btn-text">Знайти студентів</span>
                        </button>
                    </div>
                </div>

                <div class="transfer__students">
                    <h1 class="main__page-subtitle">Список студентів</h1>

                    <ul class="transfer__students-list">
                        
                    </ul>

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
        const yearInput = document.querySelector('#year');
        const courseSelect = document.querySelector('#course');
        const groupSelect = document.querySelector('#group');
        const findBtn = document.querySelector('#btn-find');
        const transferBtn = document.querySelector('#btn-transfer');

        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value);
        });

        findBtn.addEventListener('click', () => {
            fetchStudents(groupSelect.value, yearInput.value);
        });

        transferBtn.addEventListener('click', () => {
            fetchTransferStudent();
        });
        
        async function fetchGroups(course) {
            if (course == "") {
                console.log('Course is empty');
                return;
            }

            const response = await fetch(`api/Group/GetGroups?course=${course}`);
            const groups = await response.json();

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');
        };

        async function fetchStudents(groupId, year) {
            if (groupId == "" || year == "") {
                studentsList.innerHTML = "";
                return;
            }

            const response = await fetch(`api/Transfer/GetStudentsForTransfer?groupId=${groupId}&year=${year}`);
            const students = await response.json();

            studentsList.innerHTML = "";
            studentsList.insertAdjacentHTML('beforeend', getTransferStudentHead());
            students.forEach(x => {
                studentsList.insertAdjacentHTML('beforeend', getTransferStudentRow(x));
            });
        };

        async function fetchTransferStudent() {
            let students = [];

            const data = [...studentsList.querySelectorAll('.transfer__student-row')];
            data.forEach(x => {
                const studentData = x.querySelectorAll('[data-transfer-key]');
                
                let student = {};
                studentData.forEach(s => {
                    student[s.getAttribute('data-transfer-key')] = s.tagName == "SPAN" ? s.innerText : s.value;
                });

                students.push(student);
            });

            console.log(students);

            // const response = await fetch(`api/Transfer/TransferStudents`, {
            //     method: 'PUT',
            //     headers: {
            //         'Content-Type': 'application/json'
            //     },
            //     body: JSON.stringify(students)
            // });
        }
    }
}
