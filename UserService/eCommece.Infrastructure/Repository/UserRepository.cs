using Dapper;
using eCommece.Infrastructure.DbContext;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommece.Infrastructure.Repository;

internal class UsersRepository(DapperDbContext dbContext) : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new unique user ID for the user
        user.UserID = Guid.NewGuid();

        // SQL Query to insert user data into the "Users" table.
        string query = "INSERT INTO public.\"users\"(\"userid\", \"email\", \"personname\", \"gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
        int rowCountAffected = await dbContext.Connection.ExecuteAsync(query, user);
    
        if (rowCountAffected > 0 )
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        //SQL query to select a user by Email and Password
        string query = "SELECT * FROM public.\"users\" WHERE \"email\"=@Email AND \"Password\"=@Password";
        
        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await dbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }
}