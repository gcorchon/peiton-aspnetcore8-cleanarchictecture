using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Peiton.Contracts.Common;

public class Pagination
{
    public int Page { get; set; }

    public int Total { get; set; }
}

