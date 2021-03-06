// <copyright file="ProfileRepository.cs" company="">
// Copyright (c) . All rights reserved.
// </copyright>
// <auto-generated />
using Microsoft.EntityFrameworkCore; 
using ProfileLocation.Data.EF.Contexts; 
using ProfileLocation.Domain.ORM.Models; 
using ProfileLocation.Domain.ORM.Interfaces; 
 
namespace ProfileLocation.Data.EF.Repositories 
{ 
    public class ProfileRepository : BaseRepository<Profile> 
    { 
        public ProfileRepository(ProfileLocationContext context, ILogManager logManager = null) : base(context, x => x.Id , logManager) 
        { 
      
        } 
 
        public override DbSet<Profile> EntityDbSet => ProfileLocationContext.Profiles; 
    } 
}
