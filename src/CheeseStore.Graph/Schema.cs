using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseStore.Graph
{
    public static class Schema
    {
        private static readonly IMapper Mapper;

        static Schema()
        {
            var mapping = new MapperConfiguration(
                configuration =>
                {
                    configuration.CreateMap<CheeseStore.Store.Client.Cheese, Cheese>()
                        .ForMember(cheese => cheese.Available, options => options.Ignore());
                }
            );

            Mapper = mapping.CreateMapper();
        }
        private static async Task<IReadOnlyDictionary<Guid, int>> FetchInventory(this CheeseStore.Inventory.Client.IInventoryClient inventoryClient, IReadOnlyList<Guid> cheeses)
        {
            var response = await inventoryClient.PostAsync(new CheeseStore.Inventory.Client.Request { Ids = cheeses.ToArray() });

            return cheeses
                .GroupJoin(response.Available, id => id, available => available.Id, (id, available) => (Id: id, Available: available.Select(a => a.Quantity).FirstOrDefault()))
                .ToDictionary(tuple => tuple.Id, tuple => tuple.Available);
        }

        private static async Task<object> ResolveInventory(this IResolverContext context)
        {
            var dataLoader = context.BatchDataLoader<Guid, int>(
                "availableById",
                context.Service<CheeseStore.Inventory.Client.IInventoryClient>().FetchInventory);

            return await dataLoader.LoadAsync(context.Parent<Cheese>().Id, context.RequestAborted);
        }

        private static async Task<object> ResolveCheeses(this IResolverContext context)
        {
            var results = await context.Service<CheeseStore.Store.Client.IStoreClient>().GetAsync();

            return results.Select(source => Mapper.Map<CheeseStore.Store.Client.Cheese, Cheese>(source)).ToArray();
        }

        public static ISchemaBuilder Build()
        {
            return SchemaBuilder.New()
                .AddQueryType<Query>(
                    query => query
                        .Field(f => f.Cheese())
                            .Resolver(context => context.ResolveCheeses()))
                .AddObjectType<Cheese>(
                    cheese => cheese
                        .Field(f => f.Available)
                            .Resolver(context => context.ResolveInventory()))
                .ModifyOptions(o => o.RemoveUnreachableTypes = true);
        }
    }
}
