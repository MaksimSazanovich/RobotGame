using Infrastructure.UI;

namespace Infrastructure.Factories
{
    public interface IUIFactory
    {
        LoadingCurtain CreateLoadingCurtain();
    }
}