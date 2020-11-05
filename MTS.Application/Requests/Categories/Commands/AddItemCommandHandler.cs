using MediatR;
using MTS.Application.Common.Interfaces;
using MTS.Application.Requests.Images.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Application.Requests.Categories.Commands
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, string>
    {
        private readonly IMediator _mediator;

        public AddItemCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {

            //TODO: Save to db for Items here...
            //

            //For uploading image here...
            var uploadResponse = await _mediator.Send(new UploadImageCommand { File = request.File }, cancellationToken);

            return uploadResponse;
        }
    }
}
