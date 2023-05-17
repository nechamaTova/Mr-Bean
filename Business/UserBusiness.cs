using Entities;
using Repository;
//using Zxcvbn;

namespace Business
{
    public class UserBusiness:IUserBusiness
    {
        IUserRepository _userRepository;
        IPasswordBusiness _passwordBusiness;

        public UserBusiness(IUserRepository userRepository, IPasswordBusiness passwordBusiness)
        {
            this._userRepository = userRepository;
            this._passwordBusiness = passwordBusiness;
        }
        public async Task<User> addNewUser(User newUser)
        {

            var pass = await _passwordBusiness.goodPassword(newUser.UserPassword);
            var found = await _userRepository.getUserByEmail(newUser.UserEmail);
            if (pass >= 2 && found==null)
                return await _userRepository.addNewUser(newUser);

            else
                return null;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.getUserById(id);
        }

        public async Task<User> SignIn(User userData)
        {
            return await _userRepository.signIn(userData);
        }

        public async Task<User> updateUser(int id, User updatedUser)
        {
            return await _userRepository.updateUser( id,updatedUser);
        }

    
    }
}