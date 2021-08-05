function validateFields(fields, checkOnlyFields) {
    let counter = 0;
    fields.forEach(x => {
        if (!x.value) {
            x.closest('.form-element').classList.add('form-has-error');
            ++counter;
        }
    });

    // checking only elements in the array
    if (checkOnlyFields) {
        return checkOnlyFields > 0;
    }

    // checking all elements at the page
    let errors = content.querySelectorAll('.form-has-error');
    if (errors.length > 0) {
        NotificationHelper.addNotification('ErrorEnum', 'Необхідно заповнити усі поля');
        return false;
    }

    return true;
}