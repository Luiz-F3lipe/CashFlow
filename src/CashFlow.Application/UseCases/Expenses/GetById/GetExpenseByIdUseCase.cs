using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public class GetExpenseByIdUseCase: IGetExpenseByIdUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;
    
    public GetExpenseByIdUseCase(IExpensesRepository respository, IMapper mapper)
    {
        _repository = respository;
        _mapper = mapper;
    }
    
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        return _mapper.Map<ResponseExpenseJson>(result);
    }
}