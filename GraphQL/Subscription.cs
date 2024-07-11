using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL
{
    public class Subscription
    {
        [Subscribe  ]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}