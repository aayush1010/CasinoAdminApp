using Casino.AdminPortal.Shared;

namespace Casino.AdminPortal.Data
{
    public class SampleDAC : DACBase, ISampleDAC
    {
        public SampleDAC() : base(DACType.SampleDAC)
        {

        }

        public ISampleDTO SampleMethod(ISampleDTO sampleDTO)
        {
            //Entity Converter
            //Save to DB

            sampleDTO.SampleProperty = "New Value";
            return sampleDTO;
        }
    }

}
