namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BdcType
    {
        [QualifiedTypeName("Casino.AdminPortal.Business.dll", "Casino.AdminPortal.Business.SampleBDC")]
        SampleBdc = 0,
        [QualifiedTypeName("Casino.AdminPortal.Business.dll", "Casino.AdminPortal.Business.UserBDC")]
        UserBdc = 1
    }
}
