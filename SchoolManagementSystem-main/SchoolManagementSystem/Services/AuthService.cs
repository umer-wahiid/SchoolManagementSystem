using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<User> _authRepository;

        public AuthService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _authRepository = unitOfWork.GenericRepository<User>();
        }

        public User Authenticate(OAuth auth)
        {
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));
            try
            {
                var user = _authRepository.FirstOrDefault(
                    x => (x.Password.Equals(auth.Password) &&
                    x.Username.Equals(auth.UserName)
                          || x.Email.Equals(auth.Email)));

                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred during authentication.", ex);
            }
        }

    }
}