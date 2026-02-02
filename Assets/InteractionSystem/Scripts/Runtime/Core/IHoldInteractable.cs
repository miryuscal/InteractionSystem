namespace InteractionSystem.Scripts.Runtime.Core
{
    public interface IHoldInteractable
    {
        float HoldDurationSeconds { get; }
        string GetHoldActionText();
    }
}
