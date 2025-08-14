using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Enums;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Amount = 8000,
            Date = DateTime.Now.AddDays(-1),
            Description = "IPhone 16 Pro Max",
            Title = "Apple",
            PaymentType = PaymentType.Cash,
        };
        // Act
        var result = validator.Validate(request);
        
        // Assert
        Assert.True(result.IsValid);
    }
}