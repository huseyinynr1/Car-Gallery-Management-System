using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetModelByBrand;
public class GetListGetModelByBrandListItemDto : IDto
{
    public string Name { get; set; }
}
