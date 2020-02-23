using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Frisia.Suebia;
using R5T.Lombardy.Standard;
using R5T.Pictia.Frisia.Standard;


namespace R5T.Gepidia.Remote.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IRemoteFileSystemOperator"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteFileSystemOperator(this IServiceCollection services,
            ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services.AddRemoteFileSystemOperator(
                services.AddSftpClientWrapperProviderAction(
                    addAwsEc2ServerHostFriendlyNameProvider),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteFileSystemOperator"/> service.
        /// </summary>
        public static ServiceAction<IRemoteFileSystemOperator> AddRemoteFileSystemOperatorAction(this IServiceCollection services,
            ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<IRemoteFileSystemOperator>(() => services.AddRemoteFileSystemOperator(
                addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the local-based <see cref="IFileSystemOperator"/> service.
        /// </summary>
        public static IServiceCollection AddFileSystemOperator(this IServiceCollection services,
            ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services.AddRemoteBasedFileSystemOperator(
                services.AddRemoteFileSystemOperatorAction(
                    addAwsEc2ServerHostFriendlyNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the local-based <see cref="IFileSystemOperator"/> service.
        /// </summary>
        public static ServiceAction<IFileSystemOperator> AddFileSystemOperatorAction(this IServiceCollection services,
            ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<IFileSystemOperator>(() => services.AddFileSystemOperator(
                addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }
    }
}
