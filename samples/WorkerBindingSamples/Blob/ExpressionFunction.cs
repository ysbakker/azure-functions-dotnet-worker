﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SampleApp
{
    public class ExpressionFunction
    {
        private readonly ILogger<ExpressionFunction> _logger;

        public ExpressionFunction(ILogger<ExpressionFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ExpressionFunction))]
        public void Run(
            [QueueTrigger("expression-trigger")] Book book,
            [BlobInput("input-container/{id}.txt")] string myBlob,
            FunctionContext context)
        {
            _logger.LogInformation("Trigger content: {content}", book);
            _logger.LogInformation("Blob content: {content}", myBlob);
        }
    }
}
