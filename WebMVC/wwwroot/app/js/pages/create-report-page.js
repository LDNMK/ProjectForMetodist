class CreateReportPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'create-report--page';
    }

    static get page() {
        return `
            <h1 class="main__page-title">Створення звіту</h1>
            <div class="create-report">
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
                    <div class="form-element form-input">
                        <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="year">Рік</label>
                    </div>
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
                        <select class="form-element-field" id="group">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="group">Група</label>
                    </div>
                </div>
                <div class="form-element form-select">
                    <select class="form-element-field" id="student">
                        <option class="form-select-placeholder" value="" disabled selected></option>
                    </select>
                    <div class="form-element-bar"></div>
                    <label class="form-element-label" for="student">Студент</label>
                </div>
                <div class="main__buttons">
                    <button class="btn create-report__create-btn">
                        <i class="btn-icon fas fa-plus"></i>
                        <span class="btn-text">Створити звіт</span>
                    </button>
                </div>
            </div>
        `;
    }

    static init() {
        this._groupCardSubscribe();
        subscribeFormElements();
    }

    static _groupCardSubscribe() {
        const courseSelect = document.querySelector('#course');
        const yearInput = document.querySelector('#year');
        const groupSelect = document.querySelector('#group');
        const studentSelect = document.querySelector('#student');
        const createBtn = document.querySelector('.create-report__create-btn');
        
        courseSelect.addEventListener('change', () => {
            fetchGroups(courseSelect.value, yearInput.value);
        });

        yearInput.addEventListener('change', () => {
            fetchGroups(courseSelect.value, yearInput.value);
        });

        groupSelect.addEventListener('change', () => {
            fetchStudents(groupSelect.value, yearInput.value);
        });


        createBtn.addEventListener('click', () => {
            createReport(studentSelect.value)
        })

        async function fetchGroups(course, year) {
            if (course == "" || year =="") {
                return;
            }

            let url = `api/Group/GetGroups?course=${course}&year=${year}`;

            const response = await fetch(url);
            const groups = await response.json();

            console.log(groups);

            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            groupSelect.innerHTML = options.join('');
            groupSelect.classList.remove('-hasValue');

            studentSelect.value = "";
            studentSelect.innerHTML = optionDefault;
            studentSelect.classList.remove('-hasValue');
        };

        async function fetchStudents(groupId, year) {
            if (groupId == "") {
                return;
            }
            if (year == "") {
                alert("write year");
            }
            const response = await fetch(`api/StudentCard/GetStudents?groupId=${groupId}&year=${year}`);
            const students = await response.json();

            let options = students.map(x => `<option value=${x.studentId}>${x.studentName}</option>`);
            options.push(optionDefault);

            studentSelect.innerHTML = options.join('');
            studentSelect.classList.remove('-hasValue');
        };

        async function createReport(studentId) {
            if (studentId == "") {
                return;
            }

            const response = await fetch(`api/Report/CreateReport?studentId=${studentId}`);
            const report = await response.json();
        };
    }
}
