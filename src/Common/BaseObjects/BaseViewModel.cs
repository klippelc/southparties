namespace Common
{
    public abstract class BaseViewModel<TKey>
    {
        public TKey Id { get; set; }
        public string DomainKey { get; set; }
        public bool IsActive { get; set; } = true;

        // TODO: 12. Why are you using this enum?
        public FormActions FormAction { get; set; } = FormActions.Add; // TODO: 13. Is the default?
    }
}
