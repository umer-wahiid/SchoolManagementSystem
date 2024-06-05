using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Infrastructure.Authorization;
using SchoolManagementSystem.Interfaces;
using System.Security.Claims;

namespace SchoolManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<User> _authRepository;
        private readonly IJwtAuthorization _jwtAuthorization;

        public AuthService(IUnitOfWork unitOfWork, IJwtAuthorization jwtAuthorization)
        {
            this._unitOfWork = unitOfWork;
            this._authRepository = unitOfWork.GenericRepository<User>();
            this._jwtAuthorization = jwtAuthorization;
        }

        public string Authenticate(OAuth auth)
        {
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));
            try
            {
                var user = _authRepository
                    .FirstOrDefault
                    (x => x.Password.Equals(auth.Password) 
                    && (x.Username.Equals(auth.UserName)));

                if (user is null)
                    return null;

                return this._jwtAuthorization.CreateToken(user.Username);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred during authentication.", ex);
            }
        }

        public IEnumerable<Claim> ValidateToken(string token)
        {
            return this._jwtAuthorization.ValidateToken(token);
        }

    }
}