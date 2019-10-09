using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Common.CommonAttributes;
using Casino.AdminPortal.Shared.Infrastructure.Common.EntityModel.CustomAttributes;
using Casino.AdminPortal.Shared.Infrastructure.Common.EntityModel.Enums;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.DTOModel.DataTransferObjects
{
    [EntityMapping("Casino.AdminPortal.EntityDataModel.EntityModel.Sample", MappingType.TotalExplicit)]
    public class SampleDto : DtoBase, ISampleDto
    {
        public SampleDto() : base(DtoType.SampleDto)
        {

        }

        [EntityPropertyMapping(MappingDirectionType.Both, "SampleProperty")]
        public string SampleProperty { get; set; }
    }
         
}
