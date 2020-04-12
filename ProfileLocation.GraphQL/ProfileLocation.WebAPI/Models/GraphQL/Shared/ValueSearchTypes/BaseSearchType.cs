// <copyright file="BaseSearchType.cs" company="Victor Saly">
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
    public abstract class BaseSearchType : InputObjectGraphType
    {
        protected BaseSearchType()
        {
            var opFld = Field<SearchOperatorEnumType>("Operator", "");
            opFld.DefaultValue = "OR";
        }
    }
}