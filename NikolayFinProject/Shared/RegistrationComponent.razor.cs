using BlazorApp4.Data;
using NikolayFinProject.Authentication;

namespace NikolayFinProject.Shared
{
    public partial class RegistrationComponent
    {
		UserAccount userAccount = new UserAccount();
		public bool _isRegInfoCorrect { get; set; }

		public void ValidFormSubmitted()
		{
			if (_isRegInfoCorrect)
			{
				UserAccount.AddUserAccountToDB(userAccount.UserName, userAccount.Password);
				//User.AddUserToDB(regUser.Login, regUser.Password, regUser.Name, regUser.Surname, regUser.Email, regUser.Phone, regUser.Img);
				FieldsClear();
			}
		}

		public void InvalidFormSubmitted()
		{
			_isRegInfoCorrect = false;
		}

		private void FieldsClear()
		{
			userAccount.UserName = string.Empty;
			userAccount.Password = string.Empty;
			//regUser.Login = string.Empty;
			//regUser.Password = string.Empty;
			//regUser.ConfirmPassword = string.Empty;
			//regUser.Email = string.Empty;
		}

		private void UserRegistration()
		{
			_isRegInfoCorrect = true;
		}
	}
}
