let content = document.body.querySelector('.main__content');

if (!content) {
    console.log("Container with class\'main__content\' not found!");
}

const mapper = {
    "mainPage": () => "not implemented",
    "studentCardAddPage": () => "not implemented",
    "studentCardShowPage": () => getStudentCardShow(),
};

function setPageByAttribute(attr) {
    if (!(attr in mapper)) {
        console.log(`Tag with attribute data-page='${attr}' not found!`);
        return;
    }

    content.innerHTML = mapper[attr]();
}

