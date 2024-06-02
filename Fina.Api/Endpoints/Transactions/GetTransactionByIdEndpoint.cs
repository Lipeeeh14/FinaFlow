using Fina.Api.Api;
using Fina.Common.Handlers;
using Fina.Common.Models;
using Fina.Common.Requests.Transaction;
using Fina.Common.Responses;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
		=> app.MapGet("/{id}", HandleAsync)
			.WithName("Transactions: Get By Id")
			.WithSummary("Recupera uma transação")
			.WithDescription("Recupera uma transação")
			.WithOrder(4)
			.Produces<Response<Transaction?>>();

	private static async Task<IResult> HandleAsync(
		ITransactionHandler handler,
		long id)
	{
		var request = new GetTransactionByIdRequest
		{
			UserId = ApiConfiguration.UserId,
			Id = id
		};

		var response = await handler.GetByIdAsync(request);

		return response.IsSuccess
			? TypedResults.Ok(response)
			: TypedResults.BadRequest(response);
	}
}
