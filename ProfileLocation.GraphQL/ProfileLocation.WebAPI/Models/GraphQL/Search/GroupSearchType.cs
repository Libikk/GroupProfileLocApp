// <copyright file="GroupSearchType.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using System;
using GraphQL;
using GraphQL.Types;
using ProfileLocation.WebAPI.Models.GraphQL.Shared;
using ProfileLocation.Data.EF.Entities;
using ProfileLocation.Domain.ORM.Models;

namespace ProfileLocation.WebAPI.Models.GraphQL.Search
{
	public class GroupSearchType : InputObjectGraphType
	{
		public GroupSearchType()
		{
            Name = "GroupSearch";
			Description = "Group SearchContext";


            Field(typeof(ListGraphType<IntSearchType>), "Id");
        

            Field(typeof(ListGraphType<StringSearchType>), "Name");
        

            Field(typeof(ListGraphType<StringSearchType>), "Description");
        

            Field(typeof(ListGraphType<DateTimeSearchType>), "Created");
        

            Field(typeof(ListGraphType<BooleanSearchType>), "IsDeleted");
        

            var fldProfileGroups = Field(typeof(ProfileGroupSearchType), "ProfileGroups");
			fldProfileGroups.Description = "Searches for matches in ProfileGroups";
        
    
        }

    }

}