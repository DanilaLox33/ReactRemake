using System.Collections.Generic;
using UnityEngine.Localization.Settings;

public class LocalizationController
{
    private readonly List<ILocaleObject> localObject = new List<ILocaleObject>();

    public string GetLocalizedText(string key)
    {
        if (string.IsNullOrEmpty(key)) return string.Empty;
        return LocalizationSettings.StringDatabase.GetLocalizedString("Rect",key);
    }

    public void AddSubscriber(ILocaleObject locale)
    {
        if (localObject.Contains(locale))
        {
            return;
        }
        localObject.Add(locale);
    }

    public void RemoveSubscriber(ILocaleObject locale)
    {
        if (!localObject.Contains(locale))
        {
            return;
        }
        localObject.Remove(locale);
    }
}
