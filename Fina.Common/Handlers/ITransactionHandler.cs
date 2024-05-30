using Fina.Common.Models;
using Fina.Common.Requests.Transaction;
using Fina.Common.Responses;

namespace Fina.Common.Handlers;

public interface ITransactionHandler
{
	Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
	Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
	Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
	Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
	Task<PagedResponse<IEnumerable<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
}
