

using System.ComponentModel.DataAnnotations;

namespace firstApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Kullanıcı adını boş bırakmayınız!")]
        public string UserName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
