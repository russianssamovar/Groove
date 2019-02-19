using System;
using System.Threading.Tasks;
using CommonModels;
using DBRepository.Interfaces;

namespace Groove.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository ?? throw new ArgumentNullException(nameof(identityRepository));
        }

        public async Task<User> GetUser(string userName)
        {
            return await _identityRepository.GetUser(userName);
        }

        public User GetUser(string userName, string password)
        {
            return _identityRepository.GetUser(userName, password);
        }

        public bool Reistration(string userName, string password)
        {
            var user = _identityRepository.GetUser(userName);
            return user == null && _identityRepository.Reistration(userName, password);
        }
    }
}
