using System;
using Casino.AdminPortal.Shared.Functional.BusinessDomainComponents;
using Casino.AdminPortal.Shared.Functional.DataAccessComponents;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Business;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.Common.ExceptionHandling;
using Casino.AdminPortal.Shared.Infrastructure.Common.ExceptionHandling.CustomExceptionHandling;
using Casino.AdminPortal.Shared.Infrastructure.Common.OperationResult;
using Casino.AdminPortal.Shared.Infrastructure.DAC;

namespace Casino.AdminPortal.Business.Business
{
    public class SampleBdc : BdcBase, ISampleBdc
    {
        public SampleBdc() : base(BdcType.SampleBdc)
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
