

using QMVC;

public class InitCardLibraryCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<InitCardLibraryEvent>();
    }
}

public class SetTrumpCardsCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<SetTrumpCardsEvent>();
    }
}
