const notificationContainer = document.querySelector('.notification__list');

const notificationSettings = {
    "SuccessEnum": {
        timeout: 5000,
        title: "Успішно",
        icon: `<i class="success-icon fas fa-check-circle"></i>`,
        type: "success"
    },
    "WarningEnum": {
        timeout: 6000,
        title: "Попередження",
        icon: `<i class="warning-icon fas fa-exclamation-circle"></i>`,
        type: "warning"
    },
    "ErrorEnum": {
        timeout: 6000,
        title: "Помилка",
        icon: `<i class="error-icon fas fa-times-circle"></i>`,
        type: "error"
    }
}

class NotificationHelper {
    static addNotification(type, msg) {
        let data = notificationSettings[type];
        data.text = msg;
    
        let el = this._getNotificationElement(data)
        notificationContainer.insertAdjacentElement('beforeend', el);
    
        setTimeout(() => {
            el.classList.remove('showNotification');
            setTimeout(() => {
                el.remove()
            }, 700);
        }, data.timeout);
    }

    static _getNotificationElement(data) {
        let elementHTML = `
            <li class="notification__list-item showNotification ${data.type}">
                <div class="notification__list-item-container">
                    ${data.icon}
                    <span class="notification__list-item-title">
                        ${data.title}
                    </span>
                </div>
                <span class="notification__list-item-text">
                    ${data.text}
                </span>
            </li>
        `;
    
        return this._createElementFromHTML(elementHTML.trim());
    }

    static _createElementFromHTML(htmlString) {
        var div = document.createElement('div');
        div.innerHTML = htmlString.trim();
      
        return div.firstChild;
    }
}
