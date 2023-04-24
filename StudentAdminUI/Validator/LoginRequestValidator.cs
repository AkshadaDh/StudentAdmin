using FluentValidation;

namespace StudentAdminUI.Validator
{
    public class LoginRequestValidator:AbstractValidator<DomainModels.LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Passworrd).NotEmpty();

        }
    }
}
