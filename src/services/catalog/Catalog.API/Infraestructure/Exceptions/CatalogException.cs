using System;

namespace Catalog.API.Infraestructure.Exceptions
{
    public class CatalogException : Exception
    {
        public CatalogException()
        { }

        public CatalogException(string message)
            : base(message)
        { }

        public CatalogException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
