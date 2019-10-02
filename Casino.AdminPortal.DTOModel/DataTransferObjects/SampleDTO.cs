using Casino.AdminPortal.Shared;

namespace Casino.AdminPortal.DTOModel
{
    [EntityMapping("Casino.AdminPortal.EntityDataModel.EntityModel.Sample", MappingType.TotalExplicit)]
    public class SampleDTO : DTOBase, ISampleDTO
    {
        public SampleDTO() : base(DTOType.SampleDTO)
        {

        }

        [EntityPropertyMapping(MappingDirectionType.Both, "SampleProperty")]
        public string SampleProperty { get; set; }
    }
         
}
