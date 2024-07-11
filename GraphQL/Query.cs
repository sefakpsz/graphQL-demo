using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Data;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}