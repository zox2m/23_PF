using System;
using System.Collections;
using System.Collections.Generic;

public class FloorCardManager
{
	// 처음 바닥에 놓을 카드를 보관할 컨테이너.
	List<Card> begin_cards;

	// 같은 번호의 카드를 하나로 묶어서 보관하는 컨테이너. 바닥 카드 정렬 이후에는 이 컨테이너를 사용한다.
	public List<FloorSlot> slots { get; private set; }

	
	public FloorCardManager()
	{
		// 바닥 초기화.
		this.slots = new List<FloorSlot>();
        for (byte position = 0; position < 12; ++position)
        {
            this.slots.Add(new FloorSlot(position));
        }

		this.begin_cards = new List<Card>();
	}


    public void reset()
    {
        this.begin_cards.Clear();
        for (byte position = 0; position < 12; ++position)
        {
            this.slots[position].reset();
        }
    }


	public void put_to_begin_card(Card card)
	{
		this.begin_cards.Add(card);
	}


	FloorSlot find_empty_slot()
	{
		FloorSlot slot = this.slots.Find(obj => obj.is_empty());
		return slot;
	}


	FloorSlot find_slot(byte card_number)
	{
		FloorSlot slot = this.slots.Find(obj => obj.is_same(card_number));
		return slot;
	}


	// 해당번호와 동일한 위치에 카드를 놓는다.
	public void puton_card(Card card)
	{
		FloorSlot slot = find_slot(card.number);
		if (slot == null)
		{
			slot = find_empty_slot();
			slot.add_card(card);
			return;
		}

		this.slots[slot.slot_position].add_card(card);
	}


	public void remove_card(Card card)
	{
		FloorSlot slot = find_slot(card.number);
		if (slot != null)
		{
			slot.remove_card(card);
			//UnityEngine.Debug.Log(string.Format("removed card. {0}, {1}, {2}, remain {3}",
			//	card.number, card.pae_type, card.position,
			//	slot.cards.Count));
		}
	}


    public byte get_same_number_card_count(byte number)
    {
		FloorSlot slot = find_slot(number);
		if (slot == null)
		{
			return 0;
		}
		return (byte)slot.cards.Count;
    }


    public Card get_first_card(byte number)
    {
		FloorSlot slot = find_slot(number);
		if (slot == null)
		{
			return null;
		}
		return slot.cards[0];
    }


    public List<Card> get_cards(byte number)
    {
		FloorSlot slot = find_slot(number);
		if (slot == null)
		{
			return null;
		}
		return slot.cards;
    }


    public List<Card> pop_bonus_cards()
    {
        List<Card> bonus_cards = new List<Card>();
        for (int i = 0; i < this.begin_cards.Count; ++i)
        {
            if (Card.is_bonus_card(this.begin_cards[i].number))
            {
                bonus_cards.Add(this.begin_cards[i]);
            }
        }

        for (int i = 0; i < bonus_cards.Count; ++i)
        {
            this.begin_cards.Remove(bonus_cards[i]);
        }

        return bonus_cards;
    }


	/// <summary>
	/// 바닥에 깔린 카드중 동일한 카드들은 하나의 슬롯으로 쌓는다.
	/// </summary>
	public void refresh_floor_cards()
	{
		for (int i = 0; i < this.begin_cards.Count; ++i)
		{
			puton_card(this.begin_cards[i]);
		}
		this.begin_cards.Clear();
	}


    public bool validate_floor_card_counts()
    {
        int floor_card_count = 0;
        for (int i = 0; i < this.slots.Count; ++i)
        {
            floor_card_count += this.slots[i].cards.Count;
        }

        if (floor_card_count != 8)
        {
            return false;
        }

        return true;
    }


	public bool is_empty()
	{
		for (int i = 0; i < this.slots.Count; ++i)
		{
			if (!this.slots[i].is_empty())
			{
				return false;
			}
		}

		return true;
	}
}
