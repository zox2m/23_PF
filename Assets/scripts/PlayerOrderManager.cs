using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerOrderManager
{
	public List<Card> random_cards { get; private set; }

	public PlayerOrderManager()
	{
	}


	public void reset(GostopEngine engine)
	{
		this.random_cards = engine.get_random_cards(2);
	}
}
