namespace Common
{
    internal interface IParser
    {
        T Parse<T>(string inputString);
    }
}
