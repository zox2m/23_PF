using System;
using System.Collections;
using System.Collections.Generic;

public class FloorSlot
{
	public byte slot_position { get; private set; }
	public List<Card> cards { get; private set; }
	
	public FloorSlot(byte position)
	{
		this.cards = new List<Card>();
		this.slot_position = position;

        reset();
	}


    public void reset()
    {
        this.cards.Clear();
    }


	public bool is_same(byte number)
	{
		if (this.cards.Count <= 0)
		{
			return false;
		}

		return this.cards[0].number == number;
	}


	public void add_card(Card card)
	{
		this.cards.Add(card);
	}


	public void remove_card(Card card)
	{
		this.cards.Remove(card);
	}

	
	public bool is_empty()
	{
		return this.cards.Count <= 0;
	}
}
