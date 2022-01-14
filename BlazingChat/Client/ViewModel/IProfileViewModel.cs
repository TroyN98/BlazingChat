

using BlazingChat.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingChat.ViewModels
{
    public interface IProfileViewModel
    {
        public string Message { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AboutMe { get; set; }


        public Task UpdateProfile();
        public Task GetProfile();

        
    }
}
