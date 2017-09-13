// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http.Features;
using Xunit;

namespace Microsoft.AspNetCore.Mvc
{
    public class RequestFormLimitsAttributeTest
    {
        [Fact]
        public void CreatesFormOptions_WithDefaults()
        {
            // Arrange
            var formOptions = new FormOptions();

            // Act
            var requestFormLimitsAttribute = new RequestFormLimitsAttribute();

            // Assert
            Assert.Equal(formOptions.BufferBody, requestFormLimitsAttribute.BufferBody);
            Assert.Equal(formOptions.BufferBodyLengthLimit, requestFormLimitsAttribute.BufferBodyLengthLimit);
            Assert.Equal(formOptions.KeyLengthLimit, requestFormLimitsAttribute.KeyLengthLimit);
            Assert.Equal(formOptions.MemoryBufferThreshold, requestFormLimitsAttribute.MemoryBufferThreshold);
            Assert.Equal(formOptions.MultipartBodyLengthLimit, requestFormLimitsAttribute.MultipartBodyLengthLimit);
            Assert.Equal(formOptions.MultipartBoundaryLengthLimit, requestFormLimitsAttribute.MultipartBoundaryLengthLimit);
            Assert.Equal(formOptions.MultipartHeadersCountLimit, requestFormLimitsAttribute.MultipartHeadersCountLimit);
            Assert.Equal(formOptions.MultipartHeadersLengthLimit, requestFormLimitsAttribute.MultipartHeadersLengthLimit);
            Assert.Equal(formOptions.ValueCountLimit, requestFormLimitsAttribute.ValueCountLimit);
            Assert.Equal(formOptions.ValueLengthLimit, requestFormLimitsAttribute.ValueLengthLimit);
        }

        [Fact]
        public void UpdatesFormOptions_WithOverridenValues()
        {
            // Arrange
            var formOptions = new FormOptions();
            formOptions.BufferBody = true;
            formOptions.BufferBodyLengthLimit = 0;
            formOptions.KeyLengthLimit = 0;
            formOptions.MemoryBufferThreshold = 0;
            formOptions.MultipartBodyLengthLimit = 0;
            formOptions.MultipartBoundaryLengthLimit = 0;
            formOptions.MultipartHeadersCountLimit = 0;
            formOptions.MultipartHeadersLengthLimit = 0;
            formOptions.ValueCountLimit = 0;
            formOptions.ValueLengthLimit = 0;
            var requestFormLimitsAttribute = new RequestFormLimitsAttribute();

            // Act
            requestFormLimitsAttribute.BufferBody = true;
            requestFormLimitsAttribute.BufferBodyLengthLimit = 0;
            requestFormLimitsAttribute.KeyLengthLimit = 0;
            requestFormLimitsAttribute.MemoryBufferThreshold = 0;
            requestFormLimitsAttribute.MultipartBodyLengthLimit = 0;
            requestFormLimitsAttribute.MultipartBoundaryLengthLimit = 0;
            requestFormLimitsAttribute.MultipartHeadersCountLimit = 0;
            requestFormLimitsAttribute.MultipartHeadersLengthLimit = 0;
            requestFormLimitsAttribute.ValueCountLimit = 0;
            requestFormLimitsAttribute.ValueLengthLimit = 0;

            // Assert
            Assert.Equal(formOptions.BufferBody, requestFormLimitsAttribute.BufferBody);
            Assert.Equal(formOptions.BufferBodyLengthLimit, requestFormLimitsAttribute.BufferBodyLengthLimit);
            Assert.Equal(formOptions.KeyLengthLimit, requestFormLimitsAttribute.KeyLengthLimit);
            Assert.Equal(formOptions.MemoryBufferThreshold, requestFormLimitsAttribute.MemoryBufferThreshold);
            Assert.Equal(formOptions.MultipartBodyLengthLimit, requestFormLimitsAttribute.MultipartBodyLengthLimit);
            Assert.Equal(formOptions.MultipartBoundaryLengthLimit, requestFormLimitsAttribute.MultipartBoundaryLengthLimit);
            Assert.Equal(formOptions.MultipartHeadersCountLimit, requestFormLimitsAttribute.MultipartHeadersCountLimit);
            Assert.Equal(formOptions.MultipartHeadersLengthLimit, requestFormLimitsAttribute.MultipartHeadersLengthLimit);
            Assert.Equal(formOptions.ValueCountLimit, requestFormLimitsAttribute.ValueCountLimit);
            Assert.Equal(formOptions.ValueLengthLimit, requestFormLimitsAttribute.ValueLengthLimit);
        }
    }
}
