using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy.Standard;
using R5T.Pictia.Frisia.Standard;


namespace R5T.Gepidia.Remote.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IRemoteFileSystemOperator"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteFileSystemOperator(this IServiceCollection services, string hostFriendlyName)
        {
            services.AddRemoteFileSystemOperator(
                services.AddSftpClientWrapperProviderAction(hostFriendlyName),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteFileSystemOperator"/> service.
        /// </summary>
        public static ServiceAction<IRemoteFileSystemOperator> AddRemoteFileSystemOperatorAction(this IServiceCollection services, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<IRemoteFileSystemOperator>(() => services.AddRemoteFileSystemOperator(hostFriendlyName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the local-based <see cref="IFileSystemOperator"/> service.
        /// </summary>
        public static IServiceCollection AddFileSystemOperator(this IServiceCollection services, string hostFriendlyName)
        {
            services.AddRemoteBasedFileSystemOperator(
                services.AddRemoteFileSystemOperatorAction(hostFriendlyName));

            return services;
        }

        /// <summary>
        /// Adds the local-based <see cref="IFileSystemOperator"/> service.
        /// </summary>
        public static ServiceAction<IFileSystemOperator> AddFileSystemOperatorAction(this IServiceCollection services, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<IFileSystemOperator>(() => services.AddFileSystemOperator(hostFriendlyName));
            return serviceAction;
        }
    }
}
