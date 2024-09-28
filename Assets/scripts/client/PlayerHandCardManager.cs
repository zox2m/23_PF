using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerHandCardManager
{
	List<CardPicture> cards;


	public PlayerHandCardManager()
	{
		this.cards = new List<CardPicture>();
	}


	public void reset()
	{
		this.cards.Clear();
	}


	public void add(CardPicture card_picture)
	{
		this.cards.Add(card_picture);
	}


	public void remove(CardPicture card_picture)
	{
		bool result = this.cards.Remove(card_picture);
		if (!result)
		{
			UnityEngine.Debug.LogError("Cannot remove the card!");
		}
	}


	public int get_card_count()
	{
		return this.cards.Count;
	}


	public CardPicture get_card(int index)
	{
		return this.cards[index];
	}


	public CardPicture find_card(byte number, PAE_TYPE pae_type, byte position)
	{
		return this.cards.Find(obj => obj.card.is_same(number, pae_type, position));
	}


	public int get_same_number_count(byte number)
	{
		List<CardPicture> same_cards = this.cards.FindAll(obj => obj.is_same(number));
		return same_cards.Count;
	}


	public void sort_by_number()
	{
		this.cards.Sort((CardPicture lhs, CardPicture rhs) =>
		{
			if (lhs.card.number < rhs.card.number)
			{
				return -1;
			}
			else if (lhs.card.number > rhs.card.number)
			{
				return 1;
			}

			return 0;
		});
	}


	public void enable_all_colliders(bool flag)
	{
		for (int i = 0; i < this.cards.Count; ++i)
		{
			this.cards[i].enable_collider(flag);
		}
	}
}
