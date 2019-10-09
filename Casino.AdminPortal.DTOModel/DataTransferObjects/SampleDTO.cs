using Casino.AdminPortal.Shared;

namespace Casino.AdminPortal.DTOModel
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
