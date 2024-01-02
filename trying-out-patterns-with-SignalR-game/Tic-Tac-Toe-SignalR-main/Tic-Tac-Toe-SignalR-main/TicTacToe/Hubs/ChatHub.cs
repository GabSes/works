using Microsoft.AspNetCore.SignalR;
using TicTacToe.Models;
using System.Text.Json;
using TicTacToe.GameObjects;
using TicTacToe.Patterns.Template;
using TicTacToe.Patterns.Iterator;
using TicTacToe.Models.Memento;
using TicTacToe.Patterns.Interpreter;

namespace TicTacToe.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatCaretaker _caretaker;

        public ChatHub(ChatCaretaker caretaker)
        {
            _caretaker = caretaker;
        }

        //create storage to check existing names and dont let user enter existing name.
        public async Task SendMessage(string message)
        {
            MessageData msgData = JsonSerializer.Deserialize<MessageData>(message);
            Message msg;
            if(msgData?.Image != null)
            {
                msg = new GifMessage();
            }
            else
            {
                msg = new TextMessage();
            }

            Context context = new Context(msgData.Text);
            CombineExpression comb = new CombineExpression();
            SubtractExpression sub = new SubtractExpression();

            NonTerminalExpression nte = new NonTerminalExpression(comb, sub);

            var result = nte.Interpret(context);

            msgData.Text = result;

            var builtMessage = msg.BuildMessage(msgData);

            ChatState.Instance.AddMessage(builtMessage);
            _caretaker.SaveMessage(builtMessage);

            //uncomment for showing iterator pattern
            //foreach(var messg in ChatState.Instance.GetMessages())
            //{
            //    Console.WriteLine(messg.ToString());
            //}

            await Clients.All.SendAsync("ReceiveMessage", builtMessage);
        }

        public void AddMessageToHistory(TextMessage message)
        {

            _caretaker.SaveMessage(message);
        }

        public async Task UndoLastMessage()
        {
            var lastMessageMemento = _caretaker.GetLastMessage();
            if (lastMessageMemento != null)
            {
                // Assuming that ChatState can remove messages by sender and content
                bool isRemoved = ChatState.Instance.RemoveMessage(lastMessageMemento.SenderName, lastMessageMemento.Content);

                if (isRemoved)
                {
                    // Notify all clients that a message has been undone
                    await Clients.Others.SendAsync("MessageUndone", lastMessageMemento);
                }
            }
        }
    }
}
