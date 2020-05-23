function solve() {
   let sendButton = document.getElementById('send');

   sendButton.addEventListener('click', (e) => {
      let messageBox = document.getElementById('chat_input');

      let newMessage = document.createElement('div');
      newMessage.className = 'message my-message';
      newMessage.innerHTML = messageBox.value;

      messageBox.value = '';
      let chatMessages = document.getElementById('chat_messages');
      chatMessages.appendChild(newMessage);
   })
}