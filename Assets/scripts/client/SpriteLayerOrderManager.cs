using System.Collections;

public class SpriteLayerOrderManager : Singleton<SpriteLayerOrderManager>
{
	int order;
	public int Order
	{
		get
		{
			return ++order;
		}
	}


	public void reset()
	{
		this.order = 0;
	}
}
