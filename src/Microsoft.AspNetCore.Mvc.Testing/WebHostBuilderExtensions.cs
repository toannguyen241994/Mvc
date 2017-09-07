// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Mvc.Testing
{
    /// <summary>
    /// Testing extensions for creating an configuring an <see cref="IWebHostBuilder"/> for end to end in memory tests.
    /// </summary>
    public static class WebHostBuilderTestingExtensions
    {
        private static readonly string CreateDefaultBuilder = nameof(CreateDefaultBuilder);

        /// <summary>
        /// Initializes a new <see cref="IWebHostBuilder"/> instance by calling a method 
        /// <c>public static CreateDefaultBuilder(string [] args)</c> on the
        /// entry point class for the assembly. Tipically, <c>Program</c>.
        /// </summary>
        /// <typeparam name="TStartup">The type of the Startup class.</typeparam>
        /// <param name="args">The arguments passed to CreateDefaultBuilder, typically from <c>Program.Main(string [] args)</c>.</param>
        /// <returns>An <see cref="IWebHostBuilder"/> instance.</returns>
        public static IWebHostBuilder FromStartup<TStartup>(string[] args)
        {
            var factory = typeof(TStartup).Assembly.EntryPoint.DeclaringType.GetMethod(CreateDefaultBuilder, BindingFlags.Static | BindingFlags.Public);
            if (factory == null)
            {
                return null;
            }

            return (IWebHostBuilder)factory.Invoke(null, new object[] { args });
        }

        /// <summary>
        /// Configures the application content root.
        /// </summary>
        /// <param name="builder">The <see cref="IWebHostBuilder"/> to configure.</param>
        /// <param name="solutionName">The glob pattern to use for finding the solution.</param>
        /// <param name="solutionRelativePath">The relative path to the content root from the solution file.</param>
        /// <returns>An instance of this <see cref="IWebHostBuilder"/></returns>
        public static IWebHostBuilder UseSolutionRelativeContentRoot(
            this IWebHostBuilder builder,
            string solutionRelativePath,
            string solutionName = "*.sln")
        {
            if (solutionRelativePath == null)
            {
                throw new ArgumentNullException(nameof(solutionRelativePath));
            }

            var applicationBasePath = AppContext.BaseDirectory;

            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                var solutionPath = Directory.EnumerateFiles(directoryInfo.FullName, solutionName).FirstOrDefault();
                if (solutionPath != null)
                {
                    builder.UseContentRoot(Path.GetFullPath(Path.Combine(directoryInfo.FullName, solutionRelativePath)));
                    return builder;
                }

                directoryInfo = directoryInfo.Parent;
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Solution root could not be located using application root {applicationBasePath}.");
        }
    }
}
