using BackendTestAPI.Models.Entities;
using FluentValidation;

namespace BackendTestAPI.Validators
{
    public class FeedbackValidator : AbstractValidator<Feedback>
    {
        public FeedbackValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .MaximumLength(500).WithMessage("Subject cannot exceed 500 characters.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(150).WithMessage("Name cannot exceed 150 characters.");

            RuleFor(x => x.Contactnumber)
                .Matches(@"^\+?\d{10,20}$").WithMessage("Enter a valid contact number.")
                .When(x => !string.IsNullOrEmpty(x.Contactnumber));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(150).WithMessage("Email cannot exceed 150 characters.");
        }
    }

}
