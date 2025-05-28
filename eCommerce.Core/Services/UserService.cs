using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository usersRepository, IMapper _mapper) : IUsersService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest? loginRequest)
    {
        ApplicationUser? user = await usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        // return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Sucess: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "token" };
    }


    public async Task<AuthenticationResponse?> Register(RegisterRequest? registerRequest)
    {
        //Create a new ApplicationUser object from RegisterRequest
        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
        
        ApplicationUser? registeredUser = await usersRepository.AddUser(user);
        
        if (registeredUser == null)
        {
            return null;
        }

        //Return success response
        // return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token", Sucess: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "token" };
    }
}