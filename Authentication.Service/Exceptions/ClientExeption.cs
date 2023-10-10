using System.Net;

namespace Authentication.Service.Exceptions;

public abstract class ClientExeption : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public abstract string TitleMessage { get; protected set; }
}