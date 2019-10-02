using Casino.AdminPortal.Shared;
using System;

namespace Casino.AdminPortal.Business
{
    public class SampleBDC : BDCBase, ISampleBDC
    {
        public SampleBDC() : base(BDCType.SampleBDC)
        {

        }

        public OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO)
        {
            OperationResult<ISampleDTO> retVal = null;

            try
            {
                ISampleDAC sampleDAC = (ISampleDAC)DACFactory.Instance.Create(DACType.SampleDAC);
                sampleDTO = sampleDAC.SampleMethod(sampleDTO);
                retVal = OperationResult<ISampleDTO>.CreateSuccessResult(sampleDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<ISampleDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<ISampleDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }
    }
}
