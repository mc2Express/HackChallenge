namespace Infrastructure.Parse
{
    public interface IDocumentParser<out T>
    {
        T Parse(string documentPath);
    }
}
