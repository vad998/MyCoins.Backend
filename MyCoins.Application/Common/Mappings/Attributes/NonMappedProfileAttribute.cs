namespace MyCoins.Application.Common.Mappings.Attributes
{
    /// <summary>
    /// Атрибут, выставляющийся для тех профилей, которые необходимо пропустить в процессе настройки AutoMapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class NonMappedProfileAttribute : Attribute { }
}
