function subscribeFormElements() {
    let formItems = document.body.querySelectorAll('.form-element-field');

    formItems.forEach(x => 
        x.addEventListener('change', (e) => {
            let element = e.target;
            element.classList[element.value ? "add" : "remove"]("-hasValue");
        })
    );
}
