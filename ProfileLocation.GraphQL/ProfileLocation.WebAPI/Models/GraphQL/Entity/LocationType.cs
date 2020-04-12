// <copyright file="LocationType.cs" company="">
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
	public class LocationType : ObjectGraphType<Location>
	{
		public LocationType(IDataLoaderContextAccessor accessor)
		{
            Name = "LocationQLType";
 
    		var fldId = Field(typeof(int).GetGraphTypeFromType(false), "Id");
			fldId.Resolver = new FuncFieldResolver<Location,object>(ctx => ctx.Source.Id);
 
    		var fldAddress = Field(typeof(string).GetGraphTypeFromType(true), "Address");
			fldAddress.Resolver = new FuncFieldResolver<Location,object>(ctx => ctx.Source.Address);
 
    		var fldViewPort = Field(typeof(string).GetGraphTypeFromType(true), "ViewPort");
			fldViewPort.Resolver = new FuncFieldResolver<Location,object>(ctx => ctx.Source.ViewPort);
 
    		var fldLocation1 = Field(typeof(string).GetGraphTypeFromType(true), "Location1");
			fldLocation1.Resolver = new FuncFieldResolver<Location,object>(ctx => ctx.Source.Location1);
 
    		var fldPlaceId = Field(typeof(int).GetGraphTypeFromType(true), "PlaceId");
			fldPlaceId.Resolver = new FuncFieldResolver<Location,object>(ctx => ctx.Source.PlaceId);
 
    		var fldProfileId = Field(typeof(int).GetGraphTypeFromType(false), "ProfileId");
			fldProfileId.Resolver = new FuncFieldResolver<Location,object>(ctx => ctx.Source.ProfileId);

            var fldProfiles = Field(typeof(ListGraphType<ProfileType>), "Profiles");
			fldProfiles.Resolver = new FuncFieldResolver<Location,object>(ctx => 
            { 
                var poItemsLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, ProfileLocation.Domain.ORM.Models.Profile>("GetProfilesById", async ids => 
                { 
                    var repo = ((QLUserContext) ctx.UserContext).ServiceProvider.GetService<IRepository<ProfileLocation.Domain.ORM.Models.Profile>>(); 
                    var search = await repo.SearchAsync(s => ids.Contains(s.LocationId.Value), int.MaxValue); 
                    return search.Items.ToLookup(k => k.LocationId.Value);
                }); 
 
                return poItemsLoader.LoadAsync(ctx.Source.Id); 
            });

            var fldProfilesCount = Field(typeof(IntGraphType), "ProfilesCount");
            fldProfilesCount.Resolver = new FuncFieldResolver<Location, object>((ctx) => 
            { 
                var db = ((QLUserContext) ctx.UserContext).ServiceProvider.GetService<ProfileLocationContext>(); 
                return db.Set<ProfileLocation.Domain.ORM.Models.Profile>().CountAsync(c => c.LocationId == ctx.Source.Id);
            });
        
        }

    }

}