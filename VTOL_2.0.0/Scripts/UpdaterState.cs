namespace VTOL
{
    public enum UpdaterState
    {
        Idle,
        GettingRepository,
        CheckingForUpdate,
        Downloading,
        Installing,
        RollingBack
    }
}
