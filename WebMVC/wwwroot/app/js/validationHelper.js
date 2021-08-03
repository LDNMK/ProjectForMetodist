function validateFields(fields) {
    fields.forEach(x => {
        if (!x.value) {
            x.closest('.form-element').classList.add('form-has-error');
        }
    });

    let errors = content.querySelectorAll('.form-has-error');
    if (errors.length > 0) {
        NotificationHelper.addNotification('ErrorEnum', 'Необхідно заповнити усі поля');
        return false;
    }

    return true;
}