using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions
{
    private that can be supplemented with static helper methods by using the extension mechanism. These methods throw exceptions.</para>
    /// <para>Содержит экземпляр расширяемого класса, который можно дополнять статическими вспомогательными методами путём использования механизма расширений. Эти методы занимаются выбрасыванием исключений.</para>
    /// </summary>
    public static class Throw
    {
        private that contains helper methods for throwing exceptions.</para>
        /// <para>Возвращает экземпляр класса корня-расширения, который содержит вспомогательные методы для выбрасывания исключений.</para>
        /// </summary>
        public static readonly ThrowExtensionRoot A = new ThrowExtensionRoot();
    }
}
