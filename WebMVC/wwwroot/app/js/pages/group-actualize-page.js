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
            <div class="main__buttons">
                <button class="btn group__actualize-btn-actualize">
                    <i class="btn-icon fas fa-sync-alt"></i>
                    <span class="btn-text">Актуалізувати</span>
                </button>
            </div>
            <div class="group__actualize">
                <div class="group__actualize-filter">
                    <h1 class="group__actualize-title group__actualize-title-filter">Список неактивних груп</h1>
                    <ul class="group__actualize-items group__actualize-items-nonactive">

                    </ul>
                </div>
                <div class="group__actualize-right">
                    <h1 class="group__actualize-title group__actualize-title-right">Список груп на актуалізацію</h1>
                    <ul class="group__actualize-items group__actualize-items-to-actulize">

                    </ul>
                </div>
            </div>
        `;
    }

    static init() {
        this._groupCardSubscribe();
    }

    static buttons = {
        "add": "<i class='add fas fa-plus-square' onClick='GroupActualizePage.addGroupToList(this, \"remove\")'></i>",
        "remove": "<i class='remove fas fa-minus-square' onClick='GroupActualizePage.addGroupToList(this, \"add\")'></i>"
    };

    static _groupCardSubscribe() {
        GroupActualizePage._itemsNonActive = document.querySelector('.group__actualize-items-nonactive');
        GroupActualizePage._itemsToActulize = document.querySelector('.group__actualize-items-to-actulize');
        
        const actualizeBtn = document.querySelector('.group__actualize-btn-actualize');

        actualizeBtn.addEventListener('click', () => {
            const groupIds = [...GroupActualizePage._itemsToActulize.children]
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
                GroupActualizePage._itemsToActulize.innerHTML = "";
            }
        }

        

        async function fetchGetNotActiveGroups() {
            const response = await fetch(`api/Group/GetDeactivatedGroups`, {
                method: 'GET'
            });

            const groups = await response.json();

            GroupActualizePage._itemsNonActive.insertAdjacentHTML("beforeend", groups.map(x => {
                return getGroupItemWithButton(x.groupName, x.groupId, GroupActualizePage.buttons["add"]);
            }).join(''));

            if (groups.length == 0) {
                GroupActualizePage._itemsNonActive.insertAdjacentHTML("beforeend", '<span>Немає неактивних груп для актуалізації</span>');
            }
        }

        window.onload = fetchGetNotActiveGroups();
    }

    static addGroupToList(e, buttonKey) {
        const parent = e.closest('.group__item');
        const groupId = parent.getAttribute('data-group-id');
        const groupName = parent.querySelector('span').innerText;
        parent.remove();

        GroupActualizePage[buttonKey == "add" ? '_itemsNonActive' : '_itemsToActulize']
            .insertAdjacentHTML('beforeend', getGroupItemWithButton(groupName, groupId, GroupActualizePage.buttons[buttonKey]));
    }
}
