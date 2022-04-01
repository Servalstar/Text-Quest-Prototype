using Code.Dialogs;
using System;
using System.Collections.Generic;

namespace Code.Characters
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public IEnumerable<Dialog> Dialogs => _dialogs;

        protected List<Dialog> _dialogs = new List<Dialog>();

        public void AddDialog(Dialog dialog)
        {
            if (dialog == null)
                throw new ArgumentException();

            _dialogs.Add(dialog);
        }

        public Dialog GetNextDialog()
        {
            var dialog = _dialogs[0];

            TryRemoveCurrentDialoge();

            return dialog;
        }

        private void TryRemoveCurrentDialoge()
        {
            if (_dialogs.Count > 1)
                _dialogs.RemoveAt(0);
        }
    }
}