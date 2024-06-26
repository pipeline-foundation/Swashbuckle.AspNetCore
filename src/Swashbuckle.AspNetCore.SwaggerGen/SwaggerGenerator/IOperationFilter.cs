﻿using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    public interface IOperationFilter
    {
        void Apply(OpenApiOperation operation, OperationFilterContext context);
    }

    public interface IOperationAsyncFilter
    {
        Task ApplyAsync(OpenApiOperation operation, OperationFilterContext context, CancellationToken cancellationToken);
    }

    public class OperationFilterContext
    {
        public OperationFilterContext(
            ApiDescription apiDescription,
            ISchemaGenerator schemaRegistry,
            SchemaRepository schemaRepository,
            MethodInfo methodInfo)
        {
            ApiDescription = apiDescription;
            SchemaGenerator = schemaRegistry;
            SchemaRepository = schemaRepository;
            MethodInfo = methodInfo;
        }

        public ApiDescription ApiDescription { get; }

        public ISchemaGenerator SchemaGenerator { get; }

        public SchemaRepository SchemaRepository { get; }

        public MethodInfo MethodInfo { get; }

        public string DocumentName => SchemaRepository.DocumentName;
    }
}
