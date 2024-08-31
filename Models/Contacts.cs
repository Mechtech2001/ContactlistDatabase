using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactlistDatabase.Models
{
    
    public class Contacts
    {
        //sets primary key
        public int ContactsId { get; set; }
        //sets up database fields with requirments and input validation 
        [Required(ErrorMessage ="Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format 123-456-7890.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an Address.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.\-]+$", ErrorMessage = "Address can contain only letters, numbers, spaces, commas, periods, and hyphens.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter note, If it doesn't apply put 'N/A'")]
        public string Note {  get; set; } = string.Empty;
        //changes the url to make the content more predictable
        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + "contact-info";
    }
}
