using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Commands
{
    public interface ICommandManager
    {
        void IVoke(ICommand command);
        void Undo();
    }

    public class CommandManager : ICommandManager
    {
        public Stack<ICommand> commands = new Stack<ICommand>();

        public void IVoke(ICommand command)
        {
            if (command.CanExcute())
            {
                commands.Push(command);
                command.Execute();
            }            
        }

        public void Undo()
        {
            var command = commands.Pop();
            command.Undo();
        }

    }
}