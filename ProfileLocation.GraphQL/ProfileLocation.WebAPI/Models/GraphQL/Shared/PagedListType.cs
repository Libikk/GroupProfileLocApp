// <copyright file="PagedListType.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using GraphQL.Types;
using ProfileLocation.Domain.ORM.Interfaces;

namespace ProfileLocation.WebAPI.Models.GraphQL.Shared
{
    public class PagedListType<TModel, TQLType> : ObjectGraphType<IPagedList<TModel>> where TModel : class where TQLType : GraphType
    {
        public PagedListType()
        {
            Name = "PagedListResultOf" + typeof(TModel).Name;

            Field<ListGraphType<TQLType>>(
                "Items",
                resolve: context => context.Source.Items
            );

            Field(x => x.CurrentPage);
            Field(x => x.PageCount);
            Field(x => x.PageSize);
            Field(x => x.TotalCount);
        }
    }
}
