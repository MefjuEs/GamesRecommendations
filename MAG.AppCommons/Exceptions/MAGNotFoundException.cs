using System;

namespace MAG.AppCommons 
{
    public class MAGNotFoundException : Exception
    {
        public MAGNotFoundException(string message) : base(message)
        {

        }
    }
}
