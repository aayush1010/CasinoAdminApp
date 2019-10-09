using Casino.AdminPortal.Shared;

namespace Casino.AdminPortal.Data
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
