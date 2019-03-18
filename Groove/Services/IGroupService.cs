using System.Collections.Generic;
using CommonModels.Entity;

namespace Groove.Services
{
    public interface IGroupService
    {
        IEnumerable<Group> ListGroups(long? accountId);
    }
}