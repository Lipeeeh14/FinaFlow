using System.Text.Json.Serialization;

namespace Fina.Common.Responses;

public abstract class PagedResponse<TData> : Response<TData>
{
    public int CurrentSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }

    [JsonConstructor]
	public PagedResponse(
		TData? data,
		int totalCount,
		int currentSize = 1,
		int pageSize = Configuration.DefaultPageSize)
		: base(data)
	{
		Data = data;
		CurrentSize = currentSize;
		PageSize = pageSize;
		TotalCount = totalCount;
	}

	public PagedResponse(
		TData? data,
		int code = Configuration.DefaultStatusCode,
		string? message = null)
		: base(data, code, message)
	{
	}
}
