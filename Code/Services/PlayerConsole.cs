using Code.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Services
{
    public class PlayerConsole
    {
        public void Print(string text, ICommand command) => 
            Print(text, new List<ICommand> { command });

        public void Print(string text, IEnumerable<ICommand> commands)
        {
            if (CommandsAreValid(commands) == false)
                throw new ArgumentException();

            Console.WriteLine(text);

            var commandNumber = 1;

            foreach (var command in commands)
                Console.WriteLine($"{commandNumber++}. {command.Description}");

            while (true)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out int selectedCommand))
                {
                    if (SelectedCommandIsValid(commands, selectedCommand))
                    {
                        commands.ElementAt( selectedCommand - 1).Execute();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Выберите действие из предложенных вариантов");
                    }
                }
                else
                {
                    Console.WriteLine("Введите номер действия и нажмите клавишу Enter");
                }
            }
        }

        public void Print(string text)
        {
            Console.WriteLine(text);

            while (true)
                Console.ReadLine();
        }

        private bool CommandsAreValid(IEnumerable<ICommand> commands) =>
            commands != null || commands.Count() > 0;

        private bool SelectedCommandIsValid(IEnumerable<ICommand> commands, int selectedCommand) =>
            selectedCommand > 0 && selectedCommand <= commands.Count();
    }
}