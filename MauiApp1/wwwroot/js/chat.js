// Ensure functions are globally accessible
window.chatHelpers = {
    scrollToBottom: function () {
        // Prefer scrolling the last message into view to avoid being hidden under input
        var messagesContainer = document.querySelector('.chat-container .messages');
        if (!messagesContainer) return;

        var lastMessage = messagesContainer.querySelector('.message:last-child');
        if (lastMessage) {
            // Scroll last message into view aligned to the bottom
            lastMessage.scrollIntoView({ behavior: 'instant', block: 'end' });
        } else {
            // Fallback: scroll container to bottom
            messagesContainer.scrollTop = messagesContainer.scrollHeight;
        }
    },

    adjustMessagesBottomPadding: function () {
        // Add bottom padding to messages equal to input container height
        var messagesContainer = document.querySelector('.chat-container .messages');
        var inputContainer = document.querySelector('.chat-container .input-container');
        if (!messagesContainer || !inputContainer) return;

        var inputHeight = inputContainer.offsetHeight || 0;
        messagesContainer.style.paddingBottom = inputHeight + 'px';
    }
};
