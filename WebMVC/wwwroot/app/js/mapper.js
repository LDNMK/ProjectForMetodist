let tag = document.body.querySelector('.main__content');

if (!tag) {
    console.log("Tag with class\'main__content\' not found!");
}

const mapper = {
    "mainPage": () => "not implemented",
    "studentCardAddPage": () => "not implemented",
    "studentCardShowPage": getStudentCardShowPage,
};

function setPageByAttribute(attr) {
    console.log(attr);
    if (!(attr in mapper)) {
        console.log(`Tag with attribute data-page='${attr}' not found!`);
        return;
    }

    // let page = mapper[attr]()
    // tag.innerHTML = page.data;
    // if (page.hasFormElements) {
    //      subscribeFormElements();
    // }

    tag.innerHTML = mapper[attr]();
    subscribeFormElements();
}