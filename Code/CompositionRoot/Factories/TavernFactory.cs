using Code.Characters;
using Code.Commands;
using Code.Dialogs;
using Code.Player;
using Code.Rooms;
using Code.Services;
using System.Collections.Generic;

namespace Code.CompositionRoot.Factories
{
    public class TavernFactory : IRoomFactory
    {
        private readonly PlayerConsole _console;
        private readonly PlayerProgress _progress;

        public TavernFactory(PlayerConsole console, PlayerProgress progress)
        {
            _console = console;
            _progress = progress;
        }

        public BaseRoom Create()
        {
            var nomad = new Nomad();
            var room = new Tavern(_console);

            ConfigureRoom(nomad, room);
            ConfigureNomad(nomad, room);

            return room;
        }

        private void ConfigureRoom(Nomad nomad, Tavern room)
        {
            room.AddCharacter(nomad);

            var dialogCommand = new CharactersDialog(_console, nomad);
            var descriptionCommand = new TavernDescription(_console, new ReturnToCommands(_console, room.Commands));

            room.AddCommand(dialogCommand);
            room.AddCommand(descriptionCommand);
        }

        private void ConfigureNomad(Nomad nomad, Tavern room)
        {
            var returnCommand = new ReturnToCommands(_console, room.Commands);
            var robCharacterCommand = new RobCharacter(_console, returnCommand, _progress);
            var playerDeathCommand = new PlayerDeath(_console);

            var dialogBeforRobbery = new Dialog(
                request: "Жизнь или смерть, грязный бродяга!",
                responce: "Вот возьми всё что у меня есть, только не трогай меня",
                commands: new List<ICommand> { robCharacterCommand, playerDeathCommand });

            var dialogAfterRobbery = new Dialog(
                request: "Жизнь или смерть, грязный бродяга!",
                responce: "У меня больше ничего нет",
                commands: new List<ICommand> { returnCommand });

            nomad.AddDialog(dialogBeforRobbery);
            nomad.AddDialog(dialogAfterRobbery);
        }
    }
}