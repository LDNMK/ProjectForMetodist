/** @abstract */
class Page {
    constructor() {}

    static getPage() {
        return 'not implemented';
    }

    static subscribe() {
        console.log('not subscribed');
    }

    static is() {
        return 'Page';
    }

    static _idsToClear() {
        return [];
    }
}

