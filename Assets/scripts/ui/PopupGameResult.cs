﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FreeNet;

public class PopupGameResult : MonoBehaviour {

	Sprite win_sprite;
	Sprite lose_sprite;

	Image win_lose;
	Text money;
	Text score;
	Text double_val;
	Text final_score;

	void Awake()
	{
		this.win_sprite = SpriteManager.Instance.get_sprite("win");
		this.lose_sprite = SpriteManager.Instance.get_sprite("lose");

		transform.Find("button_play").GetComponent<Button>().onClick.AddListener(this.on_touch);
		this.win_lose = transform.Find("title").GetComponent<Image>();
		this.money = transform.Find("money").GetComponent<Text>();
		this.score = transform.Find("score").GetComponent<Text>();
		this.double_val = transform.Find("double").GetComponent<Text>();
		this.final_score = transform.Find("final_score").GetComponent<Text>();
	}


	void on_touch()
	{
		UIManager.Instance.hide(UI_PAGE.POPUP_GAME_RESULT);

		CPacket send = CPacket.create((short)PROTOCOL.READY_TO_START);
		NetworkManager.Instance.send(send);
	}


	public void refresh(byte is_win,
		int money,
		int score,
		int double_val,
		int final_score)
	{
		if (is_win == 1)
		{
			this.win_lose.sprite = this.win_sprite;
		}
		else
		{
			this.win_lose.sprite = this.lose_sprite;
		}

		this.money.text = money.ToString();
		this.score.text = score.ToString();
		this.double_val.text = double_val.ToString();
		this.final_score.text = final_score.ToString();
	}
}
