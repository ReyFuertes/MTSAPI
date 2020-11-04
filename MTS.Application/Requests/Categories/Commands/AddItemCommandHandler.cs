using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Application.Requests.Categories.Commands
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, string>
    {
        public Task<string> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
