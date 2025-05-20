// Sample notification data
const notifications = [
    {
        id: 1,
        title: 'Kitap İade Hatırlatması',
        message: '"Beyaz Geceler" kitabının iade tarihi yaklaşıyor. Lütfen 3 gün içinde iade ediniz.',
        date: '15:32 - 12.05.2024',
        priority: 'Yüksek Öncelikli',
        icon: 'fa-book'
    },
    {
        id: 2,
        title: 'Yeni Kitap Duyurusu',
        message: 'İlgilendiğiniz "Suç ve Ceza" kitabı kütüphanemize yeni eklendi.',
        date: '09:15 - 11.05.2024',
        priority: 'Normal',
        icon: 'fa-bookmark'
    },
    {
        id: 3,
        title: 'Etkinlik Duyurusu',
        message: 'Bu Cumartesi saat 14:00\'da "Edebiyat Söyleşisi" etkinliğimize davetlisiniz.',
        date: '18:00 - 10.05.2024',
        priority: 'Normal',
        icon: 'fa-calendar'
    }
];

// Define messages object for each view
const messages = {
    robot: {
        header: 'BASK',
        content: '',
        headerClass: ''
    },
    comment: {
        header: 'Mesajlar',
        content: '',
        headerClass: 'comment'
    },
    bell: {
        header: 'Bildirimler',
        content: '',
        headerClass: 'bell'
    }
};

let eventAttached = false;

function setActive(type) {
    const header = document.getElementById('phoneHeader');
    const content = document.getElementById('phoneContent');
    const robotInputArea = document.getElementById('robotInputArea');
    const quickBubbles = document.getElementById('quickBubbles');
    const commentBubbles = document.getElementById('commentBubbles');
    const userList = document.getElementById('userList');
    const notificationsList = document.getElementById('notificationsList');
    const notificationDetail = document.getElementById('notificationDetail');

    header.textContent = messages[type].header;
    header.className = 'phone-header' + (messages[type].headerClass ? ' ' + messages[type].headerClass : '');

    // Clear phone content
    if (type !== 'robot') {
        content.innerHTML = '';
        content.appendChild(notificationsList);
        content.appendChild(notificationDetail);
    }

    if (type === 'robot') {
        // Show robot UI elements
        robotInputArea.classList.remove('hidden');
        if (quickBubbles) quickBubbles.classList.remove('hidden');
        if (commentBubbles) commentBubbles.classList.add('hidden');
        if (userList) userList.classList.add('hidden');
        if (notificationsList) notificationsList.classList.add('hidden');
        if (notificationDetail) notificationDetail.classList.add('hidden');

        // Clear content if empty
        if (content.innerHTML.trim() === '') {
            content.innerHTML = '<div class="message">Merhaba! Size nasıl yardımcı olabilirim?</div>';
        }

        attachBubbleEvents();
    } else if (type === 'comment') {
        // Show comment UI elements
        robotInputArea.classList.add('hidden');
        if (quickBubbles) quickBubbles.classList.add('hidden');
        if (commentBubbles) commentBubbles.classList.remove('hidden');
        if (userList) userList.classList.remove('hidden');
        if (notificationsList) notificationsList.classList.add('hidden');
        if (notificationDetail) notificationDetail.classList.add('hidden');

        renderUserList('all');
        attachCommentBubbleEvents();
    } else if (type === 'bell') {
        // Show notification UI elements
        robotInputArea.classList.add('hidden');
        if (quickBubbles) quickBubbles.classList.add('hidden');
        if (commentBubbles) commentBubbles.classList.add('hidden');
        if (userList) userList.classList.add('hidden');
        if (notificationsList) notificationsList.classList.remove('hidden');
        if (notificationDetail) notificationDetail.classList.add('hidden');

        loadNotifications();
    }
}

function loadNotifications() {
    const notificationsList = document.getElementById('notificationsList');
    notificationsList.innerHTML = '';

    if (notifications.length === 0) {
        notificationsList.innerHTML = '<div class="no-notification">Aktif bildiriminiz bulunmamaktadır.</div>';
        return;
    }

    notifications.forEach(notification => {
        const notificationElement = document.createElement('div');
        notificationElement.className = 'notification-rectangle';
        notificationElement.dataset.id = notification.id;
        notificationElement.innerHTML = `
                        <div class="notification-icon"><i class="fa ${notification.icon}"></i></div>
                        <div class="notification-title">${notification.title}</div>
                    `;
        notificationsList.appendChild(notificationElement);
    });

    setupNotificationEvents();
}

function attachBubbleEvents() {
    const bubbles = document.querySelectorAll('#quickBubbles .quick-bubble');
    bubbles.forEach(function (bubble) {
        // Remove previous event listeners by cloning
        const newBubble = bubble.cloneNode(true);
        bubble.parentNode.replaceChild(newBubble, bubble);
        newBubble.addEventListener('click', function () {
            sendRobotMessage(newBubble.getAttribute('data-msg'));
        });
    });
}

function attachCommentBubbleEvents() {
    const bubbles = document.querySelectorAll('#commentBubbles .quick-bubble');
    bubbles.forEach(function (bubble) {
        bubble.classList.remove('selected');
        if (bubble.getAttribute('data-type') === 'all') {
            bubble.classList.add('selected');
        }
        // Remove previous event listeners by cloning
        const newBubble = bubble.cloneNode(true);
        bubble.parentNode.replaceChild(newBubble, bubble);
        newBubble.addEventListener('click', function () {
            document.querySelectorAll('#commentBubbles .quick-bubble').forEach(b => b.classList.remove('selected'));
            newBubble.classList.add('selected');
            renderUserList(newBubble.getAttribute('data-type'));
        });
    });
}

function setRobotInputEnabled(enabled) {
    const textarea = document.getElementById('robotMessage');
    const button = document.getElementById('btnSendRobot');
    textarea.disabled = !enabled;
    button.disabled = !enabled;
}

function sendRobotMessage(text) {
    if (text && text.trim().length > 0) {
        const content = document.getElementById('phoneContent');
        // Remove quick bubbles after sending
        const quickBubbles = document.getElementById('quickBubbles');
        if (quickBubbles) quickBubbles.classList.add('hidden');
        const msgDiv = document.createElement('div');
        msgDiv.className = 'message sent';
        msgDiv.textContent = text;
        content.appendChild(msgDiv);
        content.scrollTop = content.scrollHeight;

        setRobotInputEnabled(false);

        setTimeout(function () {
            const replyDiv = document.createElement('div');
            replyDiv.className = 'message';
            replyDiv.textContent = 'Robot cevabı: ' + text;
            content.appendChild(replyDiv);
            content.scrollTop = content.scrollHeight;
            setRobotInputEnabled(true);
            const quickBubbles = document.getElementById('quickBubbles');
            if (quickBubbles) quickBubbles.classList.remove('hidden');
        }, 2000);
    }
}


function setupNotificationEvents() {
    const notifications = document.querySelectorAll('.notification-rectangle');
    notifications.forEach(notification => {
        notification.addEventListener('click', function () {
            const id = this.dataset.id;
            const notificationData = getNotificationById(parseInt(id));

            if (notificationData) {
                showNotificationDetail(
                    notificationData.title,
                    notificationData.message,
                    notificationData.date,
                    notificationData.priority
                );
            }
        });
    });
}

function getNotificationById(id) {
    return notifications.find(n => n.id === id);
}

function showNotificationDetail(title, message, date, priority) {
    document.getElementById('notificationsList').classList.add('hidden');
    document.getElementById('notificationDetail').classList.remove('hidden');

    document.getElementById('detailTitle').textContent = title;
    document.getElementById('detailMessage').textContent = message;
    document.getElementById('detailDate').innerHTML = `<i class="fa fa-clock"></i> ${date}`;
    document.getElementById('detailPriority').innerHTML = `<i class="fa fa-flag"></i> ${priority}`;
}

function hideNotificationDetail() {
    document.getElementById('notificationDetail').classList.add('hidden');
    document.getElementById('notificationsList').classList.remove('hidden');
}

// Initialize the application
document.addEventListener('DOMContentLoaded', function () {
    // Setup event handlers
    document.getElementById('btnRobot').addEventListener('click', function () {
        setActive('robot');
    });

    document.getElementById('btnComment').addEventListener('click', function () {
        setActive('comment');
    });

    document.getElementById('btnBell').addEventListener('click', function () {
        setActive('bell');
    });

    document.getElementById('btnSendRobot').addEventListener('click', function () {
        const textarea = document.getElementById('robotMessage');
        const text = textarea.value.trim();
        if (text.length > 0) {
            sendRobotMessage(text);
            textarea.value = '';
        }
    });

    document.getElementById('robotMessage').addEventListener('keydown', function (e) {
        if (e.key === 'Enter' && !e.shiftKey) {
            e.preventDefault();
            document.getElementById('btnSendRobot').click();
        }
    });

    // Set default view to robot on load
    setActive('robot');

    // Make sure the event handlers for notifications work
    loadNotifications();
});