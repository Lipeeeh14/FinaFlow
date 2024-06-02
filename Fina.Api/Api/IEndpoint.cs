namespace Fina.Api.Api;

public interface IEndpoint
{
	static abstract void Map(IEndpointRouteBuilder app);
}
