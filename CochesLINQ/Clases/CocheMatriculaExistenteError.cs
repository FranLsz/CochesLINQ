using System;
using System.Runtime.Serialization;

namespace CochesLINQ
{
    [Serializable]
    internal class CocheMatriculaExistenteError : Exception
    {
        public CocheMatriculaExistenteError()
        {
        }

        public CocheMatriculaExistenteError(string message) : base(message)
        {
        }

        public CocheMatriculaExistenteError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CocheMatriculaExistenteError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}