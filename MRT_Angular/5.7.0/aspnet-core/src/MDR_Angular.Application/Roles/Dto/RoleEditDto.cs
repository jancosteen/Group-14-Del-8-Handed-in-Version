using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using MDR_Angular.Authorization.Roles;
using System.ComponentModel.DataAnnotations;

namespace MDR_Angular.Roles.Dto
{
    public class RoleEditDto : EntityDto<int>
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }
    }
}