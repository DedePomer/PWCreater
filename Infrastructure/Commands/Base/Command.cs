using System;
using System.Windows.Input;

namespace PWCreater.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged // Выполнятется если поменялось на ложь метод CanExecute
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object? parameter); // Ложь - команду выполнить нельзя; Истина - можно (может включать и выключать работу определённых элементов

        public abstract void Execute(object? parameter); //Логика комманды
    }
}
