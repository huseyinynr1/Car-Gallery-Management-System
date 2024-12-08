using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Utilities.DateTime;
public class MonthNameManager : IMonthNameService
{
    public string GetMonthName(int month)
    {
        return new CultureInfo("tr-TR").DateTimeFormat.GetMonthName(month);
    }
}
