using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions
{
    /// <summary>
    /// Contains an instance of an extensible class that can be supplemented with static helper methods by using the extension mechanism. These methods throw exceptions.
    /// Содержит экземпляр расширяемого класса, который можно дополнять статическими вспомогательными методами путём использования механизма расширений. Эти методы занимаются выбрасыванием исключений.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Gets an instance of the extension root class that contains helper methods for throwing exceptions.
        /// Возвращает экземпляр класса корня-расширения, который содержит вспомогательные методы для выбрасывания исключений.
        /// </summary>
        public static readonly ThrowExtensionRoot A = new ThrowExtensionRoot();
    }
}
