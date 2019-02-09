using WeatherApi.Application.Infrastructure.Repositories;
using WeatherApi.Application.Domain.Model.Local;
using Proto.User;
using WeatherApi.Application.Domain.Service.Interface;

namespace WeatherApi.Application.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        
        public GetUser FindUserByUserToken(string token)
        {
            User user = _userRepository.FindUserByUserToken(token);
            var u = new GetUser();
            u.UserID = user.Id;
            u.Name = user.Name;
            u.CityName = user.CityName;
            return u;
        }

        public string CreateUser(PostUser user)
        {
            string cityName = _userRepository.CreateUser(user);
            return cityName;
        }

        public string LoginUser(string uID, string password)
        {
            string cityName = _userRepository.Login(uID, password);
            return cityName;
        }
    }
}
