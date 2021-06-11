class GroupAddPage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'group--add-page';
    }

    static get page() {
        return `
            <h1 class="main__page-title">Створення групи</h1>
            <div class="group__add">
                <div class="main__col-2">
                    <div class="form-element form-input">
                        <input id="year" class="form-element-field" placeholder="Введіть рік" type="number" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="year">Рік</label>
                    </div>
                    <div class="form-element form-input">
                        <input id="name" class="form-element-field" placeholder="Введіть назву групи" type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="name">Назва групи</label>
                    </div>
                </div>

                <div class="main__col">
                    <div class="main__buttons">
                        <button class="btn group__add__btn-save">
                            <i class="btn-icon fas fa-save"></i>
                            <span class="btn-text">Створити групу</span>
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
        const saveBtn = document.querySelector('.group__add__btn-save');

        const year = document.querySelector('#year');
        const name = document.querySelector('#name');

        saveBtn.addEventListener('click', () => {
            fetchCreateGroup(year.value, name.value);
        })

        async function fetchCreateGroup(year, name) {
            if (year == "" || name == "") {
                return;
            }

            const response = await fetch(`api/Group/CreateGroup?groupName=${name}`, {
                method: 'POST'
            });

            // TODO: Process response
        }
    }
}
