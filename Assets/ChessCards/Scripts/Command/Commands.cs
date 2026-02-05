

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


public class ShowCardVisibleCommand : AbstractCommand
{
    bool visible;

    public ShowCardVisibleCommand(bool visible)
    {
        this.visible = visible;
    }

    protected override void OnExecute()
    {
        this.SendEvent(new ShowCardVisibleEvent(visible));
    }
}

public class PrepareVisibleCommand : AbstractCommand
{
    bool visible;

    public PrepareVisibleCommand(bool visible)
    {
        this.visible = visible;
    }

    protected override void OnExecute()
    {
        this.SendEvent(new PrepareVisibleEvent(visible));
    }
}

public class CallScoreVisibleCommand : AbstractCommand
{
    bool visible;

    public CallScoreVisibleCommand(bool visible)
    {
        this.visible = visible;
    }

    protected override void OnExecute()
    {
        this.SendEvent(new CallScoreVisibleEvent(visible));
    }
}

public class AffordVisibleCommand : AbstractCommand
{
    bool visible;

    public AffordVisibleCommand(bool visible)
    {
        this.visible = visible;
    }

    protected override void OnExecute()
    {
        this.SendEvent(new AffordVisibleEvent(visible));
    }
}


public class ActiveAffordCommand : AbstractCommand
{
    bool canAfford;
    bool nonWithOut;

    public ActiveAffordCommand(bool canAfford, bool nonWithOut)
    {
        this.canAfford = canAfford;
        this.nonWithOut = nonWithOut;
    }

    protected override void OnExecute()
    {
        this.SendEvent(new ActiveAffordEvent(canAfford, nonWithOut));
    }
}