// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc.Internal
{
    /// <summary>
    /// A filter that configures <see cref="FormOptions"/> for the current request.
    /// </summary>
    public class RequestFormLimitsFilter : IAuthorizationFilter, IRequestFormLimitsPolicy
    {
        private readonly ILogger _logger;

        public RequestFormLimitsFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RequestFormLimitsFilter>();
        }

        public FormOptions FormOptions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (IsClosestPolicy(context.Filters))
            {
                var features = context.HttpContext.Features;
                var formFeature = features.Get<IFormFeature>();

                if (formFeature == null || formFeature.Form == null)
                {
                    // Request form has not been read yet, so set the limits
                    features.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, FormOptions));
                    _logger.AppliedRequestFormLimits();
                }
                else
                {
                    _logger.CannotApplyRequestFormLimits();
                }
            }
        }

        private bool IsClosestPolicy(IList<IFilterMetadata> filters)
        {
            // Determine if this instance is the 'effective' request form limits policy.
            for (var i = filters.Count - 1; i >= 0; i--)
            {
                if (filters[i] is IRequestFormLimitsPolicy filter)
                {
                    return ReferenceEquals(this, filter);
                }
            }

            Debug.Fail("The current instance should be in the list of filters.");
            return false;
        }
    }
}
