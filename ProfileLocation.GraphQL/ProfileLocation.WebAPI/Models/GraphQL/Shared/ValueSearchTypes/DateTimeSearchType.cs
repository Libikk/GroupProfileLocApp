// <copyright file="DateTimeSearchType.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace ProfileLocation.WebAPI.Models.GraphQL.Shared
{
    public class DateTimeSearchType : BaseSearchType
    {
        public DateTimeSearchType()
        {
            Name = "DateTimeSearch";
            Field<DateTimeGraphType>("From");
            Field<DateTimeGraphType>("To");
        }
    }
}
