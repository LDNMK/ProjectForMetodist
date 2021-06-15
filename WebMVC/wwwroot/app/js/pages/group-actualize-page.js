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
                        </select>
                        <div class="form-element-bar"></div>
                        <label class="form-element-label" for="group">Група</label>
                    </div>
                    <div class="main__buttons">
                        <button class="btn group__actualize-btn-add">
                            <i class="btn-icon fa fa-plus"></i>
                            <span class="btn-text">Додати</span>
                        </button>
                    </div>
                </div>
                <div class="group__actualize-right">
                    <div class="main__buttons">
                        <button class="btn group__actualize-btn-actualize">
                            <i class="btn-icon fas fa-sync-alt"></i>
                            <span class="btn-text">Актуалізувати</span>
                        </button>
                    </div>
                    <h1 class="group__actualize-right-title">Список груп</h1>
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

        const addBtn = document.querySelector('.group__actualize-btn-add');
        const actualizeBtn = document.querySelector('.group__actualize-btn-actualize');

        addBtn.addEventListener('click', () => {
            addItem(group.options[group.selectedIndex].text, group.value);
        })

        actualizeBtn.addEventListener('click', () => {
            const groupIds = [...list.children]
                .map(x => +x.getAttribute('data-group-id'))
                .filter((v, i, a) => a.indexOf(v) === i);

            fetchActualizeGroups(groupIds);
        });

        async function fetchActualizeGroups(groupIds) {
            if (groupIds.length <= 0) {
                return;
            }

            const response = await fetch(`api/Group/ActivateExistingGroups`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(groupIds)
            });

            if (response.ok) {
                list.innerHTML = "";
                fetchGetNotActiveGroups();
            }
        }

        function addItem(groupName, groupId) {
            if (groupId == "" || groupName == "") {
                return;
            }

            let item = document.createElement('li');
            item.classList.add('group__actualize-item');
            item.setAttribute('data-group-id', groupId);

            let delBtn = document.createElement('i');
            delBtn.classList.add('fas', 'fa-minus-square');
            delBtn.addEventListener('click', () => {
                list.removeChild(item);
            });

            let span = document.createElement('span');
            span.innerText = groupName;

            item.insertAdjacentElement('beforeend', delBtn);
            item.insertAdjacentElement('beforeend', span);

            list.insertAdjacentElement('beforeend', item);
        }

        async function fetchGetNotActiveGroups() {
            const response = await fetch(`api/Group/GetDeactivatedGroups`, {
                method: 'GET'
            });

            const groups = await response.json();
            let options = groups.map(x => `<option value=${x.groupId}>${x.groupName}</option>`);
            options.push(optionDefault);

            group.innerHTML = options.join('');
            group.classList.remove('-hasValue');
        }

        window.onload = fetchGetNotActiveGroups();
    }
}
