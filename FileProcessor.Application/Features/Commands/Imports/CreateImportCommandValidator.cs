using FluentValidation;

namespace FileProcessor.Application.Features.Commands.Imports
{
    public class CreateImportCommandValidator : AbstractValidator<CreateImportCommand>
    {
        public CreateImportCommandValidator()
        {
            RuleFor(p => p.ExecutedBy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.FileSize)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThan(1_048_576).WithMessage("File size can not be greater than 1 MB");

        }
    }
}
