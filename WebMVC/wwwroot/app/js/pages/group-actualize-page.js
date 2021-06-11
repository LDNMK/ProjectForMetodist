class GroupActualizePage extends Page {
    constructor() {
        super();
    }

    static get is() {
        return 'group--actualize-page';
    }

    static get page() {
        return `
            <h1 class="main__page-title">Актуалізування груп</h1>
            <div class="group__actualize">
                <div class="group__actualize-filter">
                    <div class="form-element form-select">
                        <select class="form-element-field" id="group">
                            <option class="form-select-placeholder" value="" disabled selected></option>
                            <option value="1">КН-21 TEST</option>
                            <option value="2">БІКС-21 TEST</option>
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="group">Група</label>
                    </div>
                    <div class="main__buttons">
                        <button class="btn group__actualize__btn-add">
                            <i class="btn-icon fa fa-plus"></i>
                            <span class="btn-text">Додати</span>
                        </button>
                    </div>
                </div>
                <div class="group__actualize-list">
                    <h1 class="group__actualize-list-title">Список груп</h1>
                    <ul class="group__actualize-items">

                    </ul>
                </div>
            </div>
        `;
    }

    static init() {
        this._groupCardSubscribe();
        subscribeFormElements();
    }

    static _groupCardSubscribe() {
        let list = document.querySelector('.group__actualize-items');
        let group = document.querySelector('#group');
        const addBtn = document.querySelector('.group__actualize__btn-add');

        let counter = 0;

        addBtn.addEventListener('click', () => {
            addItem(group.options[group.selectedIndex].text, group.value);
        })

        function addItem(groupName, groupId) {
            console.log(`id: ${groupId} name: ${groupName}`);

            if (groupId == "" || groupName == "") {
                return;
            }

            let item = document.createElement('li');
            item.classList.add('group__actualize-item');
            item.setAttribute('data-group-id', groupId);

            let delBtn = document.createElement('i');
            delBtn.classList.add('fas', 'fa-trash-alt');
            delBtn.addEventListener('click', () => {
                list.removeChild(item);
            });

            let span = document.createElement('span');
            span.innerText = groupName;

            item.insertAdjacentElement('beforeend', delBtn);
            item.insertAdjacentElement('beforeend', span);

            list.insertAdjacentElement('beforeend', item);
        }

        // async function fetchCreateGroup(year, name) {
        //     if (year == "" || name == "") {
        //         return;
        //     }

        //     const response = await fetch(`api/Group/CreateGroup?groupName=${name}`, {
        //         method: 'POST'
        //     });

        //     // TODO: Process response
        // }
    }
}
