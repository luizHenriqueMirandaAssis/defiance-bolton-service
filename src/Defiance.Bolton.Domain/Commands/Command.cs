using System;

namespace Defiance.Bolton.Domain.Commands
{
    public class Command
    {
        public DateTime Timestamp { get; private set; }
        public bool ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public bool IsValid()
        {
            return ValidationResult;
        }
    }
}
