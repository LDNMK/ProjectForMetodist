class NotificationHelper {
    static addNotification(type, msg) {
        let data = {
            title: notificationTitle[type],
            text: msg,
            type: type,
            timeout: notificationTimeout[type]
        };
    
        let el = this._getNotificationElement(data)
        msgContainer.insertAdjacentElement('beforeend', el);
    
        setTimeout(() => {
            el.classList.remove('showNotification');
            setTimeout(() => {
                el.remove()
            }, 700);
        }, data.timeout);
    }

    static _getNotificationElement(msg) {
        let elementHTML = `
            <li class="notification__list-item showNotification ${msg.type}">
                <div class="notification__list-item-container">
                    ${notificationIcons[msg.type]}
                    <span class="notification__list-item-title">
                        ${msg.title}
                    </span>
                </div>
                <span class="notification__list-item-text">
                    ${msg.text}
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
