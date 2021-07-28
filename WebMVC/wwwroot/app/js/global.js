// For variables which will not change (do this once)
const msgContainer = document.querySelector('.notification__list');
const content = document.body.querySelector('.main__content');

// Notifications
const notificationTimeout = {
    success: 5000,
    warning: 6000,
    error: 6000
};

const notificationTitle = {
    success: "Успішно",
    warning: "Попередження",
    error: "Помилка"
};

const notificationIcons = {
    success: `<i class="success-icon fas fa-check-circle"></i>`,
    warning: `<i class="warning-icon fas fa-exclamation-circle"></i>`,
    error:   `<i class="error-icon fas fa-times-circle"></i>`
};