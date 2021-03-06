// <copyright file="EntityObjectEventService.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ProfileLocation.Domain.ORM.Interfaces;
using ProfileLocation.Domain.ORM.Models.Communications;

namespace ProfileLocation.Service.ORM.Communications
{
    public class EntityObjectEventService : IEntityObjectEventService
    {
        public void RaiseObjectEvent(EntityObjectEventMessageModel message)
        {
            Debug.WriteLine($"Object Event {message.EventType} for {message.Entity.GetType()}:{message.Entity.GetHashCode()}");
            EntityObjectEvent?.Invoke(this, message);
        }

        public event EventHandler<EntityObjectEventMessageModel> EntityObjectEvent;
    }
}
