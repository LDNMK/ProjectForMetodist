class MainPage extends Page {
    constructor() {
        super();
    }

    static getPage() {
        return `
            <h1>Main page</h1>
        `;
    }

    static subscribe() {
        super.subscribe();
    }

    static is() {
        return 'main--page';
    }
}

function initMainPage() {
    setPageByAttribute(MainPage.is());
}