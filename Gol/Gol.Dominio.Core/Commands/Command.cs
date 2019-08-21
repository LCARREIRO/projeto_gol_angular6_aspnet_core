using System;
using Gol.Dominio.Core.Events;
using FluentValidation.Results;

namespace Gol.Dominio.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}