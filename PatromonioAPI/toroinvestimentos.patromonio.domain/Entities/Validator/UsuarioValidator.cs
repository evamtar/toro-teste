using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.domain.Entities.Validator
{
    public class UsuarioValidator: AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("A referencia do objeto está nula");
                });

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("O login é necessário para autenticação.")
                .NotNull().WithMessage("O login é necessário para autenticação.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("A senha é necessária para autenticação.")
                .NotNull().WithMessage("A senha é necessária para autenticação.");
        }
    }
}
