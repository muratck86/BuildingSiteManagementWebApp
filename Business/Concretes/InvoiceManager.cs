using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Concretes
{
    public class InvoiceManager<T> : BaseManager<T>, IInvoiceManager<T> where T : BaseInvoice, new()
    {
        public InvoiceManager(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
