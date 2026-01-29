namespace ProjectName.Application.UsesCases.ProcessOrderPaid;

public class ProcessOrderPaidUseCase : IUseCase<ProcessOrderPaidRequest, ProcessOrderPaidResponse>
{
    public async Task<ProcessOrderPaidResponse> ExecuteAsync(ProcessOrderPaidRequest request)
    {

        var response = new ProcessOrderPaidResponse();
        return await Task.FromResult(response);
    }
}
