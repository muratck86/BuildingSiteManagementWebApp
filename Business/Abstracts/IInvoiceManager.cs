using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IInvoiceManager<T> : IManager<T> where T : BaseInvoice
    {
    }
}
