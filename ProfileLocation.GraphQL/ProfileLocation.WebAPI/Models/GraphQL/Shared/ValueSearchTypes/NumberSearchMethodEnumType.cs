// <copyright file="NumberSearchMethodEnumType.cs" company="Victor Saly">
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
    public class NumberSearchMethodEnumType : EnumerationGraphType
    {
        public NumberSearchMethodEnumType()
        {
            Name = "NumberSearchMethod";

            AddValue(Range, "Min and max, min in value index 1, and max in value index 2", Range);
            AddValue(Equal, "", Equal);
            AddValue(NotEqual, "", NotEqual);
        }

        public const string Range = "range";
        public const string Equal = "equal";
        public const string NotEqual = "notEqual";
    }
}
