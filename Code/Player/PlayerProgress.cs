using Code.Items;
using System;
using System.Collections.Generic;

namespace Code.Player
{
    public class PlayerProgress
    {
        private readonly Dictionary<IItem, int> _items = new Dictionary<IItem, int>();
        private int _coins;
 
        public void AddItem(IItem item, int count)
        {
            if (ItemIsValid(item, count) == false)
                throw new ArgumentException();

            if (_items.ContainsKey(item))
                _items[item] += count;
            else
                _items.Add(item, count);
        }
        public void AddCoins(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            _coins += count;
        }

        private bool ItemIsValid(IItem item, int count) =>
            item != null && count >= 0;
    }
}