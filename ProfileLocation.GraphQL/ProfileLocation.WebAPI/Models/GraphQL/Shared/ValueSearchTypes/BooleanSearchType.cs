// <copyright file="IntSearchType.cs" company="Storm Technologies Ltd">
// Copyright (c) Storm Technologies Ltd. All rights reserved.
// </copyright>
// <auto-generated />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace ProfileLocation.WebAPI.Models.GraphQL.Shared
{
    public class BooleanSearchType : BaseSearchType
    {
        public BooleanSearchType()
        {
            Name = "BooleanSearch";
            Description = "Boolean search";

            Field<BooleanGraphType>("value");
        }
    }
}
