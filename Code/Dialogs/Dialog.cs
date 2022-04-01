using Code.Commands;
using System.Collections.Generic;

namespace Code.Dialogs
{
    public class Dialog
    {
        public string Request { get; }
        public string Responce { get; }
        public List<ICommand> Commands => _commands;

        private readonly List<ICommand> _commands = new List<ICommand>();

        public Dialog(string request, string responce, List<ICommand> commands)
        {
            Request = request;
            Responce = responce;
            _commands = commands;
        }
    }
}
