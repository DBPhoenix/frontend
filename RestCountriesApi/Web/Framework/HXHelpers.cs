namespace Web.Framework;

public static class HXHelpers
{
    public static bool IsHistoryRestoreRequest(IHeaderDictionary headers)
    {
        return !IsHXRequest(headers) || IsHXRestoreRequest(headers);
    }
    
    private static bool IsHXRequest(IHeaderDictionary headers)
    {
        return headers["HX-Request"].FirstOrDefault() == "true";
    }

    private static bool IsHXRestoreRequest(IHeaderDictionary headers)
    {
        return headers["HX-History-Restore-Request"] == "true";
    }
}