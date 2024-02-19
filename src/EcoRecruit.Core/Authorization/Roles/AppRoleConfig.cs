using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EcoRecruit.Authorization.Roles
{
    public static class AppRoleConfig
    {
        public static void Configure(IRoleManagementConfig roleManagementConfig)
        {
            // Static host roles

            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Host.Admin,
                    MultiTenancySides.Host
                )
            );
            roleManagementConfig.StaticRoles.Add(
              new StaticRoleDefinition(
                  StaticRoleNames.Host.HumanResourceOfficer,
                  MultiTenancySides.Host
              )
          );
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Host.HumanResourceAssistant,
                    MultiTenancySides.Host
                )
            );
            roleManagementConfig.StaticRoles.Add(
               new StaticRoleDefinition(
                   StaticRoleNames.Host.Applicant,
                   MultiTenancySides.Host
               )
           );

            // Static tenant roles
               
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Tenants.Admin,
                    MultiTenancySides.Tenant
                )
            );

            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Tenants.HumanResourceOfficer,
                    MultiTenancySides.Tenant
                )
            ); 
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Tenants.HumanResourceAssistant,
                    MultiTenancySides.Tenant
                )
            );
            roleManagementConfig.StaticRoles.Add(
               new StaticRoleDefinition(
                   StaticRoleNames.Tenants.Applicant,
                   MultiTenancySides.Tenant
               )
           );
        }
    }
}
