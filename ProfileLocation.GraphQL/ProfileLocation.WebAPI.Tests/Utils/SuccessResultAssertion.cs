// <copyright file="SuccessResultAssertion.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using Alba;
using GraphQL.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace ProfileLocation.WebAPI.Tests
{
    public class SuccessResultAssertion : GraphQLAssertion
    {
        private readonly string _result;
        private readonly bool _ignoreExtensions;

        public SuccessResultAssertion(string result, bool ignoreExtensions)
        {
            _result = result;
            _ignoreExtensions = ignoreExtensions;
        }

        /// <summary>
        /// Assert Override for Alba GraphQL Extension Scenario
        /// </summary>
        /// <param name="scenario"></param>
        /// <param name="context"></param>
        /// <param name="ex">Assertion Exception</param>
        public override void Assert(Scenario scenario, HttpContext context, ScenarioAssertionException ex)
        {
            var writer = new DocumentWriter();
            var expectedResult = writer.WriteToStringAsync(CreateQueryResult(_result)).GetAwaiter().GetResult();

            var body = ex.ReadBody(context);

            if (!body.Equals(expectedResult))
            {
                if (_ignoreExtensions)
                {

                    try
                    {
                        var json = JObject.Parse(body, new JsonLoadSettings() 
                        { 
                            CommentHandling = CommentHandling.Ignore, 
                            LineInfoHandling = LineInfoHandling.Ignore 
                        });

                        JToken token;
                        // Verify the property data appears in the payload
                        if (json.HasValues && json.TryGetValue("data", out token))
                        {
                            // convert to string and remove formatting
                            var data = token.ToString(Newtonsoft.Json.Formatting.None);
                            // Add the data structure as expected from the data payload
                            var bodyWithoutExtensions = @"{""data"":" + data + "}";
                            if (bodyWithoutExtensions.Equals(expectedResult))
                            {
                                return;
                            }
                            else
                            {
                                ex.Add($"Expected '{expectedResult}' but got '{bodyWithoutExtensions}'");
                            }
                        }
                    }
                    catch
                    {
                        //Handle the case when can't parje the json object
                        ex.Add("Unable to parse jsonObject. " + ex.Message);
                        return;
                    }
                    
                }
                else
                {
                    ex.Add($"Expected '{expectedResult}' but got '{body}'");
                }
            }
        }
    }
}
