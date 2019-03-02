using CommonModels.Entity;
using VkNet.Model.RequestParams;

namespace Groove.Domain
{
    public interface IAccountBuilder
    {
        IAccountBuilder WithMainInformation(long userId);
        IAccountBuilder WithGroups(GroupsGetParams getParams);
        Account GetResult();
    }
}