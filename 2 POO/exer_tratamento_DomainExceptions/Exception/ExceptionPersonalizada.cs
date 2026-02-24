using System;

namespace treino.Exception
{
    public class ExceptionPersonalizada : ApplicationException
    {
        public ExceptionPersonalizada(string message) : base(message)
        {
        }
    }
}
