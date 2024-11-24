using EventManagementBusiness.Models.Dtos;
using FluentValidation;

namespace EventManagementBusiness.Validators
{
    public class EventDtoValidator : AbstractValidator<EventDto>
    {
        public EventDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start date is required").Must(IsValidDate)
                .WithMessage("Invalid start date format");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("End date is required").Must(IsValidDate)
                .WithMessage("Invalid end date format");

        }

        private bool IsValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

    }

}
