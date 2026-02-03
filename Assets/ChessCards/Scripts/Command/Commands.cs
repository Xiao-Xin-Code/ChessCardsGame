

using QMVC;

public class InitCardLibraryCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<InitCardLibraryEvent>();
    }
}
