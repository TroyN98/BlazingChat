

using BlazingChat.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingChat.ViewModels
{
    public class ProfileViewModel : IProfileViewModel
    {
        public string Message { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AboutMe { get; set; }

        private readonly HttpClient _httpClient;

        public ProfileViewModel() { 
        
        }
        
        

        public ProfileViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async  Task UpdateProfile()
        {

           User user = this;
           await _httpClient.PutAsJsonAsync("user/updateProfile/10", user); //NUMBER IS FOR USER TO UPDATE
            //http client calling json & passing a strng & a user
            this.Message = "Profile updated successfully";
        }

        public async Task GetProfile()
        {
           User user = await _httpClient.GetFromJsonAsync<User>("user/getprofile/10"); //NUMBER IS FOR USER TO GET
            LoadCurrentObject(user);
            this.Message = "Profile loaded successfully";
        }

        private void LoadCurrentObject(ProfileViewModel  profileViewModel) 
        {
            this.FirstName = profileViewModel.FirstName;
            this.LastName = profileViewModel.LastName;
            this.EmailAddress = profileViewModel.EmailAddress;
            this.AboutMe = profileViewModel.AboutMe;
            //add more fields

        }

        public static implicit operator ProfileViewModel(User user) 
        {
            return new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId,
                AboutMe = user.AboutMe
            };
        }


        public static implicit operator User(ProfileViewModel profileViewModel)
        {
            return new User
            {
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress,
                UserId = profileViewModel.UserId,
                AboutMe = profileViewModel.AboutMe
            };
        }
    }
}
