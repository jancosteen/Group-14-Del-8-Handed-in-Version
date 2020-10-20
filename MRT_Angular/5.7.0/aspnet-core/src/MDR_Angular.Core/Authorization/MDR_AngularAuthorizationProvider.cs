using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MDR_Angular.Authorization
{
    public class MDR_AngularAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Customer, L("Customer"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"));
            /*
            context.CreatePermission(PermissionNames.Pages_AD, L("AD"));
            context.CreatePermission(PermissionNames.Pages_AP, L("AP"));
            context.CreatePermission(PermissionNames.Pages_A, L("A"));
            context.CreatePermission(PermissionNames.Pages_Al, L("Al"));
            context.CreatePermission(PermissionNames.Pages_AS, L("AS"));
            context.CreatePermission(PermissionNames.Pages_E, L("E"));
            context.CreatePermission(PermissionNames.Pages_ES, L("ES"));
            context.CreatePermission(PermissionNames.Pages_ITMI, L("ITMI"));
            context.CreatePermission(PermissionNames.Pages_LT, L("LT"));
            context.CreatePermission(PermissionNames.Pages_MIA, L("MIA"));
            context.CreatePermission(PermissionNames.Pages_MIC, L("MIC"));
            context.CreatePermission(PermissionNames.Pages_MIP, L("MIP"));
            context.CreatePermission(PermissionNames.Pages_MI, L("MI"));
            context.CreatePermission(PermissionNames.Pages_MIS, L("MIS"));
            context.CreatePermission(PermissionNames.Pages_MIT, L("MIT"));
            context.CreatePermission(PermissionNames.Pages_MR, L("MR"));
            context.CreatePermission(PermissionNames.Pages_M, L("M"));
            context.CreatePermission(PermissionNames.Pages_OL, L("OL"));
            context.CreatePermission(PermissionNames.Pages_O, L("O"));
            context.CreatePermission(PermissionNames.Pages_OS, L("OS"));
            context.CreatePermission(PermissionNames.Pages_PC, L("PC"));
            context.CreatePermission(PermissionNames.Pages_PRF, L("PRF"));
            context.CreatePermission(PermissionNames.Pages_P, L("P"));
            context.CreatePermission(PermissionNames.Pages_PST, L("PST"));
            context.CreatePermission(PermissionNames.Pages_PWO, L("PWO"));
            context.CreatePermission(PermissionNames.Pages_PT, L("PT"));
            context.CreatePermission(PermissionNames.Pages_QC, L("QC"));
            context.CreatePermission(PermissionNames.Pages_QCS, L("QCS"));
            context.CreatePermission(PermissionNames.Pages_RR, L("RR"));
            context.CreatePermission(PermissionNames.Pages_R, L("R"));
            context.CreatePermission(PermissionNames.Pages_RS, L("RS"));
            context.CreatePermission(PermissionNames.Pages_RA, L("RA"));
            context.CreatePermission(PermissionNames.Pages_RF, L("RF"));
            context.CreatePermission(PermissionNames.Pages_RFR, L("RFR"));
            context.CreatePermission(PermissionNames.Pages_RI, L("RI"));
            context.CreatePermission(PermissionNames.Pages_RRI, L("RRI"));
            context.CreatePermission(PermissionNames.Pages_REST, L("REST"));
            context.CreatePermission(PermissionNames.Pages_RTR, L("RTR"));
            context.CreatePermission(PermissionNames.Pages_RT, L("RT"));
            context.CreatePermission(PermissionNames.Pages_SL, L("SL"));
            context.CreatePermission(PermissionNames.Pages_S, L("S"));
            context.CreatePermission(PermissionNames.Pages_SH, L("SH"));
            context.CreatePermission(PermissionNames.Pages_SHS, L("SHS"));
            context.CreatePermission(PermissionNames.Pages_SM, L("SM"));
            context.CreatePermission(PermissionNames.Pages_SMT, L("SMT"));
            context.CreatePermission(PermissionNames.Pages_SP, L("SP"));
            context.CreatePermission(PermissionNames.Pages_SPP, L("SPP"));
            context.CreatePermission(PermissionNames.Pages_SR, L("SR"));
            context.CreatePermission(PermissionNames.Pages_ST, L("ST"));
            context.CreatePermission(PermissionNames.Pages_SOL, L("SOL"));
            context.CreatePermission(PermissionNames.Pages_SO, L("SO"));
            context.CreatePermission(PermissionNames.Pages_SUP, L("SUP"));
            context.CreatePermission(PermissionNames.Pages_UC, L("WOR"));
            context.CreatePermission(PermissionNames.Pages_WOS, L("WOS"));*/
            context.CreatePermission(PermissionNames.Pages_SYSTEM_ADMIN, L("SYSTEM_ADMIN"));
            context.CreatePermission(PermissionNames.Pages_EMPLOYEE, L("EMPLOYEE"));



        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MDR_AngularConsts.LocalizationSourceName);
        }
    }
}
