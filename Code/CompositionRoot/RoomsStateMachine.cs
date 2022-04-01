using Code.CompositionRoot.Factories;
using Code.Player;
using Code.Rooms;
using Code.Services;
using System;
using System.Collections.Generic;

namespace Code.CompositionRoot
{
    public class RoomsStateMachine
    {
        private readonly Dictionary<Type, BaseRoom> _rooms;

        public RoomsStateMachine(PlayerConsole console, PlayerProgress progress)
        {
            _rooms = new Dictionary<Type, BaseRoom>
            {
                [typeof(Tavern)] = new TavernFactory(console, progress).Create()
            };
        }

        public void Enter<TRoom>() where TRoom : BaseRoom
        {
            BaseRoom room = ChangeState<TRoom>();
            room.Enter();
        }

        private TRoom ChangeState<TRoom>() where TRoom : BaseRoom
        {
            TRoom room = GetRoom<TRoom>();

            return room;
        }

        private TRoom GetRoom<TRoom>() where TRoom : BaseRoom =>
            _rooms[typeof(TRoom)] as TRoom;
    }
}