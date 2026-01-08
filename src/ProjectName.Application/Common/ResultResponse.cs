namespace ProjectName.Application.Common;

public abstract class ResultResponse
{
    private readonly List<string> _errors = new();

    public IReadOnlyCollection<string> Errors => _errors;
    public bool IsSuccess => !_errors.Any();

    public void AddError(string error)
        => _errors.Add(error);
}
