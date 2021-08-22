using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Contains an instance of an extensible class that can be supplemented with static helper methods by using the extension mechanism. These methods throw exceptions.</para>
    /// <para>Содержит экземпляр расширяемого класса, который можно дополнять статическими вспомогательными методами путём использования механизма расширений. Эти методы занимаются выбрасыванием исключений.</para>
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// <para>Gets an instance of the extension root class that contains helper methods for throwing exceptions.</para>
        /// <para>Возвращает экземпляр класса корня-расширения, который содержит вспомогательные методы для выбрасывания исключений.</para>
        /// </summary>
        public static readonly ThrowExtensionRoot A = new ThrowExtensionRoot();
    }
}
