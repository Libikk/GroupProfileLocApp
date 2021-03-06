// <copyright file="GroupEnumType.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using GraphQL.Types; 

namespace ProfileLocation.WebAPI.Models.GraphQL.EntityFieldEnums
{
	public class GroupEnumType : EnumerationGraphType
	{
		public GroupEnumType()
		{
			Name = "Group";

            AddValue("id", "", "Id"); 
            AddValue("name", "", "Name"); 
            AddValue("description", "", "Description"); 
            AddValue("created", "", "Created"); 
            AddValue("isDeleted", "", "IsDeleted"); 
		}
	}
}