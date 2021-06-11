let content = document.body.querySelector('.main__content');

if (!content) {
    console.log("Tag with class\'main__content\' not found!");
}

const mapper = {
    "main--page":               MainPage,
    "student-card--add-page":   StudentCardAddPage,
    "student-card--show-page":  StudentCardShowPage,
    // "curriculum--show-page": () => "curriculum--show-page not implemented",
    // "curriculum--add-page": () => "curriculum--add-page not implemented",
    // "transfer--page": () => "transfer--page not implemented",
    // "progress--page": () => "progress--page not implemented",
    // "report--add-page": () => "report--add-page not implemented",
    "group--add-page":          GroupAddPage,
    "group--actualize-page":    GroupActualizePage,
};

function setPageByAttribute(attr) {
    if (!(attr in mapper)) {
        console.log(`Tag with attribute data-page='${attr}' not found!`);
        return;
    }

    let obj = mapper[attr];
    content.innerHTML = obj.page;
    obj.init();
}