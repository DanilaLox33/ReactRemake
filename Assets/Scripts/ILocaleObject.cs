public interface ILocaleObject
{
    void Subscribe(ILocaleObject locale);
    void Unsubscribe(ILocaleObject locale);

    void UpdateText();
}
