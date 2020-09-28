using Automatonymous;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDogsOperations.Sagas
{
    public class HotDogStateMachine : MassTransitStateMachine<HotDogState>
    {

        public Event<ICreateSausage> SubmitCreateSausage { get; private set; }
        public HotDogStateMachine()
        {
            //InstanceState(x => x.CurrentState);
            Event(() => SubmitCreateSausage, x => x.CorrelateById(context => context.Message.CorrelationId));
            //ICreateSausage
        }
    }
}
