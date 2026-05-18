public static class MobileDebug
{
    public static void Log(string message)
    {
        if (MobileDebugUI.Instance != null)
        {
            MobileDebugUI.Instance.AddLog(message);
        }
    }
}
