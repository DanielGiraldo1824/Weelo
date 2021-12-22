using MediatR;
using Weelo.Application.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Owner.Commands
{
    public class OwnerUpdateAsyncCommandHandler : AsyncRequestHandler<OwnerUpdateAsyncCommand>
    {

        private readonly IMessaging _messaging;

        public OwnerUpdateAsyncCommandHandler(IMessaging messaging)
        {
            _messaging = messaging ?? throw new ArgumentNullException(nameof(messaging));
        }

        protected override async Task Handle(OwnerUpdateAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            await _messaging.SendMessageAsync(request, "some-queue");
        }

    }
}
