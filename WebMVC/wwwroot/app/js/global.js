// For variables which will not change (do this once)
const msgContainer = document.querySelector('.notification__list');
const content = document.body.querySelector('.main__content');

// Notifications
const notificationTimeout = {
    success: 5000,
    error: 6000
};

const notificationTitle = {
    success: "Успішно",
    error: "Помилка"
};

const notificationMessages = {
    "curriculumSave": "Навчальний план був збережений",
    "curriculumSaveError": "Виникла помилка при збереженнні навчального плану",
    "curriculumEditSaveError": "Виникла помилка при збереженнні навчального плану після редагування",
    "curriculumFindError": "Виникла помилка при пошуку навчального плану",
};