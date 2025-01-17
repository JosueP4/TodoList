using System.ComponentModel.DataAnnotations;

namespace TO_DO_LIST.Model
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public string User {  get; set; }
        public string Password {  get; set; }
        public string rol {  get; set; }
    }
}
