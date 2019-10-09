using Casino.AdminPortal.Shared.Functional.DataAccessComponents;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.DAC;

namespace Casino.AdminPortal.Data.DataAccessComponents
{
    public class SampleDac : DacBase, ISampleDac
    {
        public SampleDac() : base(DacType.SampleDac)
        {

        }

        public ISampleDto SampleMethod(ISampleDto sampleDto)
        {
            //Entity Converter
            //Save to DB

            sampleDto.SampleProperty = "New Value";
            return sampleDto;
        }
    }

}
