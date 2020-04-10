// <copyright file="GroupType.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Resolvers;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using ProfileLocation.Data.EF.Entities;
using ProfileLocation.Data.EF.Contexts;
using ProfileLocation.Domain.ORM.Interfaces;
using ProfileLocation.Domain.ORM.Models;

namespace ProfileLocation.WebAPI.Models.GraphQL
{
	public class GroupType : ObjectGraphType<Group>
	{
		public GroupType(IDataLoaderContextAccessor accessor)
		{
            Name = "GroupQLType";
 
    		var fldId = Field(typeof(int).GetGraphTypeFromType(false), "Id");
			fldId.Resolver = new FuncFieldResolver<Group,object>(ctx => ctx.Source.Id);
 
    		var fldName = Field(typeof(string).GetGraphTypeFromType(true), "Name");
			fldName.Resolver = new FuncFieldResolver<Group,object>(ctx => ctx.Source.Name);
 
    		var fldDescription = Field(typeof(string).GetGraphTypeFromType(true), "Description");
			fldDescription.Resolver = new FuncFieldResolver<Group,object>(ctx => ctx.Source.Description);
 
    		var fldCreated = Field(typeof(DateTime).GetGraphTypeFromType(false), "Created");
			fldCreated.Resolver = new FuncFieldResolver<Group,object>(ctx => ctx.Source.Created);
 
    		var fldIsDeleted = Field(typeof(bool).GetGraphTypeFromType(false), "IsDeleted");
			fldIsDeleted.Resolver = new FuncFieldResolver<Group,object>(ctx => ctx.Source.IsDeleted);

            var fldProfileGroups = Field(typeof(ListGraphType<ProfileGroupType>), "ProfileGroups");
			fldProfileGroups.Resolver = new FuncFieldResolver<Group,object>(ctx => 
            { 
                var poItemsLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, ProfileLocation.Domain.ORM.Models.ProfileGroup>("GetProfileGroupsById", async ids => 
                { 
                    var repo = ((QLUserContext) ctx.UserContext).ServiceProvider.GetService<IRepository<ProfileLocation.Domain.ORM.Models.ProfileGroup>>(); 
                    var search = await repo.SearchAsync(s => ids.Contains(s.GroupId), int.MaxValue); 
                    return search.Items.ToLookup(k => k.GroupId);
                }); 
 
                return poItemsLoader.LoadAsync(ctx.Source.Id); 
            });

            var fldProfileGroupsCount = Field(typeof(IntGraphType), "ProfileGroupsCount");
            fldProfileGroupsCount.Resolver = new FuncFieldResolver<Group, object>((ctx) => 
            { 
                var db = ((QLUserContext) ctx.UserContext).ServiceProvider.GetService<ProfileLocationContext>(); 
                return db.Set<ProfileLocation.Domain.ORM.Models.ProfileGroup>().CountAsync(c => c.GroupId == ctx.Source.Id);
            });
        
        }

    }

}