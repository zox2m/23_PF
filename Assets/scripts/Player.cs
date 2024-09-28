using System;
using System.Collections;
using System.Collections.Generic;
using FreeNet;

public enum PLAYER_TYPE : byte
{
    HUMAN,
    AI
}

public class Player
{
    public delegate void SendFn(CPacket msg);

    SendFn send_function;
    public byte player_index { get; private set; }
    public PlayerAgent agent { get; private set; }

    PLAYER_TYPE player_type;
    AIPlayer ai_logic;

    //  서버 관련 내용 삭제 필요

    public Player(byte player_index, PLAYER_TYPE player_type, SendFn send_function, LocalServer local_server)
    {
        this.player_index = player_index;
		this.agent = new PlayerAgent(player_index);
        this.player_type = player_type;

        switch (this.player_type)
        {
            case PLAYER_TYPE.HUMAN:
                this.send_function = send_function;
                break;

            case PLAYER_TYPE.AI:
                this.ai_logic = new AIPlayer(local_server);
                this.send_function = this.ai_logic.send;
                break;
        }
    }


    public void send(CPacket msg)
    {
        this.send_function(msg);
    }


	public void reset()
	{
		if (this.ai_logic != null)
		{
			this.ai_logic.reset();
		}
	}


    public bool is_autoplayer()
    {
        return this.player_type == PLAYER_TYPE.AI;
    }
}
