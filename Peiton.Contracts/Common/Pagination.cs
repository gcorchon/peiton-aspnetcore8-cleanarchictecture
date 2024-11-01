using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Peiton.Contracts.Common;

public class Pagination
{
    [BindRequired()]
    public int Page { get; set; }

    [BindRequired()]
    public int Total { get; set; }
}

