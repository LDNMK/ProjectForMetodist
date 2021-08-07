class MainPage extends Page {
    constructor() {
        super();
    }

    static get page() {
        return `
            <h1 class="main__page-title">Головна сторінка</h1>
            <p>
                Скористайтеся меню зліва для зміни контенту
            </p>
        `;
    }

    static subscribe() {
        super.subscribe();
    }

    static get is() {
        return 'main--page';
    }
}

function initMainPage() {
    setPageByAttribute(MainPage.is);
}