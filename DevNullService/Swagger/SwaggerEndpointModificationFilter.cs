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
            if (operation.OperationId == "PostData")
            {
                operation.RequestBody = new OpenApiRequestBody
                {
                    Description = "payload",
                    Required = true,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
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