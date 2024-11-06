
namespace BYT_Project.Utils
{
    public interface IConverter
    {
        Type? Type { get; }

        bool CanConvert(Type typeToConvert);
    }
}