using System;
using System.Runtime.Serialization;

namespace Employee_MVC_app.Models.ViewModel
{
    [Serializable]
    internal class NullFieldsException : Exception
    {
        

        public NullFieldsException(string message) : base(message)
        {
        }

    }
}