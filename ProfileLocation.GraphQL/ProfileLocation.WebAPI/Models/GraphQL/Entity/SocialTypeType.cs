// <copyright file="SocialTypeType.cs" company="">
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
	public class SocialTypeType : ObjectGraphType<ProfileLocation.Domain.ORM.Models.SocialType>
	{
		public SocialTypeType(IDataLoaderContextAccessor accessor)
		{
            Name = "SocialTypeQLType";
 
    		var fldId = Field(typeof(int).GetGraphTypeFromType(false), "Id");
			fldId.Resolver = new FuncFieldResolver<ProfileLocation.Domain.ORM.Models.SocialType,object>(ctx => ctx.Source.Id);
 
    		var fldName = Field(typeof(string).GetGraphTypeFromType(true), "Name");
			fldName.Resolver = new FuncFieldResolver<ProfileLocation.Domain.ORM.Models.SocialType,object>(ctx => ctx.Source.Name);
 
    		var fldIconUrl = Field(typeof(string).GetGraphTypeFromType(true), "IconUrl");
			fldIconUrl.Resolver = new FuncFieldResolver<ProfileLocation.Domain.ORM.Models.SocialType,object>(ctx => ctx.Source.IconUrl);
 
    		var fldIsDeleted = Field(typeof(bool).GetGraphTypeFromType(false), "IsDeleted");
			fldIsDeleted.Resolver = new FuncFieldResolver<ProfileLocation.Domain.ORM.Models.SocialType,object>(ctx => ctx.Source.IsDeleted);

            var fldSocials = Field(typeof(ListGraphType<SocialType>), "Socials");
			fldSocials.Resolver = new FuncFieldResolver<ProfileLocation.Domain.ORM.Models.SocialType,object>(ctx => 
            { 
                var poItemsLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, ProfileLocation.Domain.ORM.Models.Social>("GetSocialsById", async ids => 
                { 
                    var repo = ((QLUserContext) ctx.UserContext).ServiceProvider.GetService<IRepository<ProfileLocation.Domain.ORM.Models.Social>>(); 
                    var search = await repo.SearchAsync(s => ids.Contains(s.SocialTypeId), int.MaxValue); 
                    return search.Items.ToLookup(k => k.SocialTypeId);
                }); 
 
                return poItemsLoader.LoadAsync(ctx.Source.Id); 
            });

            var fldSocialsCount = Field(typeof(IntGraphType), "SocialsCount");
            fldSocialsCount.Resolver = new FuncFieldResolver<ProfileLocation.Domain.ORM.Models.SocialType, object>((ctx) => 
            { 
                var db = ((QLUserContext) ctx.UserContext).ServiceProvider.GetService<ProfileLocationContext>(); 
                return db.Set<ProfileLocation.Domain.ORM.Models.Social>().CountAsync(c => c.SocialTypeId == ctx.Source.Id);
            });
        
        }

    }

}