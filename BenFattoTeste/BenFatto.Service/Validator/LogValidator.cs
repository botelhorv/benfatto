using BenFatto.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenFatto.Service.Validator
{
    public class LogValidator : AbstractValidator<Log>
    {
        private static string DEFAULT_MESSAGE = "É necessário informar ";
        public LogValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("O Objeto não pode ser encontrado.");
                    });

            RuleFor(c => c.Method)
                .NotEmpty().WithMessage(string.Concat(DEFAULT_MESSAGE, "o metodo."))
                .NotNull().WithMessage(string.Concat(DEFAULT_MESSAGE, "o metodo."));

            RuleFor(c => c.Url)
                .NotEmpty().WithMessage(string.Concat(DEFAULT_MESSAGE, "a Url."))
                .NotNull().WithMessage(string.Concat(DEFAULT_MESSAGE, "a Url."));

            RuleFor(c => c.HttpVersion)
                .NotEmpty().WithMessage(string.Concat(DEFAULT_MESSAGE, "o Http Version."))
                .NotNull().WithMessage(string.Concat(DEFAULT_MESSAGE, "o Http Version."));

            RuleFor(c => c.HttpCode)
                .NotEmpty().WithMessage(string.Concat(DEFAULT_MESSAGE, "o codigo Http."))
                .NotNull().WithMessage(string.Concat(DEFAULT_MESSAGE, "o codigo Http."));

            RuleFor(c => c.Method)
                .NotEmpty().WithMessage(string.Concat(DEFAULT_MESSAGE, "a Url de destino."))
                .NotNull().WithMessage(string.Concat(DEFAULT_MESSAGE, "a Url de destino."));
        }
    }
}
