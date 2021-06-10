class MainPage extends Page {
    constructor() {
        super();
    }

    static get page() {
        return `
            <h1>Main page</h1>
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