namespace Project.Features.Command
{
    /// <summary>
    /// Кнопка выхода.
    /// </summary>
    public sealed class ExitButton : ConcreteButton<ExitCommand>
    {
        protected override void InitButton()
        {
            command = new ExitCommand();
        }
    }
}