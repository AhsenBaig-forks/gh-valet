using System.CommandLine;
using Valet.Handlers;

namespace Valet.Commands;

public abstract class ContainerCommand : BaseCommand
{
    private readonly string[] _args;

    protected ContainerCommand(string[] args)
    {
        _args = args;
    }

    protected abstract List<Option> Options { get; }

    protected override Command GenerateCommand(App app)
    {
        var command = base.GenerateCommand(app);

        foreach (var option in Options)
        {
            command.AddOption(option);
        }

        command.SetHandler(new ContainerHandler(app).Run(_args));

        return command;
    }
}