using System.Net;

namespace Authentication.Service.Exceptions;

public class BadRequestExeption : ClientExeption
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    public override string TitleMessage { get; protected set; } = String.Empty;
}