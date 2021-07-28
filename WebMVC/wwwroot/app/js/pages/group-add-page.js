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
                <div class="main__col">
                    <div class="form-element form-input">
                        <input id="name" class="form-element-field" placeholder="Введіть назву групи" type="text" />
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="name">Назва групи</label>
                        <small class="form-element-hint">Формат назви групи: [Префікс]-[Номер]</small>
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
        const nameInput = document.querySelector('#name');

        saveBtn.addEventListener('click', () => {
            createGroup(nameInput.value);
        })

        nameInput.addEventListener('change', (e) => {
            let name = nameInput.value;
            let parent = e.target.closest('.form-element');

            parent.classList[name.length > 0 && name.split('-').length != 2 ? 'add' : 'remove']('form-has-error');
        });

        async function createGroup(name) {
            let errors = document.querySelectorAll('.form-has-error');
            if (errors.length) {
                console.log('You should fix errors on the page!');
                return;
            }

            if (!nameInput.value) {
                nameInput.closest('.form-element').classList.add('form-has-error');
                return;
            }

            apiHelper.fetchCreateGroup(name);
        }
    }
}
