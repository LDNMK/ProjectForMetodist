let content = document.body.querySelector('.main__content');

if (!content) {
    console.log("Tag with class\'main__content\' not found!");
}

const mapper = {
    "main--page":               MainPage,
    "student-card--add-page":   StudentCardAddPage,
    "student-card--show-page":  StudentCardShowPage,
    // "curriculum--show-page": () => "curriculum--show-page not implemented",
    "curriculum--add-page":     CurriculumAddPage,
    "transfer--page":           TransferPage,
    // "progress--page": () => "progress--page not implemented",
    "create-report--page":      CreateReportPage,
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