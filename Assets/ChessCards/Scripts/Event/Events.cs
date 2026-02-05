
public class InitCardLibraryEvent
{

}

public class SetTrumpCardsEvent
{

}


public class ShowCardVisibleEvent
{
	public bool visible;

	public ShowCardVisibleEvent(bool visible)
	{
		this.visible = visible;
	}
}


public class PrepareVisibleEvent
{
	public bool visible;

	public PrepareVisibleEvent(bool visible)
	{
		this.visible = visible;
	}
}

public class CallScoreVisibleEvent
{
	public bool visible;

	public CallScoreVisibleEvent(bool visible)
	{
		this.visible = visible;
	}

}

public class AffordVisibleEvent
{
	public bool visible;

	public AffordVisibleEvent(bool visible)
	{
		this.visible = visible;
	}

}


public class ActiveAffordEvent
{
	public bool canAfford;
	public bool nonWithOut;

	public ActiveAffordEvent(bool canAfford,bool nonWithOut)
	{
		this.canAfford = canAfford;
		this.nonWithOut = nonWithOut;
	}

}