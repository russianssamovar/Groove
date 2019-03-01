using CommonModels.Entity;
using VkNet.Model.RequestParams;

namespace Groove.Domain
{
    public interface IAccountBuilder
    {
        IAccountBuilder WithMainInformation();
        IAccountBuilder WithGroups(GroupsGetParams getParams);
        Account GetResult();
    }
}