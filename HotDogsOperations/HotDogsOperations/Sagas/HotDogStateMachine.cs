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
        public Event<ISausageCreated> SausageCreataApproved { get; private set; }
        public Event<ICreateBun> SubmitCreateBun { get; private set; }
        public Event<IBunCreated> BunCreateApproved { get; private set; }

        public State SausageSubmitted { get; set; }
        public State SausageCreated { get; set; }
        public State BunSubmitted { get; set; }
        public State BunCreated { get; set; }


        public HotDogStateMachine()
        {
            //InstanceState(x => x.CurrentState);
            Event(() => SubmitCreateSausage, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => SausageCreataApproved, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => SubmitCreateBun, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => BunCreateApproved, x => x.CorrelateById(context => context.Message.CorrelationId));

            InstanceState(x => x.CurrentState);

            Initially(
                When(SubmitCreateSausage)
                .TransitionTo(SausageSubmitted));

            During(SausageSubmitted,
                When(SausageCreataApproved).TransitionTo(SausageCreated));

            During(SausageCreated,
                    When(SubmitCreateBun).TransitionTo(BunSubmitted));

            During(BunSubmitted, When(BunCreateApproved).TransitionTo(BunCreated).Finalize());

            
            //ICreateSausage
        }
    }
}
