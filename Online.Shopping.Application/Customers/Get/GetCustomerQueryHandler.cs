using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Shopping.Application.Customers.Get
{
    internal sealed class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
    {
        private readonly IOnlineShoppingDbContext _onlineShoppingDbContext;
        public GetCustomerQueryHandler(IOnlineShoppingDbContext onlineShoppingDbContext)
        {
                _onlineShoppingDbContext = onlineShoppingDbContext;
        }

        public Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
