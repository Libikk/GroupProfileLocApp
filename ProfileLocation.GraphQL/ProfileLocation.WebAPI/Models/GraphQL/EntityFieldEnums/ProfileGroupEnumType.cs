// <copyright file="ProfileGroupEnumType.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using GraphQL.Types; 

namespace ProfileLocation.WebAPI.Models.GraphQL.EntityFieldEnums
{
	public class ProfileGroupEnumType : EnumerationGraphType
	{
		public ProfileGroupEnumType()
		{
			Name = "ProfileGroup";

            AddValue("id", "", "Id"); 
            AddValue("profileId", "", "ProfileId"); 
            AddValue("groupId", "", "GroupId"); 
            AddValue("isActive", "", "IsActive"); 
            AddValue("isDeleted", "", "IsDeleted"); 
		}
	}
}