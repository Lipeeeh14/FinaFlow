using Fina.Api.Api;
using Fina.Common.Handlers;
using Fina.Common.Models;
using Fina.Common;
using Microsoft.AspNetCore.Mvc;
using Fina.Common.Responses;
using Fina.Common.Requests.Transaction;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
		=> app.MapGet("/", HandleAsync)
			.WithName("Transactions: Get By Period")
			.WithSummary("Recupera todas as de um período transações")
			.WithDescription("Recupera todas as de um período transações")
			.WithOrder(5)
			.Produces<Response<IEnumerable<Transaction>?>>();

	private static async Task<IResult> HandleAsync(
		ITransactionHandler handler,
		[FromQuery] DateTime? startDate = null,
		[FromQuery] DateTime? endDate = null,
		[FromQuery] int pageNumber = Configuration.DefaultPageNumber,
		[FromQuery] int pageSize = Configuration.DefaultPageSize)
	{
		var request = new GetTransactionsByPeriodRequest
		{
			UserId = ApiConfiguration.UserId,
			StartDate = startDate,
			EndDate = endDate,
			PageNumber = pageNumber,
			PageSize = pageSize
		};

		var response = await handler.GetByPeriodAsync(request);

		return response.IsSuccess
			? TypedResults.Ok(response)
			: TypedResults.BadRequest(response);
	}
}
