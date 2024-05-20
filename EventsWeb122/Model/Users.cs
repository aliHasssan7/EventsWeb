using System.ComponentModel.DataAnnotations;


namespace EventsWeb122.Model
{
	public class Users : EntityBase
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Password and Confirmation password did not natch")]
		public string ConfirmPassword { get; set; }
	}
}