using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevNullService.Swagger
{
    public class SwaggerEndpointModificationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (operation.OperationId == "PostData")
            {
                operation.RequestBody = new OpenApiRequestBody
                {
                    Description = "payload",
                    Required = true,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/octet-stream"] = new OpenApiMediaType
                        {
                            // an empty OpenApiSchema is required to make the file upload UI appear
                            Schema = new OpenApiSchema()
                        },
                        ["text/plain"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema { Type = "string" }
                        }
                    }
                };
            }
        }
    }
}