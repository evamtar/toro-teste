using FluentValidation;
using System;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.domain.Entities.Validator
{
    public class TransacaoValidator : AbstractValidator<Transacao>
    {
        public TransacaoValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("A referencia do objeto está nula");
                });

            RuleFor(c => c.TipoOperacao)
                .NotEmpty().WithMessage("O tipo da operação é necessário para realizar uma movimentação.")
                .NotNull().WithMessage("O tipo da operação é necessário para realizar uma movimentação.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O valor da operação é necessário para realizar uma movimentação.")
                .NotNull().WithMessage("O valor da operação é necessário para realizar uma movimentação.")
                .NotEqual((decimal)0.00).WithMessage("O valor da operação não pode ser zerado para realizar uma movimentação.");
           
        }
    }
}
