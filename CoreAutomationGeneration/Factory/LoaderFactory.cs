using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;

namespace CoreAutomationGeneration.Factory
{
    /// <summary>
    /// LoaderFactory class
    /// </summary>
    public sealed class LoaderFactory
    {
        /// <summary>
        /// The instance
        /// </summary>
        private readonly static LoaderFactory _instance = new LoaderFactory();

        /// <summary>
        /// The configuration
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="LoaderFactory"/> class from being created.
        /// </summary>
        private LoaderFactory()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("DBConnections/DataSettings/DbConnectionStrings.json", true, true).Build();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static LoaderFactory Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
