/** @abstract */
class Page {
    constructor() {}

    static getPage() {
        return 'not implemented';
    }

    static init() {
        console.log('not initialized');
    }

    static is() {
        return 'Page';
    }

    static _idsToClear() {
        return [];
    }
}

