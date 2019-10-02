using Casino.AdminPortal.Shared;
using System;

namespace Casino.AdminPortal.Business
{
    public class SampleBdc : BdcBase, ISampleBdc
    {
        public SampleBdc() : base(Shared.BdcType.SampleBdc)
        {

        }

        public OperationResult<ISampleDto> SampleMethod(ISampleDto sampleDto)
        {
            OperationResult<ISampleDto> retVal = null;

            try
            {
                ISampleDac sampleDac = (ISampleDac)DacFactory.Instance.Create(DacType.SampleDac);
                sampleDto = sampleDac.SampleMethod(sampleDto);
                retVal = OperationResult<ISampleDto>.CreateSuccessResult(sampleDto);
            }
            catch (DacException dacEx)
            {
                retVal = OperationResult<ISampleDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<ISampleDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }
    }
}
